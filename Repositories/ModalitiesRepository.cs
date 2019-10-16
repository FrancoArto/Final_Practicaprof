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
    public class ModalitiesRepository : IModalitiesRepository
    {
        SqlConnection sqlConnection = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=EstuLibreta;Trusted_Connection=True;");


        public Modality Add(Modality modality)
        {
            try
            {
                sqlConnection.Open();

                SqlCommand sqlcommand = sqlConnection.CreateCommand();
                sqlcommand.Connection = sqlConnection;
                sqlcommand.CommandText = "Modalities_Add";
                sqlcommand.CommandType = CommandType.StoredProcedure;


                //parameters
                SqlParameter name = sqlcommand.CreateParameter();
                name.ParameterName = "name";
                name.SqlDbType = SqlDbType.VarChar;
                name.Value = modality.Name;
                name.IsNullable = false;

                SqlParameter description = sqlcommand.CreateParameter();
                description.ParameterName = "description";
                description.SqlDbType = SqlDbType.Int;
                description.Value = modality.Description;
                description.IsNullable = false;

                sqlcommand.Parameters.Add(name);
                sqlcommand.Parameters.Add(description);

                sqlcommand.Prepare();
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                if (sqldatareader.Read())
                {
                    modality.ModalityId = sqldatareader.GetInt32(0);
                }
                return modality;
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

        public bool Delete(int modalityId)
        {
            try
            {
                sqlConnection.Open();

                SqlCommand sqlcommand = sqlConnection.CreateCommand();
                sqlcommand.Connection = sqlConnection;
                sqlcommand.CommandText = "Modalities_Delete";
                sqlcommand.CommandType = CommandType.StoredProcedure;


                //parameters
                SqlParameter id = sqlcommand.CreateParameter();
                id.ParameterName = "modalityId";
                id.SqlDbType = SqlDbType.Int;
                id.Value = modalityId;
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

        public List<Modality> GetAll()
        {
            try
            {
                List<Modality> modalitiesList = new List<Modality>();

                sqlConnection.Open();

                SqlCommand sqlcommand = sqlConnection.CreateCommand();
                sqlcommand.Connection = sqlConnection;
                sqlcommand.CommandText = "Modalities_GetAll";
                sqlcommand.CommandType = CommandType.StoredProcedure;

                sqlcommand.Prepare();
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                while (sqldatareader.Read())
                {
                    int resultModalityId = sqldatareader.GetInt32(0);
                    string name = sqldatareader.GetString(2);
                    string description = sqldatareader.GetString(2);

                    Modality modality = new Modality();
                    modality.ModalityId = resultModalityId;
                    modality.Name = name;
                    modality.Description = description;

                    modalitiesList.Add(modality);
                }
                sqldatareader.Close();

                return modalitiesList;
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

        public bool Modify(int modalityId, Modality modality)
        {
            try
            {
                sqlConnection.Open();

                SqlCommand sqlcommand = sqlConnection.CreateCommand();
                sqlcommand.Connection = sqlConnection;
                sqlcommand.CommandText = "Modalities_Modify";
                sqlcommand.CommandType = CommandType.StoredProcedure;


                //parameters
                SqlParameter id = sqlcommand.CreateParameter();
                id.ParameterName = "ModalityId";
                id.SqlDbType = SqlDbType.Int;
                id.Value = modalityId;
                id.IsNullable = false;

                SqlParameter name = sqlcommand.CreateParameter();
                name.ParameterName = "name";
                name.SqlDbType = SqlDbType.VarChar;
                name.Value = modality.Name;
                name.IsNullable = false;

                SqlParameter description = sqlcommand.CreateParameter();
                description.ParameterName = "description";
                description.SqlDbType = SqlDbType.Int;
                description.Value = modality.Description;
                description.IsNullable = false;

                sqlcommand.Parameters.Add(id);
                sqlcommand.Parameters.Add(name);
                sqlcommand.Parameters.Add(description);

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
