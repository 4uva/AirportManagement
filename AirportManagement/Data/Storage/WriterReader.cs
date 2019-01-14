using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace AirportManagement.Data.Storage
{
    class WriterReader
    {
        public static void Write (All all)
        { 
            JsonSerializer serializer = new JsonSerializer();
            serializer.NullValueHandling = NullValueHandling.Ignore;
            using (StreamWriter sw = new StreamWriter("all.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, all); 
            }
        }

        public static All Read()
        { 
            // deserialize JSON directly from a file
            using (StreamReader file = File.OpenText("all.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                All all = (All)serializer.Deserialize(file, typeof(All));
                return all;
            }
        }
    }
}
