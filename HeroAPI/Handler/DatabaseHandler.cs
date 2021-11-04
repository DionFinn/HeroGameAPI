using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Linq;
namespace HeroGameAPI
{
    public abstract class DatabaseHandler
    {
        public static string GetConnectionString(){
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "database-1.cizuhqmhiqkc.us-east-1.rds.amazonaws.com";
                builder.UserID = "admin";
                builder.Password = "n8Z26pv$Qt";
                builder.InitialCatalog = "heroGame";
                return builder.ConnectionString;
            }
            catch(Exception i){
                throw new Exception("error in this function GetConnectionString() " + i.Message);
            }
        }
    }
}