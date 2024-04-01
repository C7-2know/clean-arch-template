using System;
using System.Collections.Generic;
using BlogPost.Application.Common.DTOs.Common;

namespace BlogPost.Application.Common.DTOs.Rate;

public class UpdateRateDTO :BaseDto
{
    public int Value { get; set; }
    
}

