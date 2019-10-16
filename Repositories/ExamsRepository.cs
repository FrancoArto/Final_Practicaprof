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
    public class ExamsRepository : IExamsRepository
    {
        SqlConnection sqlConnection = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=EstuLibreta;Trusted_Connection=True;");


        public Exam Add(Exam exam)
        {
            try
            {
                sqlConnection.Open();

                SqlCommand sqlcommand = sqlConnection.CreateCommand();
                sqlcommand.Connection = sqlConnection;
                sqlcommand.CommandText = "Exams_Add";
                sqlcommand.CommandType = CommandType.StoredProcedure;


                //parameters
                SqlParameter examDate = sqlcommand.CreateParameter();
                examDate.ParameterName = "examDate";
                examDate.SqlDbType = SqlDbType.Date;
                examDate.Value = exam.Date;
                examDate.IsNullable = false;

                SqlParameter grade = sqlcommand.CreateParameter();
                grade.ParameterName = "grade";
                grade.SqlDbType = SqlDbType.Int;
                grade.Value = exam.Grade;
                grade.IsNullable = false;

                SqlParameter description = sqlcommand.CreateParameter();
                description.ParameterName = "description";
                description.SqlDbType = SqlDbType.VarChar;
                description.Value = exam.Description;
                description.IsNullable = true;

                SqlParameter typeId = sqlcommand.CreateParameter();
                typeId.ParameterName = "typeId";
                typeId.SqlDbType = SqlDbType.Int;
                typeId.Value = exam.TypeId;
                typeId.IsNullable = false;

                SqlParameter subjectId = sqlcommand.CreateParameter();
                subjectId.ParameterName = "subjectId";
                subjectId.SqlDbType = SqlDbType.Int;
                subjectId.Value = exam.SubjectId;
                subjectId.IsNullable = false;

                SqlParameter studentId = sqlcommand.CreateParameter();
                studentId.ParameterName = "studentId";
                studentId.SqlDbType = SqlDbType.Int;
                studentId.Value = exam.StudentId;
                studentId.IsNullable = false;

                SqlParameter staffId = sqlcommand.CreateParameter();
                staffId.ParameterName = "staffId";
                staffId.SqlDbType = SqlDbType.Int;
                staffId.Value = exam.StaffId;
                staffId.IsNullable = false;

                SqlParameter couponId = sqlcommand.CreateParameter();
                couponId.ParameterName = "couponId";
                couponId.SqlDbType = SqlDbType.Int;
                couponId.Value = exam.CouponId;
                couponId.IsNullable = false;



                sqlcommand.Parameters.Add(examDate);
                sqlcommand.Parameters.Add(grade);
                sqlcommand.Parameters.Add(description);
                sqlcommand.Parameters.Add(typeId);
                sqlcommand.Parameters.Add(subjectId);
                sqlcommand.Parameters.Add(studentId);
                sqlcommand.Parameters.Add(staffId);
                sqlcommand.Parameters.Add(couponId);


                sqlcommand.Prepare();
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                if (sqldatareader.Read())
                {
                    exam.ExamId = sqldatareader.GetInt32(0);
                }
                return exam;
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

        public bool Delete(int examId)
        {
            try
            {
                sqlConnection.Open();

                SqlCommand sqlcommand = sqlConnection.CreateCommand();
                sqlcommand.Connection = sqlConnection;
                sqlcommand.CommandText = "Exams_Delete";
                sqlcommand.CommandType = CommandType.StoredProcedure;


                //parameters
                SqlParameter id = sqlcommand.CreateParameter();
                id.ParameterName = "examId";
                id.SqlDbType = SqlDbType.Int;
                id.Value = examId;
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

        public List<Exam> GetAll()
        {
            try
            {
                List<Exam> examsList = new List<Exam>();

                sqlConnection.Open();

                SqlCommand sqlcommand = sqlConnection.CreateCommand();
                sqlcommand.Connection = sqlConnection;
                sqlcommand.CommandText = "Exams_GetAll";
                sqlcommand.CommandType = CommandType.StoredProcedure;

                sqlcommand.Prepare();
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                while (sqldatareader.Read())
                {
                    int resultExamId = sqldatareader.GetInt32(0);
                    DateTime date = sqldatareader.GetDateTime(1);
                    string description = sqldatareader.GetString(2);
                    int typeId = sqldatareader.GetInt32(3);
                    int subjectId = sqldatareader.GetInt32(4);
                    int studentId = sqldatareader.GetInt32(5);
                    int staffId = sqldatareader.GetInt32(6);
                    int couponId = sqldatareader.GetInt32(7);

                    Exam exam = new Exam();
                    exam.ExamId = resultExamId;
                    exam.Date = date;
                    exam.Description = description;
                    exam.TypeId = typeId;
                    exam.SubjectId = subjectId;
                    exam.StudentId = studentId;
                    exam.StaffId = staffId;
                    exam.CouponId = couponId;

                    examsList.Add(exam);
                }
                sqldatareader.Close();

                return examsList;
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

        public Exam GetExamById(int examId)
        {
            try
            {
                Exam exam = null;
                sqlConnection.Open();

                SqlCommand sqlcommand = sqlConnection.CreateCommand();
                sqlcommand.Connection = sqlConnection;
                sqlcommand.CommandText = "Exams_GetById";
                sqlcommand.CommandType = CommandType.StoredProcedure;

                SqlParameter paramExamId = sqlcommand.CreateParameter();
                paramExamId.ParameterName = "examId";
                paramExamId.SqlDbType = SqlDbType.Int;
                paramExamId.Value = examId;
                paramExamId.IsNullable = false;

                sqlcommand.Parameters.Add(paramExamId);

                sqlcommand.Prepare();

                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                if (sqldatareader.Read())
                {
                    int resultExamId = sqldatareader.GetInt32(0);
                    DateTime date = sqldatareader.GetDateTime(1);
                    string description = sqldatareader.GetString(2);
                    int typeId = sqldatareader.GetInt32(3);
                    int subjectId = sqldatareader.GetInt32(4);
                    int studentId = sqldatareader.GetInt32(5);
                    int staffId = sqldatareader.GetInt32(6);
                    int couponId = sqldatareader.GetInt32(7);

                    exam = new Exam();
                    exam.ExamId = resultExamId;
                    exam.Date = date;
                    exam.Description = description;
                    exam.TypeId = typeId;
                    exam.SubjectId = subjectId;
                    exam.StudentId = studentId;
                    exam.StaffId = staffId;
                    exam.CouponId = couponId;
                }

                sqldatareader.Close();
                return exam;
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

        public List<Exam> GetExamsByStudentId(int studentId)
        {
            try
            {
                List<Exam> examsList = new List<Exam>();

                sqlConnection.Open();

                SqlCommand sqlcommand = sqlConnection.CreateCommand();
                sqlcommand.Connection = sqlConnection;
                sqlcommand.CommandText = "Exams_GetByStudentId";
                sqlcommand.CommandType = CommandType.StoredProcedure;

                SqlParameter paramStutendId = sqlcommand.CreateParameter();
                paramStutendId.ParameterName = "examId";
                paramStutendId.SqlDbType = SqlDbType.Int;
                paramStutendId.Value = studentId;
                paramStutendId.IsNullable = false;

                sqlcommand.Parameters.Add(paramStutendId);

                sqlcommand.Prepare();
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();

                while (sqldatareader.Read())
                {
                    int resultExamId = sqldatareader.GetInt32(0);
                    DateTime date = sqldatareader.GetDateTime(1);
                    string description = sqldatareader.GetString(2);
                    int typeId = sqldatareader.GetInt32(3);
                    int subjectId = sqldatareader.GetInt32(4);
                    int resultStudentId = sqldatareader.GetInt32(5);
                    int staffId = sqldatareader.GetInt32(6);
                    int couponId = sqldatareader.GetInt32(7);

                    Exam exam = new Exam();
                    exam.ExamId = resultExamId;
                    exam.Date = date;
                    exam.Description = description;
                    exam.TypeId = typeId;
                    exam.SubjectId = subjectId;
                    exam.StudentId = studentId;
                    exam.StaffId = staffId;
                    exam.CouponId = couponId;

                    examsList.Add(exam);
                }
                sqldatareader.Close();

                return examsList;
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

        public bool Modify(int examId, Exam exam)
        {
            try
            {
                sqlConnection.Open();

                SqlCommand sqlcommand = sqlConnection.CreateCommand();
                sqlcommand.Connection = sqlConnection;
                sqlcommand.CommandText = "Exams_Modify";
                sqlcommand.CommandType = CommandType.StoredProcedure;


                //parameters
                SqlParameter id = sqlcommand.CreateParameter();
                id.ParameterName = "examId";
                id.SqlDbType = SqlDbType.Int;
                id.Value = examId;
                id.IsNullable = false;

                SqlParameter examDate = sqlcommand.CreateParameter();
                examDate.ParameterName = "examDate";
                examDate.SqlDbType = SqlDbType.Date;
                examDate.Value = exam.Date;
                examDate.IsNullable = false;

                SqlParameter grade = sqlcommand.CreateParameter();
                grade.ParameterName = "grade";
                grade.SqlDbType = SqlDbType.Int;
                grade.Value = exam.Grade;
                grade.IsNullable = false;

                SqlParameter description = sqlcommand.CreateParameter();
                description.ParameterName = "description";
                description.SqlDbType = SqlDbType.VarChar;
                description.Value = exam.Description;
                description.IsNullable = true;

                SqlParameter typeId = sqlcommand.CreateParameter();
                typeId.ParameterName = "typeId";
                typeId.SqlDbType = SqlDbType.Int;
                typeId.Value = exam.TypeId;
                typeId.IsNullable = false;

                SqlParameter subjectId = sqlcommand.CreateParameter();
                subjectId.ParameterName = "subjectId";
                subjectId.SqlDbType = SqlDbType.Int;
                subjectId.Value = exam.SubjectId;
                subjectId.IsNullable = false;

                SqlParameter studentId = sqlcommand.CreateParameter();
                studentId.ParameterName = "studentId";
                studentId.SqlDbType = SqlDbType.Int;
                studentId.Value = exam.StudentId;
                studentId.IsNullable = false;

                SqlParameter staffId = sqlcommand.CreateParameter();
                staffId.ParameterName = "staffId";
                staffId.SqlDbType = SqlDbType.Int;
                staffId.Value = exam.StaffId;
                staffId.IsNullable = false;

                SqlParameter couponId = sqlcommand.CreateParameter();
                couponId.ParameterName = "couponId";
                couponId.SqlDbType = SqlDbType.Int;
                couponId.Value = exam.CouponId;
                couponId.IsNullable = false;



                sqlcommand.Parameters.Add(id);
                sqlcommand.Parameters.Add(examDate);
                sqlcommand.Parameters.Add(grade);
                sqlcommand.Parameters.Add(description);
                sqlcommand.Parameters.Add(typeId);
                sqlcommand.Parameters.Add(subjectId);
                sqlcommand.Parameters.Add(studentId);
                sqlcommand.Parameters.Add(staffId);
                sqlcommand.Parameters.Add(couponId);

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
