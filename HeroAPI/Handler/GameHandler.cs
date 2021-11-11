using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Linq;
using HeroGameAPI;

namespace HeroGameAPI
{
        public class GameHandler : DatabaseHandler
        {
            public static List<Game> GetGames() {
                List<Game> gameList = new List<Game>();
                    using(SqlConnection Gconn = new SqlConnection(GetConnectionString())){
                        try {
                            using(SqlCommand Gcommand = new SqlCommand("SELECT * FROM Game", Gconn)){
                                using(SqlDataReader Greader = Gcommand.ExecuteReader()){
                                    while(Greader.Read()){
                                        gameList.Add(new Game(){
                                            GameID = Greader.GetInt32(0),
                                            Winner = Greader.GetString(1)});
                                        }
                                    }
                                }
                            }
                        catch (Exception Excep){
                            throw new Exception("Get Games does not work" + Excep.Message);
                        }
                        finally{
                            Gconn.Close();
                        }
                        return gameList;
                        }
        }

        public static Game GetGameID(int GameID){
            Game game = new Game();
            
            using (SqlConnection Gconn = new SqlConnection(GetConnectionString())){
                try {
                    Gconn.Open();
                    using(SqlCommand Gcommand = new SqlCommand(string.Format("SELECT * FROM Game WHERE GAMEID = \'{0}\'", GameID), Gconn)){
                        using (SqlDataReader Greader = Gcommand.ExecuteReader()){
                            while(Greader.Read()){
                                game.GameID = Greader.GetInt32(0);
                                game.Winner = Greader.GetString(1);
                            }
                        }
                    }
                }
            catch (Exception Excep){
                throw new Exception("Get Game by ID does not work" + Excep.Message);
            }    
            finally{
                Gconn.Close();
            }
            }
            return game;
        }
       public static string PostGame (Game game){
           using(SqlConnection Gconn = new SqlConnection(GetConnectionString())){
               Gconn.Open();
               using(SqlCommand Gcomm = new SqlCommand("GamePost", Gconn)){

                   Gcomm.CommandType = System.Data.CommandType.StoredProcedure;
                   Gcomm.Parameters

                    // using (SqlCommand PostCommand = new SqlCommand("HeroPost", Postconn)){
                    // PostCommand.Parameters.AddWithValue("@postHeroID", hero.HeroID);
                    // PostCommand.Parameters.AddWithValue("@postHeroName", hero.HeroName);
                    // PostCommand.Parameters.AddWithValue("@postMinDice", hero.MinDice);
                    // PostCommand.Parameters.AddWithValue("@postMaxDice", hero.MaxDice);
                    // PostCommand.Parameters.AddWithValue("@postUses", hero.Uses);

               }
           }
       }
    }   
}