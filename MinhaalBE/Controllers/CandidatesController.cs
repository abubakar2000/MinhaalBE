using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinhaalBE.Models;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace MinhaalBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        string cs = @"server=localhost;userid=root;password=;database=minaal";

        [Route("addcandi")]
        [HttpPost]
        public async Task<string> addCandi(Candidates candidates)
        {

            using var con = new MySqlConnection(cs);
            con.Open();

            Console.WriteLine($"MySQL version : {con.ServerVersion}");
            using var cmd = new MySqlCommand();
            cmd.Connection = con;

            cmd.CommandText = $"INSERT INTO `candidates` (`cid`, `fname`, `lname`, `passport`, `positionapplied`, `dob`, `country`, `nationality`, `experience`, `email`) VALUES (NULL, '{candidates.fname}', '{candidates.lname}', '{candidates.passport}', '{candidates.positionapplied}', '{candidates.dob}', '{candidates.country}', '{candidates.nationality}', '{candidates.experience}', '{candidates.email}');";
            cmd.ExecuteNonQuery();

            return "OK";
        }

        [Route("getcandi")]
        [HttpPost]
        public async Task<string[]> LoginUser()
        {

            using var con = new MySqlConnection(cs);
            con.Open();
            var stm = $"SELECT * FROM `candidates`";
            var cmd = new MySqlCommand(stm, con);

            List<string> a = new List<string>();
            var res = cmd.ExecuteReader();
            while (res.Read())
            {
                
                a.Add( res["email"].ToString());
            }
            return  a.ToArray();
        }
    }

    
}