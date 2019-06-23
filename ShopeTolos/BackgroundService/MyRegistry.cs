using FluentScheduler;
using ShopeTolos.WorkData.BackgroundService;

namespace ShopeTolos.BackgroundService
{
    public class MyRegistry : Registry
    {
        public MyRegistry()
        {
            Schedule<UpdateDateShiping>().ToRunEvery(1).Days().At(9, 13);
        }
    }
}