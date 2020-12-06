using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JustMVP.Domain;
using JustMVP.Web.Models.Job;
using JustMVP.Web.Models.Robot;

namespace JustMVP.Web.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Robot, RobotModel>(MemberList.None);

            CreateMap<Job, JobModel>(MemberList.None);
        }
    }
}
