using Microsoft.AspNetCore.Mvc;
using System.Web;
using MvcCrud.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;

namespace MvcCrud.Controllers
{

    public class RegisterController : Controller
    {
        private readonly IConfiguration _configuration;
        public RegisterController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
       
        public IActionResult register()
        {
            return View();
        }
       
        public JsonResult insertData([FromBody] UserMaster dt)
        {

            List<string> lst = new List<string>();
            try
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO UserMaster (FULLNAME, USERNAME, PASSWORD) VALUES (@FullName, @UserName, @Password)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    
                   cmd.Parameters.AddWithValue("@FullName", dt.FULLNAME);
                    cmd.Parameters.AddWithValue("@UserName", dt.USERNAME);
                    cmd.Parameters.AddWithValue("@Password", dt.PASSWORD);
                    cmd.ExecuteNonQuery();

                    lst.Add("Data inserted successfully.");
                }
            }
            catch (Exception ex)
            {
                lst.Add($"Error: {ex.Message}");
            }

            return Json(lst);
        }

    }
    
        //public IActionResult result([FromBody] UserMaster mstr)
        //{
        //    return Json(new {success = true});
        //}
    
}
