using System;
using System.Collections.Generic;
using System.Text;

namespace JustMVP.Domain
{
    public class UserRobot
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int RobotId { get; set; }
        public Robot Robot { get; set; }
    }
}
