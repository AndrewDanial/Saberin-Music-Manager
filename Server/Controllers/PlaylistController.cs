using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using music_manager_starter.Data;
using music_manager_starter.Data.Models;
using System;

namespace music_manager_starter.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        private readonly DataDbContext _context;

        public PlaylistController(DataDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Song>>> GetSongs()
        {
            return await _context.Songs.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Song>> PostSong(Song song)
        {
            if (song == null)
            {
                return BadRequest("Song cannot be null.");
            }


            _context.Songs.Add(song);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{song_id}")]
        public async Task<ActionResult<Song>> RemoveSong(Guid song_id)
        {
            var song = await _context.Songs.FindAsync(song_id);
            if (song == null)
            {
                return BadRequest("Song cannot be null.");
            }


            _context.Songs.Remove(song);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
