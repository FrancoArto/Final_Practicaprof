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
    public class CouponsRepository : ICouponsRepository
    {
        SqlConnection sqlConnection = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=EstuLibreta;Trusted_Connection=True;");

        public Coupon Add(Coupon coupon)
        {
            try
            {
                sqlConnection.Open();

                SqlCommand sqlcommand = sqlConnection.CreateCommand();
                sqlcommand.Connection = sqlConnection;
                sqlcommand.CommandText = "Coupons_Add";
                sqlcommand.CommandType = CommandType.StoredProcedure;


                //parameters
                SqlParameter QR = sqlcommand.CreateParameter();
                QR.ParameterName = "QR";
                QR.SqlDbType = SqlDbType.VarChar;
                QR.Value = coupon.QR;
                QR.IsNullable = false;

                sqlcommand.Parameters.Add(QR);

                sqlcommand.Prepare();
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                if (sqldatareader.Read())
                {
                    coupon.CouponId = sqldatareader.GetInt32(0);
                }
                return coupon;
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

        public bool Delete(int couponId)
        {
            try
            {
                sqlConnection.Open();

                SqlCommand sqlcommand = sqlConnection.CreateCommand();
                sqlcommand.Connection = sqlConnection;
                sqlcommand.CommandText = "Coupons_Delete";
                sqlcommand.CommandType = CommandType.StoredProcedure;


                //parameters
                SqlParameter id = sqlcommand.CreateParameter();
                id.ParameterName = "couponId";
                id.SqlDbType = SqlDbType.Int;
                id.Value = couponId;
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

        public Coupon GetCouponById(int couponId)
        {
            try
            {
                Coupon coupon = null;
                sqlConnection.Open();

                SqlCommand sqlcommand = sqlConnection.CreateCommand();
                sqlcommand.Connection = sqlConnection;
                sqlcommand.CommandText = "Coupons_GetById";
                sqlcommand.CommandType = CommandType.StoredProcedure;

                SqlParameter id = sqlcommand.CreateParameter();
                id.ParameterName = "couponId";
                id.SqlDbType = SqlDbType.Int;
                id.Value = couponId;
                id.IsNullable = false;

                sqlcommand.Parameters.Add(id);

                sqlcommand.Prepare();

                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                if (sqldatareader.Read())
                {
                    int resultCouponId = sqldatareader.GetInt32(0);
                    string QR = sqldatareader.GetString(1);

                    coupon = new Coupon();
                    coupon.CouponId = resultCouponId;
                    coupon.QR = QR;
                }

                sqldatareader.Close();
                return coupon;
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
