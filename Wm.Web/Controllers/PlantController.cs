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
        public IList<Plant> GetPlants()
        {
            return plantService.GetPlants();
        }

        [HttpPost]
        public void StartWatering(IList<Guid> ids)
        {
            // start watering plants;
            plantService.StartWatering(ids);
        }

        [HttpPost]
        public void StopWatering(IList<Guid> ids)
        {
            // start watering plants;
            plantService.StopWatering(ids);
        }
    }
}
