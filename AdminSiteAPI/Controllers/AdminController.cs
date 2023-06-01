using AdminSiteAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlClient;
namespace AdminSiteAPI.Controllers
{
   
    [ApiController]
    
    public class AdminController : Controller
    {
        
        [HttpGet]
        [Route("api/Admin/getuserList")]
        public List<User> getuserList()
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
        [HttpGet]
        [Route("api/Admin/getuserListbyID/{id}")]
        public User getuserListbyID(int id)
        {
            User usr = new User();
            SqlConnection con = new SqlConnection(@"Data Source=RANA\SQLEXPRESS;Initial Catalog=AdminSiteDB;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Users where id=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                usr.Id = dr["id"].ToString();
                usr.UserName = dr["username"].ToString();
                usr.CompanyID = dr["CompanyID"].ToString();
                usr.CompanyName = dr["CompanyName"].ToString();
                usr.UserType = dr["usertype"].ToString();
            }
            return usr;
        }
        
    }
}
