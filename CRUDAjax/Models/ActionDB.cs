using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CRUDAjax.Models
{
    public class ActionDB
    {
        //declare connection string
        string connStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        //Return list of all Employees
        public List<Employee> ListAllEmp()
        {
            List<Employee> lst = new List<Employee>();
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SP_Employee", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ActionType", "list");
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    lst.Add(new Employee
                    {
                        ID = Convert.ToInt64(rdr["ID"]),
                        EmployeeName = rdr["EmployeeName"].ToString(),
                        PhoneNumber = Convert.ToInt64(rdr["PhoneNumber"]),
                        Address = rdr["Address"].ToString(),
                        Designation = rdr["Designation"].ToString(),
                        Gender = rdr["Gender"].ToString(),
                        ManagerName = rdr["ManagerName"].ToString(),
                        ManagerID = Convert.ToInt64(rdr["ManagerID"]),
                    });
                }
                return lst;
            }
        }


        //Method for Adding an Employee  
        public int AddEmployee(Employee emp)
        {
            int i;
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SP_Employee", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@EmployeeName", emp.EmployeeName);
                com.Parameters.AddWithValue("@PhoneNumber", emp.PhoneNumber);
                com.Parameters.AddWithValue("@Address", emp.Address);
                com.Parameters.AddWithValue("@Gender", emp.Gender);
                com.Parameters.AddWithValue("@Designation", emp.Designation);
                com.Parameters.AddWithValue("@ManagerID", emp.ManagerID);
                com.Parameters.AddWithValue("@ActionType", "insert");
                i = com.ExecuteNonQuery();
            }
            return i;
        }

        //Method for Updating Employee record  
        public int UpdateEmployee(Employee emp)
        {
            int i;
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SP_Employee", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@EmployeeName", emp.EmployeeName);
                com.Parameters.AddWithValue("@PhoneNumber", emp.PhoneNumber);
                com.Parameters.AddWithValue("@Address", emp.Address);
                com.Parameters.AddWithValue("@Gender", emp.Gender);
                com.Parameters.AddWithValue("@Designation", emp.Designation);
                com.Parameters.AddWithValue("@ManagerID", emp.ManagerID);
                com.Parameters.AddWithValue("@ActionType", "update");
                com.Parameters.AddWithValue("@ID", emp.ID);
                i = com.ExecuteNonQuery();
            }
            return i;
        }

        //Method for Deleting an Employee  
        public int DeleteEmployee(int ID)
        {
            int i;
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SP_Employee", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ActionType", "delete");
                com.Parameters.AddWithValue("@ID", ID);
                i = com.ExecuteNonQuery();
            }
            return i;
        }



        public List<Manager> ListAllManager()
        {
            List<Manager> lst = new List<Manager>();
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SP_Manager", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ActionType", "list");
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    lst.Add(new Manager
                    {
                        ID = Convert.ToInt64(rdr["ID"]),
                        ManagerName = rdr["ManagerName"].ToString(),
                        PhoneNumber = Convert.ToInt64(rdr["PhoneNumber"]),
                        Address = rdr["Address"].ToString(),
                    });
                }
                return lst;
            }
        }



        //Method for Adding an Employee  
        public int AddManager(Manager manager)
        {
            int i;
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SP_Manager", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ActionType", "insert");
                com.Parameters.AddWithValue("@ManagerName", manager.ManagerName);
                com.Parameters.AddWithValue("@PhoneNumber", manager.PhoneNumber);
                com.Parameters.AddWithValue("@Address", manager.Address);
                i = com.ExecuteNonQuery();
            }
            return i;
        }

        //Method for Updating Employee record  
        public int UpdateManager(Manager manager)
        {
            int i;
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SP_Manager", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ActionType", "update");
                com.Parameters.AddWithValue("@ManagerName", manager.ManagerName);
                com.Parameters.AddWithValue("@PhoneNumber", manager.PhoneNumber);
                com.Parameters.AddWithValue("@Address", manager.Address);
                com.Parameters.AddWithValue("@ID", manager.ID);
                i = com.ExecuteNonQuery();
            }
            return i;
        }

        //Method for Deleting an Employee  
        public int DeleteManager(int ID)
        {
            int i;
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SP_Manager", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ActionType", "delete");
                com.Parameters.AddWithValue("@ID", ID);
                i = com.ExecuteNonQuery();
            }
            return i;
        }

        public bool isLoginUserValid(Login login)
        {
           
            using (SqlConnection con = new SqlConnection(connStr))
            {
                bool isValidUser = false;
                con.Open();
                SqlCommand com = new SqlCommand("SP_Login", con);
                com.Parameters.AddWithValue("@LoginID", login.LoginID);
                com.Parameters.AddWithValue("@Password", login.password);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    isValidUser = true;
                }
                return isValidUser;
            }
        }

    }
}
