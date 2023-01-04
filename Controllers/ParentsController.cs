using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using PschoolAPI.Models;

namespace PschoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        
        public ParentsController (IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult GetAllParents()
        {
            string Query = @"Select * from Parents";

            DataTable PTable = new DataTable();

            string sqldatasource = _configuration.GetConnectionString("SchoolCon");

            SqlDataReader reader;
            using (SqlConnection con = new SqlConnection(sqldatasource))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    reader = cmd.ExecuteReader();
                    PTable.Load(reader);

                    reader.Close();

                    con.Close();
                }
            }

            return new JsonResult(PTable);
        }

        [HttpPost]
        public JsonResult AddParent(Parents par)
        {
            string Query = @"Insert into parents(ParentName,PhoneNumber,Email,Address) values ('" + par.ParentName + "','" + par.PhoneNumber + "','" + par.Email + "','" + par.Address + "')";

            DataTable PTable = new DataTable();

            string sqldatasource = _configuration.GetConnectionString("SchoolCon");

            SqlDataReader reader;
            using (SqlConnection con = new SqlConnection(sqldatasource))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    reader = cmd.ExecuteReader();
                    PTable.Load(reader);

                    reader.Close();

                    con.Close();
                }
            }

            return new JsonResult("Added Successflly");
        }

        [HttpPut]
        public JsonResult UpdateParent(Parents Par)
        {
            string Query = @"update Parents set Address ='" + Par.Address +
               "' where ParentID = " + Par.ParentID + @" ";
            DataTable table = new DataTable();

            string sqldatasource = _configuration.GetConnectionString("SchoolCon");

            SqlDataReader reader;
            using (SqlConnection con = new SqlConnection(sqldatasource))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    reader = cmd.ExecuteReader();
                    table.Load(reader);

                    reader.Close();

                    con.Close();
                }
            }

            return new JsonResult("Updated Succussfully");
        }

        [HttpDelete]
        public JsonResult DeleteParent(Parents ParentID)
        {
            string Query = "Delete from parents where ParentID = " + ParentID.ParentID + "";
            DataTable table = new DataTable();

            string sqldatasource = _configuration.GetConnectionString("SchoolCon");

            SqlDataReader reader;
            using (SqlConnection con = new SqlConnection(sqldatasource))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    reader = cmd.ExecuteReader();
                    table.Load(reader);

                    reader.Close();

                    con.Close();
                }
            }

            return new JsonResult("Deleted Succussfully");
        }
    }
}