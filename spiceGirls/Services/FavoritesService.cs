using spiceGirls.Models;
using spiceGirls.Repositories;

namespace spiceGirls.Services
{
    public class FavoritesService
    {
        private readonly FavoritesRepository _favoritesRepo;

        public FavoritesService(FavoritesRepository favoritesRepo)
        {
            _favoritesRepo = favoritesRepo;
        }

        internal object Create(Favorite favoriteData)
        {
            return _favoritesRepo.Create(favoriteData);
        }
    }
}