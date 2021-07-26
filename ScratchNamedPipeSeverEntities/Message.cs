using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScratchNamedPipeSeverEntities
{
    public class Message
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public DateTime DateSent { get; set; }

        public static Message Deserialize(string message)
        {
            return JsonConvert.DeserializeObject<Message>(message);
        }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static Message DeserializeCompressed(string message)
        {
            var bytes = Encoding.ASCII.GetBytes(message);
            var decompressed = StrComp.Unzip(bytes);
            var m = JsonConvert.DeserializeObject<Message>(decompressed);
            return m;
        }

        public string SerializeCompressed()
        {
            //convert obj to json string
            var s = JsonConvert.SerializeObject(this);
            var compressed = StrComp.Zip(s);
            string result = Encoding.ASCII.GetString(compressed);
            return result;
        }
    }
}
