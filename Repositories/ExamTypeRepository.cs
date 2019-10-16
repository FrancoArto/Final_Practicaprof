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
    public class ExamTypeRepository : IExamTypeRepository
    {
        SqlConnection sqlConnection = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=EstuLibreta;Trusted_Connection=True;");


        public ExamType Add(ExamType examType)
        {
            try
            {
                sqlConnection.Open();

                SqlCommand sqlcommand = sqlConnection.CreateCommand();
                sqlcommand.Connection = sqlConnection;
                sqlcommand.CommandText = "ExamTypes_Add";
                sqlcommand.CommandType = CommandType.StoredProcedure;


                //parameters
                SqlParameter name = sqlcommand.CreateParameter();
                name.ParameterName = "name";
                name.SqlDbType = SqlDbType.VarChar;
                name.Value = examType.Name;
                name.IsNullable = false;

                SqlParameter description = sqlcommand.CreateParameter();
                description.ParameterName = "description";
                description.SqlDbType = SqlDbType.Int;
                description.Value = examType.Description;
                description.IsNullable = false;

                sqlcommand.Parameters.Add(name);
                sqlcommand.Parameters.Add(description);

                sqlcommand.Prepare();
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                if (sqldatareader.Read())
                {
                    examType.TypeId = sqldatareader.GetInt32(0);
                }
                return examType;
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

        public bool Delete(int examTypeId)
        {
            try
            {
                sqlConnection.Open();

                SqlCommand sqlcommand = sqlConnection.CreateCommand();
                sqlcommand.Connection = sqlConnection;
                sqlcommand.CommandText = "ExamTypes_Delete";
                sqlcommand.CommandType = CommandType.StoredProcedure;


                //parameters
                SqlParameter id = sqlcommand.CreateParameter();
                id.ParameterName = "examTypeId";
                id.SqlDbType = SqlDbType.Int;
                id.Value = examTypeId;
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

        public List<ExamType> GetAll()
        {
            try
            {
                List<ExamType> examTypesList = new List<ExamType>();

                sqlConnection.Open();

                SqlCommand sqlcommand = sqlConnection.CreateCommand();
                sqlcommand.Connection = sqlConnection;
                sqlcommand.CommandText = "ExamTypes_GetAll";
                sqlcommand.CommandType = CommandType.StoredProcedure;

                sqlcommand.Prepare();
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                while (sqldatareader.Read())
                {
                    int resultExamTypeId = sqldatareader.GetInt32(0);
                    string name = sqldatareader.GetString(2);
                    string description = sqldatareader.GetString(2);

                    ExamType examType = new ExamType();
                    examType.TypeId = resultExamTypeId;
                    examType.Name = name;
                    examType.Description = description;

                    examTypesList.Add(examType);
                }
                sqldatareader.Close();

                return examTypesList;
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

        public bool Modify(int examTypeId, ExamType examType)
        {
            try
            {
                sqlConnection.Open();

                SqlCommand sqlcommand = sqlConnection.CreateCommand();
                sqlcommand.Connection = sqlConnection;
                sqlcommand.CommandText = "ExamTypes_Modify";
                sqlcommand.CommandType = CommandType.StoredProcedure;


                //parameters
                SqlParameter id = sqlcommand.CreateParameter();
                id.ParameterName = "examTypeId";
                id.SqlDbType = SqlDbType.Int;
                id.Value = examTypeId;
                id.IsNullable = false;

                SqlParameter name = sqlcommand.CreateParameter();
                name.ParameterName = "name";
                name.SqlDbType = SqlDbType.VarChar;
                name.Value = examType.Name;
                name.IsNullable = false;

                SqlParameter description = sqlcommand.CreateParameter();
                description.ParameterName = "description";
                description.SqlDbType = SqlDbType.Int;
                description.Value = examType.Description;
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
