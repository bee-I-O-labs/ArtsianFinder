using System;
using System.Collections.Generic;
using ArtisansFinder.Models;
using ServiceStack.Common;
using ServiceStack.OrmLite;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.ServiceModel;

namespace ArtisansFinder.ServiceInterface
{
    public class Feedbacks
    {
        public int[] FeedbackIds { get; set; }
    }

    public class FeedbacksResponse : IHasResponseStatus
    {
        public FeedbacksResponse()
        {
            this.ResponseStatus = new ResponseStatus();
        }

        public List<FeedbackInfo> Results { get; set; }

        public ResponseStatus ResponseStatus { get; set; }
    }

    public class FeedbackService : Service
    {
        public object Get(Feedbacks request)
        {
            var response = new FeedbacksResponse();

            if (request.FeedbackIds.Length == 0)
                return response;

            var feedbacks = Db.Ids<Feedbacks>(request.FeedbackIds);

            var feedbackInfos = feedbacks.ConvertAll(x => x.TranslateTo<FeedbackInfo>());

            return new FeedbacksResponse
            {
                Results = feedbackInfos
            };
        }
    }

    public class FeedbackInfo
    {
        public int Id { get; set; }
        public int ArtisanId { get; set; }
        public string JobType { get; set; }
    }
}