using TimesheetsManagementProject.Models.Domain;
using TimesheetsManagementProject.Models.Dto;
using TimesheetsManagementProject.Repositories;

namespace TimesheetsManagementProject.Services
{
    public interface IClientsRepository 
    {
        Task<List<ClientResponse>> GetClients();
        Task<Clients> SaveClient(Clients clients);
        Task<Clients> DeleteClient(int clientId);
        Task<Clients> UpdateClient(int Id , Clients clients);
    }

    public class ClientResponse
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string CurrencyId { get; set; }
        public string BillingMethodId { get; set; }
        public string EmailId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }
        public int Mobile { get; set; }
        public string Fax { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }

    }
}
