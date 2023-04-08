using System.Linq;
using System.Text;
using RobotService.Core.Contracts;
using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories;
using RobotService.Repositories.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private IRepository<ISupplement> supplements;
        private IRepository<IRobot> robots;

        public Controller()
        {
            supplements = new SupplementRepository();
            robots = new RobotRepository();
        }

        public string CreateRobot(string model, string typeName)
        {
            if (typeName != nameof(DomesticAssistant) &&
                typeName != nameof(IndustrialAssistant))
            {
                return string.Format(OutputMessages.RobotCannotBeCreated, typeName);
            }

            IRobot robot = null;
            if (typeName == nameof(DomesticAssistant))
            {
                robot = new DomesticAssistant(model);
            }
            else if (typeName == nameof(IndustrialAssistant))
            {
                robot = new IndustrialAssistant(model);
            }

            robots.AddNew(robot);

            return string.Format(OutputMessages.RobotCreatedSuccessfully, typeName, model);
        }

        public string CreateSupplement(string typeName)
        {
            if (typeName != nameof(SpecializedArm) &&
                typeName != nameof(LaserRadar))
            {
                return string.Format(OutputMessages.SupplementCannotBeCreated, typeName);
            }

            ISupplement supplement = null;
            if (typeName == nameof(SpecializedArm))
            {
                supplement = new SpecializedArm();
            }
            else if (typeName == nameof(LaserRadar))
            {
                supplement = new LaserRadar();
            }

            supplements.AddNew(supplement);

            return string.Format(OutputMessages.SupplementCreatedSuccessfully, typeName);
        }

        public string UpgradeRobot(string model, string supplementTypeName)
        {
            ISupplement supplement = supplements.Models().FirstOrDefault(s => s.GetType().Name == supplementTypeName);

            var filteredRobots = robots.Models()
                .Where(r => r.InterfaceStandards
                    .All(i => i != supplement.InterfaceStandard) && r.Model == model);

            if (!filteredRobots.Any())
            {
                return string.Format(OutputMessages.AllModelsUpgraded, model);
            }

            IRobot robot = filteredRobots.First();
            robot.InstallSupplement(supplement);
            supplements.RemoveByName(supplementTypeName);

            return string.Format(OutputMessages.UpgradeSuccessful, model, supplementTypeName);
        }

        public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded)
        {
            var filteredRobots = robots.Models()
                .Where(r => r.InterfaceStandards
                    .Any(i => i == intefaceStandard));

            if (!filteredRobots.Any())
            {
                return string.Format(OutputMessages.UnableToPerform, intefaceStandard);
            }

            var orderedRobots = filteredRobots
                .OrderByDescending(r => r.BatteryLevel);

            int sumBatteryLevel = orderedRobots
                .Sum(r => r.BatteryLevel);

            int countRobots = 0;

            if (sumBatteryLevel < totalPowerNeeded)
            {
                return string.Format(OutputMessages.MorePowerNeeded, serviceName, totalPowerNeeded - sumBatteryLevel);
            }
            else if (sumBatteryLevel >= totalPowerNeeded)
            {
                foreach (var robot in orderedRobots)
                {
                    if (robot.BatteryLevel >= totalPowerNeeded)
                    {
                        robot.ExecuteService(totalPowerNeeded);
                        countRobots++;
                        break;
                    }
                    else if (robot.BatteryLevel < totalPowerNeeded)
                    {
                        totalPowerNeeded -= robot.BatteryLevel;
                        robot.ExecuteService(robot.BatteryLevel);
                        countRobots++;
                    }
                }
            }

            return string.Format(OutputMessages.PerformedSuccessfully, serviceName, countRobots);
        }

        public string RobotRecovery(string model, int minutes)
        {
            var filteredRobots = robots.Models()
                .Where(r => r.Model == model &&
                            r.BatteryLevel < r.BatteryCapacity / 2);

            int count = 0;
            foreach (var robot in filteredRobots)
            {
                robot.Eating(minutes);
                count++;
            }

            return string.Format(OutputMessages.RobotsFed, count);
        }

        public string Report()
        {
            var ordrededRobots = robots.Models()
                .OrderByDescending(r => r.BatteryLevel)
                .ThenBy(r => r.BatteryCapacity);

            StringBuilder sb = new();

            foreach (var robot in ordrededRobots)
            {
                sb.AppendLine(robot.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
