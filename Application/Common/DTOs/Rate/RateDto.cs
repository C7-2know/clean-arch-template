using System;
using System.Collections.Generic;
using System.Text;
using BlogPost.Application.Common.DTOs.Common;

namespace BlogPost.Application.Common.DTOs.Rate;

public abstract class RateDto:BaseDto
{
    public int Value {get;set;}
    public int PostId {get;set;}

}