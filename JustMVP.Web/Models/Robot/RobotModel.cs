using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using JustMVP.Domain;
using JustMVP.Web.Models.Job;

namespace JustMVP.Web.Models.Robot
{
    public class RobotModel
    {
        public string Name { get; set; }

        public RobotStatus Status { get; set; }

        public JobModel Job { get; set; }

        [Range(0, 100)]
        public int BatteryLevel { get; set; }

        public bool AvailableForChildren { get; set; }

        public int OwnerUserId { get; set; }
    }
}
