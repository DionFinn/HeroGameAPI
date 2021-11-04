using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Linq;
using HeroGameAPI;

namespace HeroGameAPI
{
    public class VillianHandler : DatabaseHandler
    {
               public static List<Villian> GetVillian(){
            List<Villian> villianList = new List<Villian>();


            //GetHeroes = Get all heroes + all details
            using (SqlConnection vconn = new SqlConnection(GetConnectionString())){
                try{
                    vconn.Open();

                    using (SqlCommand Vcomm = new SqlCommand("SELECT * FROM Villian", vconn))
                    {
                        using (SqlDataReader Vreader = Vcomm.ExecuteReader())
                        {
                            while(Vreader.Read())
                            {
                                villianList.Add(new Villian(){
                                VillianID = Vreader.GetInt32(0), 
                                VillianName = Vreader.GetString(1),
                                Attackpoints = Vreader.GetInt32(2)}); 
                            }
                        }
                    }
                }
                catch (Exception Excep){
                throw new Exception("error in the GetVilliansHandler" +  Excep.Message);
                }
                finally{
                    vconn.Close();
                } 
                return villianList;
            }
        }

        public static Villian GetVillianByID(int VillianID){
            Villian V = new Villian();
            using (SqlConnection IDVconn = new SqlConnection(GetConnectionString())){
                try {
                    IDVconn.Open();
                    using (SqlCommand IDcomm = new SqlCommand(string.Format("SELECT * FROM Villian WHERE VillianID = VillianID", VillianID), IDVconn)){
                        using (SqlDataReader IDreader = IDcomm.ExecuteReader()){
                            while(IDreader.Read()){
                                V.VillianID = IDreader.GetInt32(0); 
                                V.VillianName = IDreader.GetString(1);
                                V.Attackpoints = IDreader.GetInt32(2);
                            }
                        }
                    }
                }
                catch (Exception Excep){
                    throw new Exception("this Villian shii doesnt work lmao " + Excep.Message);
                }
                finally{
                    IDVconn.Close();
                }
                return V;
            }   
        }

        public static string VillianPost(Villian villian){
            using(SqlConnection Postconn = new SqlConnection(GetConnectionString())){
                Postconn.Open();
                using (SqlCommand PostCommand = new SqlCommand("HeroPost", Postconn)){
                    PostCommand.Parameters.AddWithValue("@postVillianID", villian.VillianName);
                    PostCommand.Parameters.AddWithValue("@postVillianName", villian.VillianName);
                    PostCommand.Parameters.AddWithValue("@postUses", villian.Attackpoints);

                    int postcount = PostCommand.ExecuteNonQuery();
                    
                    Postconn.Close();
                    if (postcount >= 1)
                    {
                        return "this post shii works lmao";
                    }
                    else {
                        return "";
                    }
                }
            }


        }

        public static string DeleteVillian(int VillianID){
            
            using (SqlConnection Vconn = new SqlConnection(GetConnectionString())){
            
                Vconn.Open();

            
                using (SqlCommand Vcommand = new SqlCommand("DeleteVillain", Vconn)){
            
                   Vcommand.CommandType = System.Data.CommandType.StoredProcedure;
                   Vcommand.Parameters.AddWithValue("@delVillainID", VillianID);
                   int delcount = Vcommand.ExecuteNonQuery();
                   Vconn.Close();

                   if(delcount >= 1){
                       return "deleted villian";
                   }
                   else {
                      return "delete did not work";
                   }
                }
            }
        }

        public static string VillianUpdate(Villian Villian){
            using (SqlConnection Vconn = new SqlConnection(GetConnectionString())){
                Vconn.Open();

                using (SqlCommand Vcommand = new SqlCommand("UpdateVillian", Vconn)){

                    Vcommand.CommandType = System.Data.CommandType.StoredProcedure;


                    Vcommand.Parameters.AddWithValue("@putVillianID", Villian.VillianID);
                    Vcommand.Parameters.AddWithValue("@putVillianName", Villian.VillianName);
                    Vcommand.Parameters.AddWithValue("@putVillianUses", Villian.Attackpoints);


                    int upCount = Vcommand.ExecuteNonQuery();
                    Vconn.Close();

                    if (upCount >= 1 ){
                        return "update 1";
                    }
                    else {
                        return "update V doesnt work";
                    }
                }
            }
        }
    }
}
    // public int VillianID { get; set; }
    //     public string VillianName { get; set; }
    //     public int Uses { get; set; }