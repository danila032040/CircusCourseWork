using System;
using System.IO;
using CircusDataAccessLibrary.Repositories.Implementations;
using CircusDataAccessLibrary.Repositories.Interfaces;

namespace CircusTests.DAL.Data
{
    public class XmlRepositoriesFixture : IDisposable
    {
        private readonly string _directoryPath;
        
        public string PerformanceRepositoryFilePath { get; }
        public string RoleRepositoryFilePath { get; }
        public string TicketCategoryInfoRepositoryFilePath { get; }
        public string TicketRepositoryFilePath { get; }
        public string UserRepositoryFilePath { get; }
        
        public IPerformanceRepository PerformanceRepository{ get; }
        public IRoleRepository RoleRepository{ get; }
        public ITicketCategoryInfoRepository TicketCategoryInfoRepository{ get; }
        public ITicketRepository TicketRepository{ get; }
        public IUserRepository UserRepository{ get; }

        public XmlRepositoriesFixture()
        {
            _directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "TestTemporaryFiles");
            
            PerformanceRepositoryFilePath = Path.Combine(_directoryPath, $"{nameof(PerformanceXmlRepository)}.xml");
            RoleRepositoryFilePath = Path.Combine(_directoryPath, $"{nameof(RoleXmlRepository)}.xml");
            TicketCategoryInfoRepositoryFilePath = Path.Combine(_directoryPath, $"{nameof(TicketCategoryInfoXmlRepository)}.xml");
            TicketRepositoryFilePath = Path.Combine(_directoryPath, $"{nameof(TicketXmlRepository)}.xml");
            UserRepositoryFilePath = Path.Combine(_directoryPath, $"{nameof(UserXmlRepository)}.xml");
            
            Directory.CreateDirectory(_directoryPath);

            File.Create(PerformanceRepositoryFilePath).Dispose();
            File.Create(RoleRepositoryFilePath).Dispose();
            File.Create(TicketCategoryInfoRepositoryFilePath).Dispose();
            File.Create(TicketRepositoryFilePath).Dispose();
            File.Create(UserRepositoryFilePath).Dispose();

            PerformanceRepository =
                new PerformanceXmlRepository(Path.Combine(_directoryPath, $"{nameof(PerformanceXmlRepository)}.xml"));
            RoleRepository = new RoleXmlRepository(Path.Combine(_directoryPath, $"{nameof(RoleXmlRepository)}.xml"));
            TicketCategoryInfoRepository =
                new TicketCategoryInfoXmlRepository(
                    Path.Combine(_directoryPath, $"{nameof(TicketCategoryInfoXmlRepository)}.xml"));
            TicketRepository =
                new TicketXmlRepository(Path.Combine(_directoryPath, $"{nameof(TicketXmlRepository)}.xml"));
            UserRepository = new UserXmlRepository(Path.Combine(_directoryPath, $"{nameof(UserXmlRepository)}.xml"));
        }


        public void Dispose()
        {
            PerformanceRepository.Dispose();
            RoleRepository.Dispose();
            TicketCategoryInfoRepository.Dispose();
            TicketRepository.Dispose();
            UserRepository.Dispose();
            
            Directory.Delete(_directoryPath, true);
        }
    }
}