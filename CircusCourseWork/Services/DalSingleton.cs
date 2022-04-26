using System.Collections.Generic;
using System.IO;
using System.Linq;
using CircusDataAccessLibrary.Authorization.Implementations;
using CircusDataAccessLibrary.Authorization.Interfaces;
using CircusDataAccessLibrary.Data;
using CircusDataAccessLibrary.Repositories.Implementations;
using CircusDataAccessLibrary.Repositories.Interfaces;

namespace CircusCourseWork.Services
{
    public class DalSingleton
    {
        private static DalSingleton? _instance;
        public static DalSingleton Instance => _instance ??= new DalSingleton();

        public IAuth Auth { get; private set; }
        public ICircusRepository CircusRepository { get; private set; }
        public IPerformanceRepository PerformanceRepository { get; private set; }
        public IRoleRepository RoleRepository { get; private set; }
        public ITicketCategoryInfoRepository TicketCategoryInfoRepository { get; private set; }
        public ITicketRepository TicketRepository { get; private set; }
        public IUserRepository UserRepository { get; private set; }

        public DalSingleton()
        {
            string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Repositories");

            string authRepFileName = Path.Combine(directoryPath, $"{nameof(Auth)}.xml");
            string circusRepFileName = Path.Combine(directoryPath, $"{nameof(CircusRepository)}.xml");
            string performanceRepFileName = Path.Combine(directoryPath, $"{nameof(PerformanceRepository)}.xml");
            string roleRepFileName = Path.Combine(directoryPath, $"{nameof(RoleRepository)}.xml");
            string ticketCategoryInfoRepFileName = Path.Combine(directoryPath, $"{nameof(TicketCategoryInfoRepository)}.xml");
            string ticketRepFileName = Path.Combine(directoryPath, $"{nameof(TicketRepository)}.xml");
            string userRepFileName = Path.Combine(directoryPath, $"{nameof(UserRepository)}.xml");

            if (!File.Exists(authRepFileName)) File.Create(authRepFileName).Dispose();
            if (!File.Exists(circusRepFileName)) File.Create(circusRepFileName).Dispose();
            if (!File.Exists(performanceRepFileName)) File.Create(performanceRepFileName).Dispose();
            if (!File.Exists(roleRepFileName)) File.Create(roleRepFileName).Dispose();
            if (!File.Exists(ticketCategoryInfoRepFileName)) File.Create(ticketCategoryInfoRepFileName).Dispose();
            if (!File.Exists(ticketRepFileName)) File.Create(ticketRepFileName).Dispose();
            if (!File.Exists(userRepFileName)) File.Create(userRepFileName).Dispose();

            CircusRepository = new CircusXmlRepository(circusRepFileName);
            PerformanceRepository = new PerformanceXmlRepository(performanceRepFileName);
            RoleRepository = new RoleXmlRepository(roleRepFileName);
            TicketCategoryInfoRepository = new TicketCategoryInfoXmlRepository(ticketCategoryInfoRepFileName);
            TicketRepository = new TicketXmlRepository(ticketRepFileName);
            UserRepository = new UserXmlRepository(userRepFileName);

            Auth = new Auth(authRepFileName, UserRepository);

            InitializeIfNeeded();
        }

        private void InitializeIfNeeded()
        {
            var adminRole = new Role
                            {
                                Name = "Admin"
                            };
            var adminUser = new User
                            {
                                Name="Administrator",
                                Login = "admin",
                                Password = "admin"
                            };
            var tci1 = new TicketCategoryInfo
                       {
                           Name = "Категория билетов №1",
                           Count = 10,
                           Price = 50M
                       };
            var tci2 = new TicketCategoryInfo
                       {
                           Name = "Категория билетов №2",
                           Count = 40,
                           Price = 25M
                       };
            var tci3 = new TicketCategoryInfo
                       {
                           Name = "Категория билетов №3",
                           Count = 50,
                           Price = 10M
                       };
            var circus = new Circus
                         {
                             Name = "Самый лучший цирк в мире!!!",
                             TicketCategoryInfoIds = new List<int>()
                         };

            if (!RoleRepository.Read().Any(r => r.Name == adminRole.Name))
                RoleRepository.Create(adminRole);
            else
                adminRole = RoleRepository.Read().First(r => r.Name == adminRole.Name);
            
            adminUser.RoleId = adminRole.Id;
            if (!UserRepository.Read().Any(u => u.Login == adminUser.Login && u.Password == adminUser.Password))
                UserRepository.Create(adminUser);
            else
                adminUser = UserRepository.Read()
                                          .First(u => u.Login == adminUser.Login && u.Password == adminUser.Password);

            if (TicketCategoryInfoRepository.Read().Count == 0)
            {
                TicketCategoryInfoRepository.Create(tci1);
                TicketCategoryInfoRepository.Create(tci2);
                TicketCategoryInfoRepository.Create(tci3);
                
                circus.TicketCategoryInfoIds.Add(tci1.Id);
                circus.TicketCategoryInfoIds.Add(tci2.Id);
                circus.TicketCategoryInfoIds.Add(tci3.Id);
            }

            if (CircusRepository.Read().Count == 0) CircusRepository.Create(circus);
        }
    }
}