using MongoDB.Driver;
using MongoDB.Bson;
using MC_Service.Models;
using MongoDB.Driver.Linq;

namespace MC_Service.DataLayerAccess
{

    public class MDB
    {
        
        private IMongoDatabase mcdb;
        private IMongoCollection<Motorcycle> motorcycles;
        private IMongoQueryable <Motorcycle> queryableMotorcycles;
        public MDB(string connectionString, string databaseName, string collectionName) {

            var client = new MongoClient(connectionString);
            mcdb = client.GetDatabase(databaseName);
            motorcycles = mcdb.GetCollection<Motorcycle>(collectionName);
            queryableMotorcycles = motorcycles.AsQueryable();
        }

            public async Task<List<Motorcycle>> getAllMotorcyclesFromDatabase()
            {
                List<Motorcycle> allMotorcycles = new List<Motorcycle>();
                try
                {
                    allMotorcycles = await queryableMotorcycles.ToListAsync();
                }
                catch (Exception ex) { 
                    Console.WriteLine(ex.Message);
                    throw;
                }
                return allMotorcycles;
            }

        public async Task<ObjectId> addMotorcycleToDatabase(Motorcycle motorcycle)
        {
            try
            {
                await motorcycles.InsertOneAsync(motorcycle);
            }
            catch (Exception ex) {
               Console.WriteLine(ex);
                throw;
            }
            return motorcycle._id;
        }



        public void updateMotorcycle(string id, string propertyName,  string newPropertyValue)
        {
            var objectId = ObjectId.Parse(id);
            var filter = Builders<Motorcycle>.Filter.Eq(m => m._id, objectId);
            var update = Builders<Motorcycle>.Update.Set(propertyName, newPropertyValue);
            motorcycles.UpdateOne(filter, update);
        }

    }
}
