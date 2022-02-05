using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibraryService.WebAPI.Data;
using LibraryService.WebAPI.Services;
using System;

namespace LibraryService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class LibrariesController : ControllerBase
    {
        private readonly ILibrariesService _librariesrepository;

        public LibrariesController(ILibrariesService librariesrepository)
        {
            _librariesrepository = librariesrepository;
        }

        [HttpDelete("{library}")]
        public async Task<ActionResult> Delete(int[] ids)
        {
            var DeleteLibrary = await _librariesrepository.Get(ids);
            if (DeleteLibrary == null)
            {
                return NotFound();
            }

            await _librariesrepository.Delete(DeleteLibrary.FirstOrDefault());
            return NoContent();
        }
    }
}
