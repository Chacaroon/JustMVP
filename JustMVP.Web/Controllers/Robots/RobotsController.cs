using System.Linq;
using JustMVP.DAL.Interfaces;
using JustMVP.Web.Models.Robot;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace JustMVP.Web.Controllers.Robots
{
    [Route("api/[controller]")]
    [ApiController]
    public class RobotsController : BaseController
    {
        private readonly IRobotsRepository _robotsRepository;

        public RobotsController(IRobotsRepository robotsRepository)
        {
            _robotsRepository = robotsRepository;
        }

        [HttpGet]
        public ActionResult<RobotModel[]> GetAll()
        {
            var result = _robotsRepository.GetAll(x => x.UserRobots.Any(x1 => x1.UserId == UserId));

            return Success(result);
        }
    }
}
