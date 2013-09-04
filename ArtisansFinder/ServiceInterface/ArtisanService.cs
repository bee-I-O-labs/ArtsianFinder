using System;
using System.Collections.Generic;
using ArtisansFinder.Models;
using ServiceStack.Common;
using ServiceStack.OrmLite;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.ServiceModel;

namespace ArtisansFinder.ServiceInterface
{
    public class Artisans
    {
        public int[] ArtisanIds { get; set; }
    }

    public class ArtisansResponse : IHasResponseStatus
    {
        public ArtisansResponse()
        {
            this.ResponseStatus = new ResponseStatus();
        }

        public List<ArtisanInfo> Results { get; set; }

        public ResponseStatus ResponseStatus { get; set; }
    }

    public class ArtisanService : Service
    {
        public object Get(Artisans request)
        {
            var response = new ArtisansResponse();

            if (request.ArtisanIds.Length == 0)
                return response;

            var artisans = Db.Ids<Artisans>(request.ArtisanIds);

            var artisanInfos = artisans.ConvertAll(x => x.TranslateTo<ArtisanInfo>());

            return new ArtisansResponse
            {
                Results = artisanInfos
            };
        }
    }

    public class ArtisanInfo
    {
        public ArtisanInfo()
        {
            this.Address = new Address();
            this.PhoneNumbers = new Dictionary<PhoneType, string>();
        }
        public int Id { get; set; }
        public Dictionary<PhoneType, string> PhoneNumbers { get; set; }
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
        public int YearsOfExperience { get; set; }
        public string ProfileImageUrl64 { get; set; }
    }
}