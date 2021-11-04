using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Linq;
using HeroGameAPI;

namespace HeroGameAPI
{
    public class HeroHandler : DatabaseHandler
    {
        public static List<Hero> GetHeroes(){
            List<Hero> heroList = new List<Hero>();


            //GetHeroes = Get all heroes + all details
            using (SqlConnection hconn = new SqlConnection(GetConnectionString())){
                try{
                    hconn.Open();

                    using (SqlCommand Hcomm = new SqlCommand("SELECT * FROM Hero", hconn))
                    {
                        using (SqlDataReader Hreader = Hcomm.ExecuteReader())
                        {
                            while(Hreader.Read())
                            {
                                heroList.Add(new Hero(){
                                HeroID = Hreader.GetInt32(0), 
                                HeroName = Hreader.GetString(1),
                                MinDice = Hreader.GetInt32(2),
                                MaxDice = Hreader.GetInt32(3),
                                Uses = Hreader.GetInt32(4) }); 
                            }
                        }
                    }
                }
                catch (Exception Excep){
                throw new Exception("error in the GetHeroesHandler" +  Excep.Message);
                }
                finally{
                    hconn.Close();
                } 
                return heroList;
            }
        }
        //get hero id, copy this shit for other handlers e.g. villian etc dont over work shit that doesnt need to be
        public static Hero GetHeroByID(int HeroID){
            Hero h = new Hero();
            using (SqlConnection IDhconn = new SqlConnection(GetConnectionString())){
                try {
                    IDhconn.Open();
                    using (SqlCommand IDcomm = new SqlCommand(string.Format("SELECT * FROM Hero WHERE HeroId = HeroId", HeroID), IDhconn)){
                        using (SqlDataReader IDreader = IDcomm.ExecuteReader()){
                            while(IDreader.Read()){
                                h.HeroID = IDreader.GetInt32(0); 
                                h.HeroName = IDreader.GetString(1);
                                h.MinDice = IDreader.GetInt32(2);
                                h.MaxDice = IDreader.GetInt32(3);
                                h.Uses = IDreader.GetInt32(4); 
                            }
                        }
                    }
                }
                catch (Exception Excep){
                    throw new Exception("this shii doesnt work lmao " + Excep.Message);
                }
                finally{
                    IDhconn.Close();
                }
                return h;
            }   
        }

        public static string HeroPost(Hero hero){
            using(SqlConnection Postconn = new SqlConnection(GetConnectionString())){
                Postconn.Open();
                using (SqlCommand PostCommand = new SqlCommand("HeroPost", Postconn)){
                    PostCommand.Parameters.AddWithValue("@postHeroID", hero.HeroID);
                    PostCommand.Parameters.AddWithValue("@postHeroName", hero.HeroName);
                    PostCommand.Parameters.AddWithValue("@postMinDice", hero.MinDice);
                    PostCommand.Parameters.AddWithValue("@postMaxDice", hero.MaxDice);
                    PostCommand.Parameters.AddWithValue("@postUses", hero.Uses);

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
        // not finished this yet finish procs in database to use them all lmao 
        public static string DeleteHeroes(int HeroID) {
            using(SqlConnection Deleteconn = new SqlConnection(GetConnectionString())){
                Deleteconn.Open();
                using (SqlCommand deleteCommand = new SqlCommand("DeleteHero", Deleteconn)){
                    deleteCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    
                    deleteCommand.Parameters.AddWithValue("DeleteHero.HeroID", HeroID);

                    int deleteCount = deleteCommand.ExecuteNonQuery();

                    Deleteconn.Close();

                    if(deleteCount >= 1){
                        return "this delete shii works lmao";
                    }

                    else {
                        return "";
                    }

                }
            }
        }
    }
}
        // public int HeroID { get; set; }
        // public string  HeroName { get; set; }
        // public int MinDice { get; set; }
        // public int MaxDice { get; set; }
        // public int Uses { get; set; }

        //ADD GET BY ID, ADD GET BY NAME, ADD POST HERO