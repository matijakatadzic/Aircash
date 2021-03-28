using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aircash.DataContract.Token
{
    public class Token
    {
        public Token(string responseToken)
        {
            var parsedObject = JObject.Parse(responseToken);
            OathToken = parsedObject["access_token"].ToString();
            ExpireTime = DateTime.Now.AddSeconds(Convert.ToInt32( parsedObject["expires_in"].ToString()));
        }

        public string OathToken { get; set; }
        public DateTime ExpireTime { get; set; }
    }
}
