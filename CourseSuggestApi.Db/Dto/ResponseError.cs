using System;
namespace CourseSuggestApi.Db.Dto
{
    public class ResponseError
    {
        public ResponseError()
        {
        }

        public ErrorCode Code
        {
            get;
            set;
        }

        public enum ErrorCode : int
        {
            AlreadyVoted = -1,
            PostObjectMalformed = -2,
            AuthorDetailsMissing = -3
        }
        public string ErrorMessage
        { 
            get;
            set;
        }
    }
}
