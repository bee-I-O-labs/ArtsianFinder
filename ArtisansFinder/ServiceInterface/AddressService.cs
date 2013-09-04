using System.Collections.Generic;
using ServiceStack.Common;
using ServiceStack.OrmLite;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.ServiceModel;

namespace ArtisansFinder.ServiceInterface
{
    public class Addresses
    {
        public int[] AddressIds { get; set; }
    }

    public class AddressesResponse : IHasResponseStatus
    {
        public AddressesResponse()
        {
            this.ResponseStatus = new ResponseStatus();
        }

        public List<AddressInfo> Results { get; set; }

        public ResponseStatus ResponseStatus { get; set; }
    }

    public class AddressService : Service
    {
        public object Get(Addresses request)
        {
            var response = new JobsResponse();

            if (request.AddressIds.Length == 0)
                return response;

            var addresses = Db.Ids<Addresses>(request.AddressIds);

            var addressInfos = addresses.ConvertAll(x => x.TranslateTo<AddressInfo>());

            return new AddressesResponse
            {
                Results = addressInfos
            };
        }
    }

    public class AddressInfo
    {
        public int Id { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Town { get; set; }
        public int ArtisanId { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}