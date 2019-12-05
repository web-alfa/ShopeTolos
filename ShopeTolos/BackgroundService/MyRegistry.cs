using FluentScheduler;
using ShopeTolos.BackgroundService.WorkData;
using ShopeTolos.WorkData.BackgroundService;

namespace ShopeTolos.BackgroundService
{
    public class MyRegistry : Registry
    {
        public MyRegistry()
        {
            Schedule<UpdateDateShiping>().ToRunEvery(1).Days().At(00, 00);
            Schedule<DataUpdatePriceShiping>().ToRunEvery(1).Days().At(4, 00);
            Schedule<InitShopNew>().ToRunNow().AndEvery(2).Hours();
            Schedule<ConnectorAli>().ToRunNow().AndEvery(6).Hours();
        }
    }
}