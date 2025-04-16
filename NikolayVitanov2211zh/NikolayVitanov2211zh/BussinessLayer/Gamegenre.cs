using System;
using System.Collections.Generic;

namespace DataLayer;

public partial class Gamegenre
{
    public int GenreId { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Game> Games { get; set; } = new List<Game>();

	private Gamegenre()
	{
	}

	public Gamegenre(int id, string title)
	{
		GenreId = id;
		Title = title;
		Games = new List<Game>();
	}
}
