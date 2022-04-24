using System;
using System.Collections.Generic;
using System.Linq;
using CircusDataAccessLibrary.Data;
using CircusDataAccessLibrary.Repositories.Interfaces;
using CircusTests.DAL.Data;
using Xunit;

namespace CircusTests.DAL.Tests
{
    [Collection(nameof(RepositoriesCollection))]
    public class PerformanceRepositoryTest
    {
        private readonly IRepository<Performance, int> _rep;

        public PerformanceRepositoryTest(XmlRepositoriesFixture fixture)
        {
            _rep = fixture.PerformanceRepository;
        }

        [Fact]
        public void CallCrudMethodsWithNullArguments_ThrowsNullArgumentException()
        {
            Assert.Throws<ArgumentNullException>(() => _rep.Create(null!));
            Assert.Throws<ArgumentNullException>(() => _rep.Update(null!));
        }

        [Fact]
        public void Create_CheckIfCreatedIsEqualToCreating()
        {
            var creatingPerformance = new Performance
                                      {
                                          Name = "Testing_Create"
                                      };
            _rep.Create(creatingPerformance);
            Performance? createdPerformance = _rep.Read().FirstOrDefault(p => p.Id == creatingPerformance.Id);

            Assert.NotNull(createdPerformance);
            Assert.Equal(creatingPerformance, createdPerformance);
        }

        [Fact]
        public void Read_CheckIfReadingDataContainsInsertedData()
        {
            var creatingPerformances = new List<Performance>
                                       {
                                           new()
                                           {
                                               Name = "Testing_Read_0"
                                           },
                                           new()
                                           {
                                               Name = "Testing_Read_1"
                                           },
                                           new()
                                           {
                                               Name = "Testing_Read_2"
                                           }
                                       };
            creatingPerformances.ForEach(_rep.Create);
            List<Performance> createdPerformances = _rep.Read();

            creatingPerformances.ForEach(performance => Assert.Contains(performance, createdPerformances));
        }

        [Fact]
        public void Update_CheckIfUpdatedIsEqualToUpdating()
        {
            var updatingPerformance = new Performance
                                      {
                                          Name = "Testing_Update_0"
                                      };
            _rep.Create(updatingPerformance);
            updatingPerformance.Name = "Testing_Update_1";

            _rep.Update(updatingPerformance);
            Performance? updatedPerformance = _rep.Read().FirstOrDefault(p => p.Id == updatingPerformance.Id);

            Assert.NotNull(updatedPerformance);
            Assert.Equal(updatingPerformance, updatedPerformance);
        }

        [Fact]
        public void Delete_CheckIfDeletedIsEqualToDeleting()
        {
            var deletingPerformance = new Performance
                                      {
                                          Name = "Testing_Delete"
                                      };
            _rep.Create(deletingPerformance);

            _rep.Delete(deletingPerformance.Id);
            Performance? updatedPerformance = _rep.Read().FirstOrDefault(p => p.Id == deletingPerformance.Id);

            Assert.Null(updatedPerformance);
        }
    }
}