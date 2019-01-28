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
                SqlParameter careerId = sqlcommand.CreateParameter();
                careerId.ParameterName = "careerId";
                careerId.SqlDbType = SqlDbType.Int;
                careerId.Value = career.CareerId;
                careerId.IsNullable = false;

                SqlParameter tourismPackageId = sqlcommand.CreateParameter();
                tourismPackageId.ParameterName = "tourismPackageId";
                tourismPackageId.SqlDbType = SqlDbType.Int;
                tourismPackageId.Value = booking.TourismPackageId;
                tourismPackageId.IsNullable = false;

                SqlParameter bookingDate = sqlcommand.CreateParameter();
                bookingDate.ParameterName = "bookingDate";
                bookingDate.SqlDbType = SqlDbType.Date;
                bookingDate.Value = booking.BookingDate;
                bookingDate.IsNullable = false;



                sqlcommand.Parameters.Add(clientId);
                sqlcommand.Parameters.Add(tourismPackageId);
                sqlcommand.Parameters.Add(bookingDate);


                sqlcommand.Prepare();
                sqlcommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }

        public bool Delete(int careerId)
        {
            throw new NotImplementedException();
        }

        public List<Career> GetAll()
        {
            throw new NotImplementedException();
        }

        public Career GetCareerById(int careerId)
        {
            throw new NotImplementedException();
        }

        public Career Modify(int careerId, Career career)
        {
            throw new NotImplementedException();
        }
    }
}
