using AddressBookAppAPI.CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBookAppAPI.RepositoryLayer
{
    public class AddressBookAppAPIRL : IAddressBookAppAPIRL
    {
        public readonly IConfiguration _configuration;
        public readonly SqlConnection _sqlConnection;
        public AddressBookAppAPIRL(IConfiguration configuration)
        {
            _configuration = configuration;
            _sqlConnection = new SqlConnection(_configuration["ConnectionStrings:DBSettingConnection"]);
        }
            public async Task<AddUserResponse> AddUser(AddUserRequest request)
        {
            AddUserResponse response = new AddUserResponse
            {
                IsSuccess = true,
                Message = "Successful"
            };
            try
            {
                string sqlQuery = "insert into AddressBookAppAPITable (FirstName, LastName, Age) values (@FirstName, @LastName, @Age)";
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, _sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue("@FirstName", request.FirstName);
                    sqlCommand.Parameters.AddWithValue("@LastName", request.LastName);
                    sqlCommand.Parameters.AddWithValue("@Age", request.Age);
                    _sqlConnection.Open();
                    int status = await sqlCommand.ExecuteNonQueryAsync();
                    if(status <= 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Unsuccessful";
                    }
                }

            } catch(Exception e)
            {
                response.IsSuccess = false;
                response.Message = e.Message;
            }
            finally
            {
                _sqlConnection.Close();
            }
            return response;
        }

        public async Task<DeleteUserResponse> DeleteUser(DeleteUserRequest request)
        {
            DeleteUserResponse response = new DeleteUserResponse();
            response.IsSuccess = true;
            response.Message = "Successful";
            try
            {
                string sqlQuery = "Delete from AddressBookAppAPITable WHERE Id=@Id";
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, _sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue("@Id", request.Id);
                    _sqlConnection.Open();
                    int status = await sqlCommand.ExecuteNonQueryAsync();
                    if(status <=0 )
                    {
                        response.IsSuccess = false;
                        response.Message = "Unsuccessful";
                    }
                }
             }
            catch(Exception e)
            {
                response.IsSuccess = false;
                response.Message = e.Message;
            }
            finally
            {
                _sqlConnection.Close();
            }
            return response;
        }

        public async Task<GetAllUsersResponse> GetAllUsers()
        {
            GetAllUsersResponse response = new GetAllUsersResponse();
            response.IsSuccess = true;
            response.Message = "Successful";
            try
            {
                string sqlQuery = "select FirstName, LastName, Age from AddressBookAppAPITable";
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, _sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    _sqlConnection.Open();
                    using(SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync())
                    {
                        if(sqlDataReader.HasRows)
                        {
                            response.getAllUsersData = new List<GetAllUsersData>();
                            while(await sqlDataReader.ReadAsync())
                            {
                                GetAllUsersData dbData = new GetAllUsersData();
                                dbData.FirstName = sqlDataReader["FirstName"] != DBNull.Value ? sqlDataReader["FirstName"].ToString() : string.Empty;
                                dbData.LastName = sqlDataReader["LastName"] != DBNull.Value ? sqlDataReader["LastName"].ToString() : string.Empty;
                                dbData.Age = sqlDataReader["Age"] != DBNull.Value ? Convert.ToInt32(sqlDataReader["Age"]) : 0;
                                response.getAllUsersData.Add(dbData);
                            }
                        }
                    }
                }
            } catch(Exception e)
            {
                response.IsSuccess = false;
                response.Message = e.Message;
            }
            finally
            {
                _sqlConnection.Close();
            }
            return response;
        }

        public async Task<UpdateUserResponse> UpdateUser(UpdateUserRequest request)
        {
            UpdateUserResponse response = new UpdateUserResponse();
            response.IsSuccess = true;
            response.Message = "Successful";
            try
            {
                string sqlQuery = "update AddressBookAppAPITable set FirstName = @FirstName, LastName = @LastName, Age = @Age where Id = @Id";
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, _sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue("@FirstName", request.FirstName);
                    sqlCommand.Parameters.AddWithValue("@LastName", request.LastName);
                    sqlCommand.Parameters.AddWithValue("@Age", request.Age);
                    sqlCommand.Parameters.AddWithValue("@Id", request.Id);
                    _sqlConnection.Open();
                    int status = await sqlCommand.ExecuteNonQueryAsync();
                    if(status <=0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Unsuccessful";
                    }
                }
            }
            catch (Exception e)
            {
                response.IsSuccess = false;
                response.Message = e.Message;
            }
            finally
            {
                _sqlConnection.Close();
            }
            return response;
        }
    }
}
