using System;
using System.Collections.Generic;
using System.Collections;
using Procurios.Public;

namespace Core.Helpers
{
    public static class JSONParser
    {
        public static IList<DateTime> AddMyShowJSON(string response)
        {
            var success = false;

            var jsonHash = (ArrayList)JSON.JsonDecode(response, ref success);

            if (!success || jsonHash == null)
                return null;

            var dates = new List<DateTime>();

            foreach (var item in jsonHash)
            {
                var showData = (Hashtable)item;
                dates.Add(DateTime.Parse(showData["showdate"].ToString()));
            }
            
            return dates;
        }

    }
}
