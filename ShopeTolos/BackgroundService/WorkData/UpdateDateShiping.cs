using FluentScheduler;
using ShopeTolos.BackgroundService.WorkData;

namespace ShopeTolos.WorkData.BackgroundService
{
    public class UpdateDateShiping : IJob
    {
        private ManagerData managerData = null;

        public async void Execute()
        {
            managerData = new ManagerData();
            await managerData.StartService();
        }
    }
}