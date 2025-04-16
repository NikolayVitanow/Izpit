using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class GamegenreContext : IDb<Gamegenre, int>
    {
        private GameDbContext dbContext;

        public GamegenreContext(GameDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(Gamegenre item)
        {
            List<Game> games = new List<Game>(item.Games.Count);
            foreach (Game game in item.Games)
            {
                Game gameFromDb = dbContext.Games.Find(game.GameId);
                if (gameFromDb != null) games.Add(gameFromDb);
                else games.Add(game);
            }

            item.Games = games;

            dbContext.Genres.Add(item);
            dbContext.SaveChanges();
        }

        public void Delete(int key)
        {
            Gamegenre genreFromDb = Read(key);
            dbContext.Genres.Remove(genreFromDb);
            dbContext.SaveChanges();
        }

        public Gamegenre Read(int key, bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            IQueryable<Gamegenre> query = dbContext.Genres;

            if (useNavigationalProperties)
                query = query.Include(g => g.Games);

            if (isReadOnly)
                query = query.AsNoTrackingWithIdentityResolution();

            Gamegenre genre = query.FirstOrDefault(g => g.GenreId == key);

            if (genre == null)
                throw new ArgumentException($"Genre with ID = {key} does not exist!");

            return genre;
        }

        public List<Gamegenre> ReadAll(bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            IQueryable<Gamegenre> query = dbContext.Genres;

            if (useNavigationalProperties)
                query = query.Include(g => g.Games);

            if (isReadOnly)
                query = query.AsNoTrackingWithIdentityResolution();

            return query.ToList();
        }

        public void Update(Gamegenre item, bool useNavigationalProperties = false)
        {


            List<Game> games = new List<Game>(item.Games.Count);
            foreach (Game game in item.Games)
            {
                Game gameFromDb = dbContext.Games.Find(game.GameId);
                if (gameFromDb != null) games.Add(gameFromDb);
                else games.Add(game);
            }

            item.Games = games;

            dbContext.Genres.Update(item);
            dbContext.SaveChanges();
        }
    }
}
