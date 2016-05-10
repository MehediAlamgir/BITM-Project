using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityMS.Models;

namespace UniversityMS.DAL
{
    public class DepartmentGateway:ConnectionString
    {
        public int SaveDepartment(Department aDepartment)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "INSERT INTO Departments(DeptCode,DeptName) VALUES(@DeptCode,@DeptName)";
            SqlCommand command = new SqlCommand(query,connection);

            command.Parameters.Clear();

            command.Parameters.Add("DeptCode", SqlDbType.NVarChar);
            command.Parameters["DeptCode"].Value = aDepartment.DeptCode;

            command.Parameters.Add("DeptName", SqlDbType.NVarChar);
            command.Parameters["DeptName"].Value = aDepartment.DeptName;

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowAffected;
        }

        public bool IsDepartmentCodeExist(string DeptCode)
        {
            bool isDeptCodeExists = false;

            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT DeptCode FROM Departments WHERE DeptCode= @DeptCode ";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Clear();

            command.Parameters.Add("DeptCode", SqlDbType.NVarChar);
            command.Parameters["DeptCode"].Value = DeptCode;


            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                isDeptCodeExists = true;
            }
            connection.Close();

            return isDeptCodeExists;
        }

        

        public bool IsDepartmentNameExist(string DeptName)
        {
            bool isDeptNameExists = false;

            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT DeptName FROM Departments WHERE DeptName= @DeptName ";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Clear();

            command.Parameters.Add("DeptName", SqlDbType.NVarChar);
            command.Parameters["DeptName"].Value = DeptName;


            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                isDeptNameExists = true;
            }
            connection.Close();

            return isDeptNameExists;
        }

        public List<Department> GetAllDepartment()
        {
            List<Department> departments = new List<Department>();
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT * FROM Departments";
            SqlCommand command = new SqlCommand(query, connection);




            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string DeptCode = reader["DeptCode"].ToString();
                string DeptName = reader["DeptName"].ToString();

                Department aDepartment = new Department();
                aDepartment.DeptCode = DeptCode;
                aDepartment.DeptName = DeptName;
                departments.Add(aDepartment);



            }
            connection.Close();


            return departments;
        }
    }
}