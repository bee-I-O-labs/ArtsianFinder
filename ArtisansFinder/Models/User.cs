using System;
using System.Collections.Generic;
using ServiceStack.DataAnnotations;

namespace ArtisansFinder.Models
{
    /// <summary>
	/// Custom User DataModel for harvesting UserAuth info into your own DB table
	/// </summary>  
	
    public enum PhoneType {
        Home,
        Work,
        Mobile,
    }
    public enum AddressType {
        Home,
        Work,
        Other,
    }
    public class Address {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Town { get; set; }
    }
    public class ArtisanAddress : Address
    {
        [AutoIncrement] // Creates Auto primary key
        public int Id { get; set; }

        [References(typeof(Artisan))]      //Creates Foreign Key
        public int ArtisanId { get; set; }

        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
	public class User  
	{
        public User()
        {
            this.PhoneNumbers = new Dictionary<PhoneType, string>();
            this.Address = new Address();
        }
		public int Id { get; set; }
		public string Email { get; set; }
        public Dictionary<PhoneType, string> PhoneNumbers { get; private set; }  //Blobbed
        public Address Address { get; private set; }  //Blobbed
		public string UserName { get; set; }
		public string DisplayName { get; set; }
		public string TwitterUserId { get; set; }
		public string TwitterScreenName { get; set; }
		public string TwitterName { get; set; }
		public string FacebookName { get; set; }
		public string FacebookFirstName { get; set; }
		public string FacebookLastName { get; set; }
		public string FacebookUserId { get; set; }
		public string FacebookUserName { get; set; }
		public string FacebookEmail { get; set; }
        public string GoogleUserId { get; set; }
        public string GoogleFullName { get; set; }
        public string GoogleEmail { get; set; }
        public string YahooUserId { get; set; }
        public string YahooFullName { get; set; }
        public string YahooEmail { get; set; }
        public string GravatarImageUrl64 { get; set; }
	    public string SecurityQuestion { get; set; }
	    public string SecurityAnswer { get; set; }
	}

    public class Job
    {
        [AutoIncrement]
        public int Id { get; set; }

        [References(typeof(Artisan))]
        public int ArtisanId { get; set; }
        public string JobType { get; set; }

    }
    public class Artisan
    {
        public Artisan()
        {
            this.Address = new Address();
            this.PhoneNumbers = new Dictionary<PhoneType, string>();
        }
        
        public Dictionary<PhoneType,string> PhoneNumbers { get; set; }
        [AutoIncrement] // Creates Auto primary key
        public int Id { get; set; }

        public Address Address { get; private set; }  //Blobbed

        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string CpcRegistrationNumber { get; set; }
        public bool IsRegistered { get; set; }
        public string WorkingHours { get; set; }
        public DateTime CreatedAt { get; set; }
        public string AreaOfSpecialization { get; set; }
        
//        [References(typeof(Job))]      //Creates Foreign Key
//        public int JobId { get; set; }

        public int YearsOfExperience { get; set; }
        public string ImageUrl { get; set; }
    }
    public class Feedback : FavoriteArtisan
    {
        public string Comment { get; set; }
    }
    public class FavoriteArtisan
    {
        [References(typeof(Artisan))]
        public int ArtisanId { get; set; }

        [AutoIncrement]
        public int Id { get; set; }

        [References(typeof(User))]
        public int UserId { get; set; }
    }
}


