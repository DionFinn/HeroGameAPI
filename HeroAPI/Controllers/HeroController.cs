using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeroGameAPI;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace HeroGame.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HeroController : ControllerBase
    {
       public readonly ILogger<HeroController> _Logger;

       public HeroController(ILogger<HeroController> logger)
       {
         _Logger = logger;
       }
  
      //get all heroes
      [HttpGet]
      public IEnumerable<Hero> Get(){
        return HeroHandler.GetHeroes();
      }
      //get by ID (HeroID)
      [HttpGet]
      [Route("Hero/{HeroID}")]
      public Hero GetHero(int HeroID){
        return HeroHandler.GetHeroByID(HeroID);
      }
      
      [HttpPost]
      public void Post([FromBody]Hero hero){
        HeroHandler.HeroPost(hero);
      }
      //delete by id
      [HttpDelete("{HeroID}")]
        public void Delete(int HeroID){
          HeroHandler.DeleteHeroes(HeroID);
        }
      
    }
}