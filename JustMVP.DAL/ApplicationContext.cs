using JustMVP.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace JustMVP.DAL
{
    public class ApplicationContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        private readonly IConfiguration _configuration;
        private const int _seededEntitiesCount = 3;

        public ApplicationContext(DbContextOptions<ApplicationContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("JustMVP"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ConfigureUsers(modelBuilder);
            ConfigureRoles(modelBuilder);
            ConfigureRobots(modelBuilder);
            ConfigureJobs(modelBuilder);
        }

        public DbSet<Robot> Robots { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<UserRobot> UserRobots { get; set; }

        private void ConfigureUsers(ModelBuilder modelBuilder)
        {
            var passwordHasher = new PasswordHasher<User>();

            var users = Enumerable.Range(1, _seededEntitiesCount)
                .Select(x =>
                {
                    var user = new User($"User{x}")
                    {
                        Id = x
                    };

                    user.NormalizedUserName = user.UserName.ToUpper();
                    user.PasswordHash = passwordHasher.HashPassword(user, $"Password{x}@");

                    return user;
                });

            modelBuilder.Entity<User>()
                .HasData(users);
        }

        private void ConfigureRoles(ModelBuilder modelBuilder)
        {
            var roles = new[] { "User", "Child" }.Select((roleName, i) => new IdentityRole<int>
            {
                Id = i + 1,
                Name = roleName,
                NormalizedName = roleName.ToUpper(),
            });

            var userRoles = Enumerable.Range(1, _seededEntitiesCount)
                .Select(x => new IdentityUserRole<int>
                {
                    UserId = x,
                    RoleId = x % 2 + 1
                });

            modelBuilder.Entity<IdentityRole<int>>()
                .HasData(roles);

            modelBuilder.Entity<IdentityUserRole<int>>()
                .HasData(userRoles);
        }

        private void ConfigureRobots(ModelBuilder modelBuilder)
        {
            var robots = Enumerable.Range(1, _seededEntitiesCount)
                .Select(x => new Robot
                {
                    Id = x,
                    BatteryLevel = 100,
                    Name = $"Robot {x}",
                    Status = RobotStatus.Disabled,
                    AvailableForChildren = true,
                    OwnerUserId = x
                });

            modelBuilder.Entity<Robot>()
                .HasData(robots);

            modelBuilder.Entity<UserRobot>()
                .HasKey(x => new { x.RobotId, x.UserId });

            modelBuilder.Entity<UserRobot>()
                .HasData(robots.Select(x => new UserRobot
                {
                    RobotId = x.Id,
                    UserId = x.Id,
                }));
        }

        private void ConfigureJobs(ModelBuilder modelBuilder)
        {
            var jobs = Enumerable.Range(1, _seededEntitiesCount)
                .Select(x => new Job
                {
                    Id = x,
                    Name = $"Job {x}"
                });

            modelBuilder.Entity<Job>()
                .HasData(jobs);
        }
    }
}
