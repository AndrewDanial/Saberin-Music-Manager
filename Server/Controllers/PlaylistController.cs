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
            var playlists = await _context.Playlists
                .Include(p => p.Songs).ToListAsync();
            playlists = playlists.OrderBy(p => p.CreatedAt).ToList();
            foreach (var p in playlists)
            {
                Console.WriteLine(p.CreatedAt);
            }
            return playlists;
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
            if (playlist == null)
            {
                return BadRequest("Playlist cannot be null.");
            }


            _context.Playlists.Remove(playlist);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{playlistId}")]
        public async Task<ActionResult<Playlist>> ReplacePlaylist(Guid playlistId, [FromBody] Playlist newPlaylist)
        {
            var playlist = await _context.Playlists.Include(p => p.Songs).FirstOrDefaultAsync(p => p.Id == playlistId);
            if (playlist == null)
            {
                return BadRequest("Playlist cannot be null.");
            }

            playlist.Title = newPlaylist.Title;

            if (playlist.Songs != null)
                playlist.Songs.Clear();
            else
                playlist.Songs = [];

            if (newPlaylist.Songs != null)
            {
                foreach (var song in newPlaylist.Songs)
                {
                    var existingSong = await _context.Songs.FindAsync(song.Id);
                    if (existingSong != null)
                    {
                        playlist.Songs.Add(existingSong);
                    }
                }
            }

            await _context.SaveChangesAsync();
            return BadRequest(playlist);
            return Ok(playlist);
        }
    }
}
