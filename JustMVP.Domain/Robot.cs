using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JustMVP.Domain
{
    public class Robot : BaseEntity
    {
        public string Name { get; set; }

        public RobotStatus Status { get; set; }

        public int? CurrentJobId { get; set; }

        public Job? CurrentJob { get; set; }

        [Range(0, 100)]
        public int BatteryLevel { get; set; }

        public bool AvailableForChildren { get; set; }

        public int OwnerUserId { get; set; }
    }
}
