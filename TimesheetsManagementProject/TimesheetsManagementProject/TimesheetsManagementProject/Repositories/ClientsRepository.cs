using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI;
using System.Configuration;
using System.Linq.Expressions;
using TimesheetsManagementProject.Data;
using TimesheetsManagementProject.Models.Domain;
using TimesheetsManagementProject.Models.Dto;
using TimesheetsManagementProject.Repositories;

namespace TimesheetsManagementProject.Services
{
    public class ClientsRepository : IClientsRepository
    {
        private readonly DataContext _dataContext;
        private readonly IConfiguration _configuration;
        public ClientsRepository(DataContext dataContext, IConfiguration configuration)
        {
            _dataContext = dataContext;
            _configuration = configuration;
        }

        public async Task<Clients> DeleteClient(int clientId)
        {
            try
            {
                var existingClient = await _dataContext.Clients.FirstOrDefaultAsync(x => x.ClientId == clientId);

                if (existingClient == null)
                {
                    return null;
                }

                existingClient.IsDeleted = true;

                await _dataContext.SaveChangesAsync();

                return existingClient;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete the client.", ex);
            }
        }

        public async Task<List<ClientResponse>> GetClients()
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DataConnectionStrings")))
            {
                var query = $@"
                          SELECT                    
                            c.ClientId
                            ,c.ClientName
                            ,c.CurrencyId
                            ,c.BillingMethodId
                            ,c.IsActive
                            ,c.EmailId
                            ,c.FirstName
                            ,c.LastName
                            ,c.Phone
                            ,c.Mobile
                            ,c.Fax
                        FROM Clients  c
                        WHERE c.IsDeleted = 0
                        ORDER BY c.ClientId
                    ";

                return (await connection.QueryAsync<ClientResponse>(query).ConfigureAwait(false)).ToList();
            }

        }


        public async Task<Clients> SaveClient(Clients clients)
        {
            try
            {
                await _dataContext.Clients.AddAsync(clients);
                await _dataContext.SaveChangesAsync();
                return clients;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to save the client.", ex);
            }
        }

        public async Task<Clients> UpdateClient(int ClientId, Clients clients)
        {
            try
            {
                var existingClients = await _dataContext.Clients.FirstOrDefaultAsync(x => x.ClientId == ClientId);

                if (existingClients == null)
                {
                    return null;
                }
                existingClients.ClientName = clients.ClientName;
                existingClients.CurrencyId = clients.CurrencyId;
                existingClients.BillingMethodId = clients.BillingMethodId;
                existingClients.EmailId = clients.EmailId;
                existingClients.FirstName = clients.FirstName;
                existingClients.LastName = clients.LastName;
                existingClients.Phone = clients.Phone;
                existingClients.Mobile = clients.Mobile;
                existingClients.Fax = clients.Fax;
                existingClients.IsDeleted = clients.IsDeleted;
                existingClients.IsActive = clients.IsActive;

                await _dataContext.SaveChangesAsync();

                return existingClients;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update the client.", ex);
            }
            
        }
    }
}
