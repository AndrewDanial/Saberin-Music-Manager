namespace music_manager_starter.Data.Models
{
    public sealed class Playlist
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required List<Song> Songs { get; set; }
    }
}
