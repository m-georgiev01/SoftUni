using System.Collections.Generic;
using System.Linq;
using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;

namespace RobotService.Repositories
{
    public class RobotRepository : IRepository<IRobot>
    {
        private List<IRobot> robots;

        public RobotRepository()
        {
            robots = new List<IRobot>();
        }

        public IReadOnlyCollection<IRobot> Models()
            => robots.AsReadOnly();

        public void AddNew(IRobot model)
            => robots.Add(model);

        public bool RemoveByName(string typeName)
        {
            foreach (IRobot robot in robots)
            {
                if (robot.Model == typeName)
                {
                    return robots.Remove(robot);
                }
            }

            return false;
        }

        public IRobot FindByStandard(int interfaceStandard)
            => robots.FirstOrDefault(r => r.InterfaceStandards.Any(i => i == interfaceStandard));
    }
}
