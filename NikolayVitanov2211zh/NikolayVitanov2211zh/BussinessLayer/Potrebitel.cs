using System;
using System.Collections.Generic;

namespace DataLayer;

public partial class Potrebitel
{
    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int Age { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Potrebitel> Friends { get; set; } = new List<Potrebitel>();

    public virtual ICollection<Game> Games { get; set; } = new List<Game>();

    public virtual ICollection<Potrebitel> Users { get; set; } = new List<Potrebitel>();

	private Potrebitel()
	{
	}

	public Potrebitel(int id, string firstName, string lastName, int age, string username, string password, string email)
	{
		UserId = id;
		FirstName = firstName;
		LastName = lastName;
		Age = age;
		Username = username;
		Password = password;
		Email = email;
		Friends = new List<Potrebitel>();
		Games = new List<Game>();
		Users = new List<Potrebitel>();
	}
}
