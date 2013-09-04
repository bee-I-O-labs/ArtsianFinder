using System;
using System.Collections.Generic;
using ArtisansFinder.Models;
using ServiceStack.Common;
using ServiceStack.OrmLite;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.ServiceModel;

namespace ArtisansFinder.ServiceInterface
{
    public class Jobs
    {
        public int[] JobIds { get; set; }
    }

    public class JobsResponse : IHasResponseStatus
    {
        public JobsResponse()
        {
            this.ResponseStatus = new ResponseStatus();
        }

        public List<JobInfo> Results { get; set; }

        public ResponseStatus ResponseStatus { get; set; }
    }

    public class JobService : Service
    {
        public object Get(Jobs request)
        {
            var response = new JobsResponse();

            if (request.JobIds.Length == 0)
                return response;

            var jobs = Db.Ids<Jobs>(request.JobIds);

            var jobInfos = jobs.ConvertAll(x => x.TranslateTo<JobInfo>());

            return new JobsResponse
            {
                Results = jobInfos
            };
        }
    }

    public class JobInfo
    {
        public int Id { get; set; }
        public int ArtisanId { get; set; }
        public string JobType { get; set; }
    }
}