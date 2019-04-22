using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wm.Web.DataStore;
using Wm.Web.Models;

namespace Wm.Web.Services
{
    public class PlantService
    {
        public PlantService()
        {
            PlantRepository.Initliaze();
        }

        public IList<Plant> GetPlants()
        {
            return PlantRepository.Plants.Values.ToList();
        }

        public void StartWatering(IList<Guid> ids)
        {
            // set lastWatered to datetime.now + 10 seconds
        }

        public void StopWatering(IList<Guid> ids)
        {
            // overwrite lastWatered to datetime.now need boolean isWatering
            foreach(var id in ids)
            {
                if (PlantRepository.Plants.TryGetValue(id, out var plant))
                {

                }
            }
        }
    }
}