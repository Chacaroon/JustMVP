using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JustMVP.DAL.Interfaces;
using JustMVP.Domain;
using Microsoft.EntityFrameworkCore;

namespace JustMVP.DAL.Repositories
{
    public class RobotsRepository : BaseRepository<Robot>, IRobotsRepository
    {
        protected override IQueryable<Robot> BaseQuery => base.BaseQuery.Include(x => x.CurrentJob);

        public RobotsRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
