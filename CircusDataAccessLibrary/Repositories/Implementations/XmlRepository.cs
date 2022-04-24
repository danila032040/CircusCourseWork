using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CircusDataAccessLibrary.Data;
using CircusDataAccessLibrary.Helpers.Interfaces;
using CircusDataAccessLibrary.Repositories.Interfaces;

namespace CircusDataAccessLibrary.Repositories.Implementations
{
    public abstract class XmlRepository<TEntity, TId> : IRepository<TEntity, TId>
        where TId : struct, IComparable<TId>
        where TEntity : BaseEntity<TId>
    {
        private readonly string _filePath;

        private readonly IXmlConverter _xmlConverter;
        private readonly IIdGenerator<TId> _idGenerator;

        protected XmlRepository(string filePath,
                                IXmlConverter xmlConverter,
                                IIdGenerator<TId> idGenerator)
        {
            if (filePath is null) throw new ArgumentNullException(nameof(filePath));
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"File with path {nameof(filePath)} not found.");

            _filePath = filePath;
            _xmlConverter = xmlConverter;
            _idGenerator = idGenerator;
        }

        public void Create(TEntity entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));

            List<TEntity> entities = Read();

            do
            {
                entity.Id = _idGenerator.Next();
            } while (entities.Any(e => e.Id.Equals(entity.Id)));

            entities.Add(entity);

            File.WriteAllText(_filePath, _xmlConverter.ConvertToXml(entities));
        }

        public List<TEntity> Read()
        {
            return _xmlConverter.ConvertFromXml<List<TEntity>>(File.ReadAllText(_filePath));
        }

        public void Update(TEntity entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));

            List<TEntity> entities = Read();
            int entityToUpdateIndex = entities.FindIndex(e => e.Id.Equals(entity.Id));

            if (entityToUpdateIndex == -1)
                throw new ArgumentException($"There is no {nameof(TEntity)} with {entity.Id} id in repository.");

            entities[entityToUpdateIndex] = entity;

            File.WriteAllText(_filePath, _xmlConverter.ConvertToXml(entities));
        }

        public void Delete(TId entityId)
        {
            List<TEntity> entities = Read();
            int entityToDeleteIndex = entities.FindIndex(e => e.Id.Equals(entityId));

            if (entityToDeleteIndex == -1)
                throw new ArgumentException($"There is no {nameof(TEntity)} with {entityId} id in repository.");

            entities.RemoveAt(entityToDeleteIndex);

            File.WriteAllText(_filePath, _xmlConverter.ConvertToXml(entities));
        }
    }
}