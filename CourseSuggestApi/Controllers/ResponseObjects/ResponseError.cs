using System;
namespace CourseSuggestApi.Controllers.ResponseObjects
{
    public class ResponseError
    {
        public enum ErrorCode: int {
            AlreadyVoted = -1
        }
        public string ErrorMessage
        {
            get;
            set;
        }
        public ErrorCode Code
        {
            get;
            set;
        }
        public ResponseError()
        {
        }
    }
}
