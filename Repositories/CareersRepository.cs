using Model.Entities;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CareersRepository : ICareersRepository
    {
        SqlConnection sqlConnection = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=EstuLibreta;Trusted_Connection=True;");


        public Career Add(Career career)
        {
            try
            {
                sqlConnection.Open();

                SqlCommand sqlcommand = sqlConnection.CreateCommand();
                sqlcommand.Connection = sqlConnection;
                sqlcommand.CommandText = "Careers_Add";
                sqlcommand.CommandType = CommandType.StoredProcedure;


                //parameters
                SqlParameter name = sqlcommand.CreateParameter();
                name.ParameterName = "name";
                name.SqlDbType = SqlDbType.VarChar;
                name.Value = career.Name;
                name.IsNullable = false;

                SqlParameter resolution = sqlcommand.CreateParameter();
                resolution.ParameterName = "resolution";
                resolution.SqlDbType = SqlDbType.VarChar;
                resolution.Value = career.Resolution;
                resolution.IsNullable = false;

                SqlParameter duration = sqlcommand.CreateParameter();
                duration.ParameterName = "duration";
                duration.SqlDbType = SqlDbType.Int;
                duration.Value = career.Duration;
                duration.IsNullable = false;



                sqlcommand.Parameters.Add(name);
                sqlcommand.Parameters.Add(resolution);
                sqlcommand.Parameters.Add(duration);


                sqlcommand.Prepare();
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                if (sqldatareader.Read())
                {
                    career.CareerId = sqldatareader.GetInt32(0);
                }
                return career;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public bool Delete(int careerId)
        {
            try
            {
                sqlConnection.Open();

                SqlCommand sqlcommand = sqlConnection.CreateCommand();
                sqlcommand.Connection = sqlConnection;
                sqlcommand.CommandText = "Careers_Delete";
                sqlcommand.CommandType = CommandType.StoredProcedure;


                //parameters
                SqlParameter id = sqlcommand.CreateParameter();
                id.ParameterName = "careerId";
                id.SqlDbType = SqlDbType.Int;
                id.Value = careerId;
                id.IsNullable = false;
                
                sqlcommand.Parameters.Add(id);

                sqlcommand.Prepare();


                if (sqlcommand.ExecuteNonQuery() == 1)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public List<Career> GetAll()
        {
            try
            {
                List<Career> careersList = new List<Career>();

                sqlConnection.Open();

                SqlCommand sqlcommand = sqlConnection.CreateCommand();
                sqlcommand.Connection = sqlConnection;
                sqlcommand.CommandText = "Careers_GetAll";
                sqlcommand.CommandType = CommandType.StoredProcedure;

                sqlcommand.Prepare();
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                while (sqldatareader.Read())
                {
                    int resultCareerId = sqldatareader.GetInt32(0);
                    string name = sqldatareader.GetString(1);
                    string resolution = sqldatareader.GetString(2);
                    int duration = sqldatareader.GetInt32(3);

                    Career career = new Career();
                    career.CareerId = resultCareerId;
                    career.Name = name;
                    career.Resolution = resolution;
                    career.Duration = duration;

                    careersList.Add(career);
                }
                sqldatareader.Close();

                return careersList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {

                sqlConnection.Close();
            }
        }

        public Career GetCareerById(int careerId)
        {
            try
            {
                Career career = null;
                sqlConnection.Open();

                SqlCommand sqlcommand = sqlConnection.CreateCommand();
                sqlcommand.Connection = sqlConnection;
                sqlcommand.CommandText = "Careers_GetById";
                sqlcommand.CommandType = CommandType.StoredProcedure;

                SqlParameter paramCareerId = sqlcommand.CreateParameter();
                paramCareerId.ParameterName = "careerId";
                paramCareerId.SqlDbType = SqlDbType.Int;
                paramCareerId.Value = careerId;
                paramCareerId.IsNullable = false;

                sqlcommand.Parameters.Add(paramCareerId);

                sqlcommand.Prepare();

                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                if (sqldatareader.Read())
                {
                    int resultCareerId = sqldatareader.GetInt32(0);
                    string name = sqldatareader.GetString(1);
                    string resolution = sqldatareader.GetString(2);
                    int duration = sqldatareader.GetInt32(3);

                    career = new Career();
                    career.CareerId = resultCareerId;
                    career.Name = name;
                    career.Resolution = resolution;
                    career.Duration = duration;
                }

                sqldatareader.Close();
                return career;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public bool Modify(int careerId, Career career)
        {
            try
            {
                sqlConnection.Open();

                SqlCommand sqlcommand = sqlConnection.CreateCommand();
                sqlcommand.Connection = sqlConnection;
                sqlcommand.CommandText = "Careers_Modify";
                sqlcommand.CommandType = CommandType.StoredProcedure;


                //parameters
                SqlParameter id = sqlcommand.CreateParameter();
                id.ParameterName = "careerId";
                id.SqlDbType = SqlDbType.Int;
                id.Value = careerId;
                id.IsNullable = false;

                SqlParameter name = sqlcommand.CreateParameter();
                name.ParameterName = "name";
                name.SqlDbType = SqlDbType.VarChar;
                name.Value = career.Name;
                name.IsNullable = false;

                SqlParameter resolution = sqlcommand.CreateParameter();
                resolution.ParameterName = "resolution";
                resolution.SqlDbType = SqlDbType.VarChar;
                resolution.Value = career.Resolution;
                resolution.IsNullable = false;

                SqlParameter duration = sqlcommand.CreateParameter();
                duration.ParameterName = "duration";
                duration.SqlDbType = SqlDbType.Int;
                duration.Value = career.Duration;
                duration.IsNullable = false;



                sqlcommand.Parameters.Add(id);
                sqlcommand.Parameters.Add(name);
                sqlcommand.Parameters.Add(resolution);
                sqlcommand.Parameters.Add(duration);

                sqlcommand.Prepare();

                if (sqlcommand.ExecuteNonQuery() == 1)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
