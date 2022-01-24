using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinhaalBE.Models;
using MySql.Data.MySqlClient;

namespace MinhaalBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase

    {
        string cs = @"server=localhost;userid=root;password=;database=minaal";

        [HttpGet]
        public string Get()
        {
            return "Welcome to the Minaal api v1";
        }
       
        [Route("signup")]
        [HttpPost]
        public string AddnewUser(Users newUser)
        {
            using var con = new MySqlConnection(cs);
            con.Open();

            Console.WriteLine($"MySQL version : {con.ServerVersion}");
            using var cmd = new MySqlCommand();
            cmd.Connection = con;

            cmd.CommandText = $"INSERT INTO `users` (`Email`, `Password`, `FirstName`, `LastName`, `PassportNumber`, `DateOfBirth`, `Country`, `Nationality`,`role`) VALUES('{newUser.Email}', '{newUser.Password}', '{newUser.FirstName}', '{newUser.LastName}', '{newUser.PassportNumber}', '{newUser.DateOfBirth}', '{newUser.Country}', '{newUser.Nationality}', '{newUser.Role}');" ;
            cmd.ExecuteNonQuery();



            // insertion here
            /** Sample body input
             * {
    "Email":"abubakar@gmail.com",
    "Password":"somelovelypass",
    "FirstName":"ABubakar",
    "LastName":"Mughal",
    "PassportNumber":"12345",
    "DateOfBirth":"2022-01-24T17:03:11.767976+05:00",
    "Country":"Pakistan",
    "Nationality":"Pakistani"
    "role":"admin"

             */
            return "Signed up " +newUser.Email + " " + newUser.PassportNumber;
        }
        [Route("login")]
        [HttpPost]
        public string LoginUser(LoginUser user)
        {

            using var con = new MySqlConnection(cs);
            con.Open();
            var stm = $"SELECT * FROM `users` WHERE Email = '{user.Email}' and Password = '{user.Password}'";
            var cmd = new MySqlCommand(stm, con);

            var res = cmd.ExecuteReader();
            while (res.Read())
            {
                return res["role"].ToString();
            }
            /**
             * {
    "Email":"abc",
    "Password":"1078"
}
             */
            //return "Logged In " + user.Email + " with password " + user.Password;
            return "NOT FOUND";
        }


    }
}