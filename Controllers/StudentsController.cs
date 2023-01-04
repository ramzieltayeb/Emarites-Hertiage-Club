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
    public class StudentsController : ControllerBase
    {
        private readonly IConfiguration _configruation;

        public StudentsController (IConfiguration configuration)
        {
            _configruation = configuration;
        }
        
        [HttpGet]
        [Route("{id}")]
        public JsonResult GetById(Students Stu)
        {
            String Query = "Select * from Students where StudentID =" + Stu.StudentID + "";
            DataTable table = new DataTable();

            string sqldatasource = _configruation.GetConnectionString("SchoolCon");
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

            return new JsonResult(table);
        }


        [HttpGet]
        public JsonResult GetAllStudents()
        {
            String Query = @"Select * from Students";
            DataTable table = new DataTable();

            string sqldatasource = _configruation.GetConnectionString("SchoolCon");

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

            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult AddStudent(Students Stu)
        {
            string Query = @"insert into Students (Student_first_name,Student_last_name,Email,Address,PhoneNumber,ClassLevel,parent,Gender) values ('" + Stu.Student_first_name+ "','"+Stu.Student_last_name+"','"+Stu.Email+"','"+Stu.Address+"','"+Stu.PhoneNumber+"','"+Stu.ClassLevel+"','"+Stu.Parent+"','"+Stu.Gender+@"') ";
            DataTable table = new DataTable();

            string sqldatasource = _configruation.GetConnectionString("SchoolCon");

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

            return new JsonResult("Added Succussfully");
        }
        

        [HttpPut]
        public JsonResult UpdateClassLevel(Students Stu)
        {
            string Query = @"update Students set ClassLevel =" + Stu.ClassLevel +
                " where StudentID = " + Stu.StudentID + @" ";
            DataTable table = new DataTable();

            string sqldatasource = _configruation.GetConnectionString("SchoolCon");

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
        public JsonResult Delete(Students Stu)
        {
            string Query = @"delete from Students where StudentID =" + Stu.StudentID + @" ";
            DataTable table = new DataTable();

            string sqldatasource = _configruation.GetConnectionString("SchoolCon");

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