using Dapper;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
  public  class EmployeeRepository
    {
        public readonly string connectionString;



        public EmployeeRepository()
        {
            connectionString = @"Data source=DESKTOP-18UQSSV;Initial catalog=EmployeeDatabase;User Id=sa;Password=Anaiyaan@123";
        }

        public void InsertEmployeeData(EmployeeModel emp)
        {

            try
            {
                SqlConnection con = new SqlConnection(connectionString);

                con.Open();
                con.Execute($" exec insertemployee '{emp.Name}', '{emp.DateOfBirth}','{emp.Experience}','{emp.Phonenumber}','{emp.EmailAddress}'");

                con.Close();

            }
            catch (SqlException ex)
            {
                throw;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public EmployeeModel GetEmployeeDataById(int id)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                var Employee = con.QueryFirst<EmployeeModel>($" exec selectemployeebyID {id} ");
                con.Close();



                return Employee;


            }

            catch (SqlException er)
            {
                throw;
            }
            catch (Exception r)
            {
                throw r;
            }
        }

        public List<EmployeeModel> GetEmployeeData()
        {
            try
            {
                List<EmployeeModel> constrain = new List<EmployeeModel>();

                var connection = new SqlConnection(connectionString);
                connection.Open();
                constrain = connection.Query<EmployeeModel>($" exec selectemployee").ToList();
                connection.Close();

                return constrain;


            }

            catch (SqlException er)
            {
                throw;
            }
            catch (Exception r)
            {
                throw r;
            }
        }

        public void UpdateEmployeeData(EmployeeModel emp)
        {
            try
            {

                SqlConnection con = new SqlConnection(connectionString);

                con.Open();
                con.Execute($" exec Updateemployee '{emp.Name}', '{emp.DateOfBirth}','{emp.Experience}','{emp.Phonenumber}','{emp.EmailAddress}',{emp.Empid}");
                con.Close();
            }
            catch (SqlException )
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void DeleteEmployeeData(int id)
        {
            try
            {


                SqlConnection con = new SqlConnection(connectionString);

                con.Open();
                con.Execute($"  exec DeleteEmployee { id}");

                con.Close();

            }
            catch (SqlException ed)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
