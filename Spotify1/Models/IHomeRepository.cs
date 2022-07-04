namespace Spotify1.Models
{
    public interface IHomeRepository
    {
        bool AddNewArtist(Home artists);
        List<Home> GetArtist();
        bool AddNewSong(Home songs);
    }
}
