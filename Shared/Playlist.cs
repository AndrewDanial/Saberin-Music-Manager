namespace music_manager_starter.Shared
{
    public sealed class Playlist
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public List<Song> Songs { get; set; }
    }
}
