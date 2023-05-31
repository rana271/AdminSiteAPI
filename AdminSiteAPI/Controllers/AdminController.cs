using AdminSiteAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace AdminSiteAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : Controller
    {
        public List<User> Index()
        {
            List<User> users = new List<User>();
            //users.Add(new User { })
            SqlConnection con = new SqlConnection(@"Data Source=RANA\SQLEXPRESS;Initial Catalog=AdminSiteDB;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Users", con);
            SqlDataReader dr= cmd.ExecuteReader();
            while (dr.Read())
            {
                users.Add(new User { Id = dr["id"].ToString(), 
                    UserName = dr["username"].ToString(), 
                    CompanyID = dr["CompanyID"].ToString(), 
                    CompanyName = dr["CompanyName"].ToString(), 
                    UserType = dr["usertype"].ToString() });
            }
            return users;

        }
    }
}
