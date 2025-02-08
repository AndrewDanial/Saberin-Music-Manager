namespace music_manager_starter.Data.Models
{
    public sealed class Playlist
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public ICollection<Song>? Songs { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
