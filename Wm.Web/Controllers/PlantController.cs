using System;
using System.Collections.Generic;
using System.Web.Http;
using Wm.Web.Models;
using Wm.Web.Services;

namespace Wm.Web.Controllers
{
    // Fix later once we need this ready for release
    public class PlantController : ApiController
    {
        private readonly PlantService plantService = new PlantService();

        [HttpGet]
        [ActionName(nameof(GetPlants))]
        public IList<Plant> GetPlants()
        {
            return plantService.GetPlants();
        }

        [HttpPost]
        [ActionName(nameof(StartWatering))]
        public void StartWatering([FromBody] IList<Plant> plants)
        {
            // start watering plants;
            plantService.StartWatering(plants);
        }

        [HttpPost]
        [ActionName(nameof(StopWatering))]
        public void StopWatering([FromBody] IList<Plant> plants)
        {
            // start watering plants;
            plantService.StopWatering(plants);
        }
    }
}
