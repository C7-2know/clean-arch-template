using System;
using System.Collections.Generic;
using System.Text;

namespace BlogPost.Application.Common.Exceptions;

public class BadRequestException : ApplicationException
{
    public BadRequestException(string message) : base(message)
    {

    }
}

