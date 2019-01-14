using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace AirportManagement.Data.Storage
{
    class ReaderWriter
    {

        public static All Read()
        { return new All(); }
        public static void Write (All all )
        { 
         
            JsonSerializer serializer = new JsonSerializer();
            serializer.NullValueHandling = NullValueHandling.Ignore;
            using (StreamWriter sw = new StreamWriter("all.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
             serializer.Serialize(writer, all); 
            //    // {"ExpiryDate":new Date(1230375600000),"Price":0}this is a method body,i cant make a semanic conection 
            //}









         }

    }
}
}
