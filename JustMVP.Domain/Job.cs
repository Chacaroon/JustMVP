using System;
using System.Collections.Generic;
using System.Text;

namespace JustMVP.Domain
{
    public class Job: BaseEntity
    {
        public string Name { get; set; }

        public string? Params { get; set; }
    }
}
