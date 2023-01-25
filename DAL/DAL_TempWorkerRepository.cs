using EksamenFinish.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Windows;

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

        public void CreateTempWorker(M_TempWorker worker)
        {
            using (var command = _connection.CreateCommand())
            {
                //_connection.Open();

                command.CommandText = "INSERT INTO TempWorker (Id, FirstName, LastName, Address, City, ZipCode, PersonalNumber, IsActive) " +
                    "VALUES (@Id, @FirstName, @LastName, @Address, @City, @ZipCode, @PersonalNumber, @IsActive)";
                command.Parameters.Add(new SqlParameter("@Id", Guid.NewGuid()));
                command.Parameters.Add(new SqlParameter("@FirstName", worker.FirstName));
                command.Parameters.Add(new SqlParameter("@LastName", worker.LastName));
                command.Parameters.Add(new SqlParameter("@Address", worker.Address));
                command.Parameters.Add(new SqlParameter("@City", worker.City));
                command.Parameters.Add(new SqlParameter("@ZipCode", worker.ZipCode));
                command.Parameters.Add(new SqlParameter("@PersonalNumber", worker.PersonalNumber));
                command.Parameters.Add(new SqlParameter("@IsActive", worker.IsActive));
                command.ExecuteNonQuery();
                MessageBox.Show($"Success. {worker.FirstName} {worker.LastName} \n {worker.Address} {worker.City} \n {worker.ZipCode} {worker.PersonalNumber} \n {worker.IsActive} is added to the database");
            }
        }

        #endregion CreateTempWorker

        #region SearchTempWorkers

        /// <summary>
        ///  It uses the properties of the passed in M_TempWorker object to build a query and then uses SqlCommand and SqlDataReader to execute the query and read the results.
        ///  It then returns the list of matching M_TempWorker
        /// </summary>

        public List<M_TempWorker> SearchTempWorkers(M_TempWorker tempWorker)
        {
            using (DbCommand command = _connection.CreateCommand())
            {
                //_connection.Open();

                var workers = new List<M_TempWorker>();
                command.Connection = _connection;

                // Start building the query
                var query = "SELECT * FROM TempWorker WHERE 1=1";

                if (!string.IsNullOrEmpty(tempWorker.FirstName))
                {
                    query += " AND FirstName = @FirstName";
                    command.Parameters.Add(new SqlParameter("@FirstName", tempWorker.FirstName));
                }

                if (!string.IsNullOrEmpty(tempWorker.LastName))
                {
                    query += " AND LastName = @LastName";
                    command.Parameters.Add(new SqlParameter("@LastName", tempWorker.LastName));
                }

                if (!string.IsNullOrEmpty(tempWorker.City))
                {
                    query += " AND City = @City";
                    command.Parameters.Add(new SqlParameter("@City", tempWorker.City));
                }

                if (tempWorker.ZipCode != 0)
                {
                    query += " AND ZipCode = @ZipCode";
                    command.Parameters.Add(new SqlParameter("@ZipCode", tempWorker.ZipCode));
                }

                if (!string.IsNullOrEmpty(tempWorker.PersonalNumber))
                {
                    query += " AND PersonalNumber = @PersonalNumber";
                    command.Parameters.Add(new SqlParameter("@PersonalNumber", tempWorker.PersonalNumber));
                }

                if (tempWorker.IsActive != null)
                {
                    query += " AND IsActive = @IsActive";
                    command.Parameters.Add(new SqlParameter("@IsActive", tempWorker.IsActive));
                }

                command.CommandText = query;
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        workers.Add(new M_TempWorker
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
                return workers;
            }
        }

        #endregion SearchTempWorkers

        #region UpdateWorker

        public void UpdateWorker(M_TempWorker worker)
        {
            try
            {
                using (DbCommand command = _connection.CreateCommand())
                {
                    command.CommandText = "UPDATE TempWorkers SET FirstName = @FirstName, LastName = @LastName, @Address, @City, @ZipCode, @PersonalNumber, IsActive = @IsActive WHERE Id = @Id";
                    command.Parameters.Add(new SqlParameter("@FirstName", worker.FirstName));
                    command.Parameters.Add(new SqlParameter("@LastName", worker.LastName));
                    command.Parameters.Add(new SqlParameter("@LastName", worker.Address));
                    command.Parameters.Add(new SqlParameter("@LastName", worker.City));
                    command.Parameters.Add(new SqlParameter("@LastName", worker.ZipCode));
                    command.Parameters.Add(new SqlParameter("@LastName", worker.PersonalNumber));
                    command.Parameters.Add(new SqlParameter("@IsActive", worker.IsActive));
                    // Id should not be changed:
                    command.Parameters.Add(new SqlParameter("@Id", worker.Id));
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        #endregion UpdateWorker

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