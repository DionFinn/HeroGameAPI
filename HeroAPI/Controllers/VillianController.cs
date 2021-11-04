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
    public class VillianController : ControllerBase 
    {
       public readonly ILogger<VillianController> _Logger;

       public VillianController(ILogger<VillianController> logger)
       {
         _Logger = logger;
       }
  
        [HttpGet]
        public IEnumerable<Villian> Get(){
            return VillianHandler.GetVillian();
        }

        [HttpGet]
        [Route("/Villian/{VillianID}")]
        public Villian GetVillianByID(int VillianID){
            return VillianHandler.GetVillianByID(VillianID);
        }

        [HttpPost]
      public void Post([FromBody]Villian villian){
        VillianHandler.VillianPost(villian);
      }
      //delete by id
      [HttpDelete("{VillianId}")]
        public void Delete(int VillianID){
          VillianHandler.DeleteVillian(VillianID);
        }

    }
}
