using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace AirportManagement.Data.Storage
{
    public class WriterReader
    {
        public static void Write (Repository repository)
        { 
            JsonSerializer serializer = new JsonSerializer();
            serializer.NullValueHandling = NullValueHandling.Ignore;
            using (StreamWriter sw = new StreamWriter("all.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, repository); 
            }
        }

        public static Repository Read()
        {
            try
            {
                // deserialize JSON directly from a file
                using (StreamReader file = File.OpenText("all.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    Repository repository = (Repository)serializer.Deserialize(file, typeof(Repository));
                    return repository;
                }
            }
            catch (FileNotFoundException)
            {
                Repository repository = new Repository();
                //repository.Create(); // replaced by seeding
                return repository;
            }
        }
    }
}
