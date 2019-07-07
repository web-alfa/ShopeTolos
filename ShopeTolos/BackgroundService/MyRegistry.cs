using FluentScheduler;
using ShopeTolos.BackgroundService.WorkData;
using ShopeTolos.WorkData.BackgroundService;

namespace ShopeTolos.BackgroundService
{
    public class MyRegistry : Registry
    {
        public MyRegistry()
        {
            Schedule<UpdateDateShiping>().ToRunEvery(1).Days().At(4, 14);
            Schedule<ConnectorAli>().ToRunEvery(1).Days().At(4, 18);
        }
    }
}