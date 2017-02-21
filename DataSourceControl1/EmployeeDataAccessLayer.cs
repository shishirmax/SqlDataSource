using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataSourceControl1
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string City { get; set; }
        public string Contact { get; set; }

    }
    public class EmployeeDataAccessLayer
    {
        public static List<Employee> GetAllEmployees()
        {
            List<Employee> listEmployee = new List<Employee>();

            string CS = ConfigurationManager.ConnectionStrings["SampleDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("select * from Employee", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Employee employee = new Employee();
                    employee.ID = Convert.ToInt32(rdr["ID"]);
                    employee.Name = rdr["Name"].ToString();
                    employee.Department = rdr["Department"].ToString();
                    employee.City = rdr["City"].ToString();
                    employee.Contact = rdr["Contact"].ToString();

                    listEmployee.Add(employee);

                }
            }
            return listEmployee;

    }
    }
}