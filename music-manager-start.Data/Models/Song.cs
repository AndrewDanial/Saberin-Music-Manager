namespace music_manager_starter.Data.Models
{
    public sealed class Song
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Artist { get; set; }
        public required string Album { get; set; }
        public required string Genre { get; set; }
    }
}
