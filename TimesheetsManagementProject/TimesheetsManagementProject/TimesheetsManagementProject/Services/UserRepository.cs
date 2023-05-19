using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using TimesheetsManagementProject.Data;
using TimesheetsManagementProject.Models.Domain;
using Microsoft.Extensions.Configuration;
using Dapper;
using TimesheetsManagementProject.Repositories;

namespace TimesheetsManagementProject.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;
        private readonly IConfiguration _configuration;
        public UserRepository(DataContext dataContext, IConfiguration configuration)
        {
            _dataContext = dataContext;
            _configuration = configuration;
        }

        public async Task<List<UsersResponse>> GetUsers()
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DataConnectionStrings")))
            {
                var query = $@"
                        SELECT 
                             u.UserId
                            ,u.UserRoleId
                            ,u.DesignationId
                            ,u.EmpId
                            ,u.FirstName
                            ,u.LastName
                            ,u.FullName
                            ,u.EmailId
                            ,u.PhoneNumber
                            ,u.IsActive
                            ,u.IsDeleted
                            ,u.CreatedDate
                            ,u.CreatedBy
                            ,u.UpdatedDate
                            ,u.UpdatedBy
                           
                        FROM users u
                        WHERE u.IsDeleted = 0
                        ORDER BY u.Name
                            
                    ";

                return (await connection.QueryAsync<UsersResponse>(query).ConfigureAwait(false)).ToList();
            }
        }

        public async Task<Users> SaveUsers(Users users)
        {
            await _dataContext.Users.AddAsync(users);
            await _dataContext.SaveChangesAsync();
            return users;
        }

        public async Task<UserRoles> SaveUserRoles(UserRoles userRoles)
        {
            await _dataContext.UserRoles.AddAsync(userRoles);
            await _dataContext.SaveChangesAsync();
            return userRoles;
        }
    }
}
