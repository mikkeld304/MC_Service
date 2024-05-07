using MC_Service.DataLayerAccess;
using MC_Service.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;


namespace MC_Service.Controllers
{
    [Route("api/MCService")]
    [ApiController]
    public class MCServiceController : ControllerBase
    {
        private readonly MDB mDB;
        public MCServiceController() {

            mDB = new MDB("mongodb+srv://mikkelpid:Sfqa0ulocJnPseRf@mcdb.ijorohu.mongodb.net/?retryWrites=true&w=majority&appName=MCDB", "MCDB", "Motorcycles");

        }


        [HttpPost("/addMotorcycle")]
        public async Task<IActionResult> addMotorcycleToDatabase([FromBody] Motorcycle data)
        {
            ObjectId mcId = await mDB.addMotorcycleToDatabase(data);
            string mcIdStr = mcId.ToString();
            return Ok(mcIdStr);
        }

        [HttpGet("/getAllMotorcycles")]
        public async Task<IActionResult> getAllMotorcycles()
        {
            List<Motorcycle> motorcyclesList = await mDB.getAllMotorcyclesFromDatabase();
            return Ok(motorcyclesList);
        }

        [HttpPost("/updateMotorcycle/{id}/{propertyName}/{newvalue}")]
        public async Task<IActionResult> updateMotorcycle(string id, string propertyName, string newvalue) 
        {
           await mDB.updateMotorcycle(id, propertyName, newvalue));
            return Ok();
        }

        
    }
}
