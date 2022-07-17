using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityInfo.Controllers
{
    [Route("api/files")]
    [ApiController]
    public class FilesController : Controller
    {
        private readonly FileExtensionContentTypeProvider _fileExtensionContentTypeProvider;

        public FilesController(FileExtensionContentTypeProvider fileExtensionContentTypeProvider)
        {
            _fileExtensionContentTypeProvider = fileExtensionContentTypeProvider ?? throw new ArgumentNullException(nameof(fileExtensionContentTypeProvider));
        }

        [HttpGet("{fileId}")]
        public ActionResult<string> GetFile(string fileId)
        {
            var path = "getting-started-with-rest-slides.pdf";
            if (!System.IO.File.Exists(path))
            {
                return NotFound();
            }
            if (!_fileExtensionContentTypeProvider.TryGetContentType(path, out var contentType))
            {
                // arbitrary binery data
                contentType = "application/octet-steam";
            }
            var bytes = System.IO.File.ReadAllBytes(path);
            //return File(bytes, "text/plain", Path.GetFileName(path));
            return File(bytes, contentType, Path.GetFileName(path));
        }

    }
}

