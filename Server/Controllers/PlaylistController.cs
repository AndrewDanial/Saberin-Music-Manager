using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using music_manager_starter.Data;
using music_manager_starter.Data.Models;

namespace music_manager_starter.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistsController : ControllerBase
    {
        private readonly DataDbContext _context;

        public PlaylistsController(DataDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Playlist>>> GetPlaylists()
        {
            return await _context.Playlists.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Playlist>> PostPlaylists(Playlist playlist)
        {
            if (playlist == null)
            {
                return BadRequest("playlist cannot be null.");
            }


            _context.Playlists.Add(playlist);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{playlistId}")]
        public async Task<ActionResult<Playlist>> RemovePlaylist(Guid playlistId)
        {
            var playlist = await _context.Playlists.FindAsync(playlistId);
            Console.WriteLine(playlist);
            if (playlist == null)
            {
                return BadRequest("Playlist cannot be null.");
            }


            _context.Playlists.Remove(playlist);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
