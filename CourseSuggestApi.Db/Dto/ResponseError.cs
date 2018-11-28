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
            AlreadyVoted = -1
        }
        public string ErrorMessage
        { 
            get;
            set;
        }
    }
}
