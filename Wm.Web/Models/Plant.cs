using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wm.Web.Models
{
    public class Plant
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTime LastWatered { get; set; }

        public bool IsWatering { get; set; }

        // TODO: figure out what 'water status' means?
    }
}