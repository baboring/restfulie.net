﻿namespace Restfulie.Server.Results
{
    public class BadRequest : RestfulieResult
    {

        public BadRequest()
        {
        }

        public BadRequest(string message) : base(message)
        {
        }


        protected override int StatusCode
        {
            get { return (int) StatusCodes.BadRequest; }
        }
    }
}