﻿using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFoody.Job.Repositories
{
   public class BaseRepository
    {
        const string CONNECTION_STRING = "Server=localhost,1433;Database=IFoody;User Id=sa;Password=1q2w3e4r@#$";
        
        protected async Task<int> ExecutarAsync(string sqlCommand, object? parms)
        {
            using(var conn = new SqlConnection(CONNECTION_STRING))
            {
               return await conn.ExecuteAsync(sqlCommand, parms);
            }
        }
        protected int Executar(string sqlCommand, object? parms)
        {
            using (var conn = new SqlConnection(CONNECTION_STRING))
            {
                return  conn.Execute(sqlCommand, parms);
            }
        }

    }
}
