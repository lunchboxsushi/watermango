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

        public void StartWatering(IList<Plant> entities)
        {
            // set lastWatered the calculated time
            foreach (var entity in entities)
            {
                // incase it's been deleted check our repo
                if (PlantRepository.Plants.TryGetValue(entity.Id, out var plant))
                {
                    // validate plant is able to be watered need to handle business exception case
                    if (plant.LastWatered == null || plant.LastWatered > DateTime.UtcNow.AddSeconds(30))
                    {
                        plant.IsWatering = true;
                        plant.LastWatered = DateTime.UtcNow.AddSeconds(10);
                        plant.AlertWatering = plant.LastWatered.GetValueOrDefault().AddHours(6);
                    } else
                    {
                        throw new Exception($"Plant cannot be watered again within 30 seconds");
                    }
                }
            }
        }

        public void StopWatering(IList<Plant> entities)
        {
            // set lastWatered the calculated time
            foreach (var entity in entities)
            {
                // incase it's been deleted check our repo
                if (PlantRepository.Plants.TryGetValue(entity.Id, out var plant))
                {
                    plant.IsWatering = false;
                    plant.LastWatered = DateTime.UtcNow;
                    plant.AlertWatering = plant.LastWatered.GetValueOrDefault().AddHours(6);
                }
            }
        }
    }
}