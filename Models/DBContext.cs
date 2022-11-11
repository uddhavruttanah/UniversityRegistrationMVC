using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using DAL.Model;

namespace UniversityRegistrationMVC.Models
{
    public class DBContext
    {
        public SqlConnection con=new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ConnectionString);
        public List<UniversityUserData> GetUniversityUser(string authenticateUserQuery)
        {
            List<UniversityUserData> list = new List<UniversityUserData> ();
            SqlCommand cmd = new SqlCommand("select Email, Password from UserData", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable datatable = new DataTable();
            //when using adapter no need to open/close connection
            //it establish and update connection on its own
            adapter.Fill(datatable);
            foreach(DataRow dataRow in datatable.Rows)
            {
                list.Add(new UniversityUserData
                {
                    Email= Convert.ToString(dataRow[0]),
                    Password= Convert.ToString(dataRow[1])
                });
            }
            return list;    
        }
    }
}