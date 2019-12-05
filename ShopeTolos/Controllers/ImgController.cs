using Microsoft.AspNetCore.Mvc;

namespace ShopeTolos.Controllers
{
    public class ImgController : ControllerBase
    {
        [HttpGet]
        [Route("Image")]
        public IActionResult GetShiping(string name)
        {
            var imageFileStream = System.IO.File.OpenRead($"{System.IO.Directory.GetCurrentDirectory()}/Img/{name}");
            return File(imageFileStream, "image/png");
        }
    }
}