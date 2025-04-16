using System;
using System.Collections.Generic;


namespace DataLayer;

public partial class Game
{
    public int GameId { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Gamegenre> Genres { get; set; } = new List<Gamegenre>();

    public virtual ICollection<Potrebitel> Users { get; set; } = new List<Potrebitel>();

	private Game()
	{
	}

	public Game(int id, string title, ICollection<Gamegenre> genres, ICollection<Potrebitel> users)
	{
		GameId = id;
		Title = title;
		Genres = new List<Gamegenre>();
		Users = new List<Potrebitel>();
	}
}
