using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Wm.Web.Models;

namespace Wm.Web.DataStore
{
    /*  Singleton, no database currently. We can add one in the future
    *   using controller/data or controller/service/data
    *   PlantRepository can be updated to use a non static repository class that could use
    *   a database context, via Linq2Sql
    */
    public static class PlantRepository
    {
        public static IList<Plant> Plants { get; } = new List<Plant>();

        public static bool isInitialized { get; set; }

        public static void Initliaze()
        {
            var appConfigFlower = ConfigurationManager.AppSettings["flowers"] ?? null;

            if (!isInitialized && !String.IsNullOrEmpty(appConfigFlower))
            {
                var flowerCount = int.Parse(appConfigFlower);
                for (var i = 0; i < flowerCount; i++) { 
                    Plants.Add(new Plant());
                }
            }

            isInitialized = true;
        }
    }
}