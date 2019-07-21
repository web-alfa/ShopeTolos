using FluentScheduler;
using ShopeTolos.BackgroundService.WorkData;
using ShopeTolos.WorkData.BackgroundService;

namespace ShopeTolos.BackgroundService
{
    public class MyRegistry : Registry
    {
        public MyRegistry()
        {
            Schedule<UpdateDateShiping>().ToRunNow().AndEvery(7).Hours();
            Schedule<DataUpdatePriceShiping>().ToRunNow().AndEvery(2).Hours();
            Schedule<ConnectorAli>().ToRunNow().AndEvery(24).Hours();
        }
    }
}