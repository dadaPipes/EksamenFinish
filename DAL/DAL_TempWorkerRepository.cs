using EksamenFinish.Services;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace EksamenFinish.DAL
{
    public class DAL_TempWorkerRepository : IDisposable, IDAL_TempWorker
    {
        private DbConnection _connection;

        public DAL_TempWorkerRepository()
        {
            DAL_DatabaseConnection dbConnection = new DAL_DatabaseConnection();
            string connectionString = dbConnection.GetConnectionString();
            _connection = new SqlConnection(connectionString);
            _connection.Open();
        }

        #region CreateTempWorker

        public void CreateTempWorker(DTO_TempWorker dto_tempWorker)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO TempWorker (Id, FirstName, LastName, Address, City, ZipCode, PersonalNumber, IsActive) " +
                    "VALUES (@Id, @FirstName, @LastName, @Address, @City, @ZipCode, @PersonalNumber, @IsActive)";
                command.Parameters.Add(new SqlParameter("@Id", Guid.NewGuid()));
                command.Parameters.Add(new SqlParameter("@FirstName", dto_tempWorker.FirstName));
                command.Parameters.Add(new SqlParameter("@LastName", dto_tempWorker.LastName));
                command.Parameters.Add(new SqlParameter("@Address", dto_tempWorker.Address));
                command.Parameters.Add(new SqlParameter("@City", dto_tempWorker.City));
                command.Parameters.Add(new SqlParameter("@ZipCode", dto_tempWorker.ZipCode));
                command.Parameters.Add(new SqlParameter("@PersonalNumber", dto_tempWorker.PersonalNumber));
                command.Parameters.Add(new SqlParameter("@IsActive", dto_tempWorker.IsActive));
                command.ExecuteNonQuery();
            }
        }

        #endregion CreateTempWorker

        #region SearchTempWorkers

        public List<DTO_TempWorker> SearchTempWorkers(DTO_TempWorker dto_tempWorker)
        {
            var dto_tempWorkers = new List<DTO_TempWorker>();
            using (DbCommand command = _connection.CreateCommand())
            {
                
                command.Connection = _connection;

                // Start building the query
                var query = "SELECT * FROM TempWorker WHERE 1=1";

                if (!string.IsNullOrEmpty(dto_tempWorker.FirstName))
                {
                    query += " AND FirstName = @FirstName";
                    command.Parameters.Add(new SqlParameter("@FirstName", dto_tempWorker.FirstName));
                }

                if (!string.IsNullOrEmpty(dto_tempWorker.LastName))
                {
                    query += " AND LastName = @LastName";
                    command.Parameters.Add(new SqlParameter("@LastName", dto_tempWorker.LastName));
                }

                if (!string.IsNullOrEmpty(dto_tempWorker.City))
                {
                    query += " AND City = @City";
                    command.Parameters.Add(new SqlParameter("@City", dto_tempWorker.City));
                }

                if (dto_tempWorker.ZipCode != 0)
                {
                    query += " AND ZipCode = @ZipCode";
                    command.Parameters.Add(new SqlParameter("@ZipCode", dto_tempWorker.ZipCode));
                }

                if (!string.IsNullOrEmpty(dto_tempWorker.PersonalNumber))
                {
                    query += " AND PersonalNumber = @PersonalNumber";
                    command.Parameters.Add(new SqlParameter("@PersonalNumber", dto_tempWorker.PersonalNumber));
                }

                if (dto_tempWorker.IsActive != null)
                {
                    query += " AND IsActive = @IsActive";
                    command.Parameters.Add(new SqlParameter("@IsActive", dto_tempWorker.IsActive));
                }

                command.CommandText = query;
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dto_tempWorkers.Add(new DTO_TempWorker
                        {
                            Id = (Guid)reader["Id"],
                            FirstName = (string)reader["FirstName"],
                            LastName = (string)reader["LastName"],
                            Address = (string)reader["Address"],
                            City = (string)reader["City"],
                            ZipCode = (int)reader["ZipCode"],
                            PersonalNumber = (string)reader["PersonalNumber"],
                            IsActive = (bool)reader["IsActive"],
                        });
                    }
                }
                
            }
            return dto_tempWorkers;
        }

        #endregion SearchTempWorkers

        #region UpdateWorker

        public void UpdateWorker(DTO_TempWorker dto_tempWorker)
        {
            try
            {
                using (DbCommand command = _connection.CreateCommand())
                {
                    command.CommandText = "UPDATE TempWorkers SET FirstName = @FirstName, LastName = @LastName, Address = @Address, City = @City, ZipCode = @ZipCode, PersonalNumber = @PersonalNumber, IsActive = @IsActive WHERE Id = @Id";
                    command.Parameters.Add(new SqlParameter("@FirstName", dto_tempWorker.FirstName));
                    command.Parameters.Add(new SqlParameter("@LastName", dto_tempWorker.LastName));
                    command.Parameters.Add(new SqlParameter("@Address", dto_tempWorker.Address));
                    command.Parameters.Add(new SqlParameter("@City", dto_tempWorker.City));
                    command.Parameters.Add(new SqlParameter("@ZipCode", dto_tempWorker.ZipCode));
                    command.Parameters.Add(new SqlParameter("@PersonalNumber", dto_tempWorker.PersonalNumber));
                    command.Parameters.Add(new SqlParameter("@IsActive", dto_tempWorker.IsActive));
                    // Id should not be changed:
                    command.Parameters.Add(new SqlParameter("@Id", dto_tempWorker.Id));
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        #endregion UpdateWorker

        #region DeleteTempWorker
        public void DeleteTempWorker(Guid id)
        {
            try
            {
                using (DbCommand command = _connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM TempWorkers WHERE Id = @Id";
                    command.Parameters.Add(new SqlParameter("@Id", id));
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        #endregion

        #region Helper Exeption

        private void HandleException(Exception ex)
        {
            // Log the exception
            // Send an email or notification to the administrator
            // Show a message to the user
            // etc.
        }

        #endregion Helper Exeption

        #region Helper Dispose

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (_connection != null)
            {
                _connection.Close();
                _connection.Dispose();
            }
        }

        #endregion Helper Dispose
    }
}