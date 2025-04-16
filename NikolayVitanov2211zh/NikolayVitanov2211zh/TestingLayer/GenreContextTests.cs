using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using Org.BouncyCastle.Asn1.Cmp;
using NUnit.Framework;


namespace TestingLayer
{
    public class GenreContextTests
    {
        static GamegenreContext genresContext;
        static GenreContextTests() { genresContext = new GamegenreContext(TestManager.dbContext); }

        [Test]
        public void CreateGenre()
        {

            Gamegenre genre = new Gamegenre(1, "mmo");
            int genresBefore = TestManager.dbContext.Genres.Count();

            // Act
            genresContext.Create(genre);

            // Assert
            int genresAfter = TestManager.dbContext.Genres.Count();
            Gamegenre lastGenre = TestManager.dbContext.Genres.Last();
            Assert.That(genresBefore + 1 == genresAfter && lastGenre.Title == genre.Title,
                "Names are not equal or genre is not created!");
        }
        [Test]
        public void ReadGenre()
        {
            Gamegenre newGenre = new Gamegenre(1, "mmo");
            genresContext.Create(newGenre);

            Gamegenre genre = genresContext.Read(1);

            Assert.That(genre.Title == "mmo", "Read() does not get Genre by id!");
        }
        [Test]
        public void ReadAllGenres()
        {
            int genresBefore = TestManager.dbContext.Genres.Count();

            int genresAfter = genresContext.ReadAll().Count;

            Assert.That(genresBefore == genresAfter, "ReadAll() does not return all of the Genres!");
        }
        [Test]
        public void UpdateGenre()
        {
            Gamegenre newGenre = new Gamegenre(1, "shooter");
            genresContext.Create(newGenre);

            Gamegenre lastGenre = genresContext.ReadAll().Last();
            lastGenre.Title = "Updated Genre";

            genresContext.Update(lastGenre, false);

            Assert.That(genresContext.Read(lastGenre.GenreId).Title == "Updated Genre",
            "Update() does not change the Genre's name!");
        }
        [Test]
        public void DeleteGenre()
        {
            Gamegenre newGenre = new Gamegenre(1, "shooter");
            genresContext.Create(newGenre);

            List<Gamegenre> genres = genresContext.ReadAll();
            int genresBefore = genres.Count;
            Gamegenre genre = genres.Last();

            genresContext.Delete(genre.GenreId);

            int genresAfter = genresContext.ReadAll().Count;
            Assert.That(genresBefore == genresAfter + 1, "Delete() does not delete a genre!");
        }
    }
}
