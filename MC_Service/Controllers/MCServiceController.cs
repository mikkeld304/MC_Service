using MC_Service.DataLayerAccess;
using MC_Service.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver.Core.Configuration;
using System.Collections;
using System.Text.Json;


namespace MC_Service.Controllers
{
    [Route("api/MCService")]
    [ApiController]
    public class MCServiceController : ControllerBase
    {
        private string connection_string { get; set; }
        private string databaseName { get; set; }
        private string collectionName { get; set; }
        private readonly MDB mDB;

        public MCServiceController() {
            connection_string = Environment.GetEnvironmentVariable("CONNECTION_STRING");
            databaseName = Environment.GetEnvironmentVariable("DATABASE_NAME");
            collectionName = Environment.GetEnvironmentVariable("COLLECTION_NAME");
            mDB = new MDB(connection_string, databaseName, collectionName);

        }


        [HttpPost("/addMotorcycle")]
        public async Task<IActionResult> addMotorcycleToDatabase([FromBody] Motorcycle data)
        {
            Motorcycle mc = await mDB.addMotorcycleToDatabase(data);
            Console.WriteLine(mc);
            return Ok(mc);
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
            await mDB.updateMotorcycle(id, propertyName, newvalue);
            return Ok();
        }
        
        
    }
}
