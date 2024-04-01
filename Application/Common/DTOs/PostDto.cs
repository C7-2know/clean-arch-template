using System;
using System.Collections.Generic;
using System.Text;
using BlogPost.Application.Common.DTOs.Common;

namespace BlogPost.Application.Common.DTOs;

public abstract class PostDto:BaseDto
{
    public int Text {get;set;}
    public int PostId {get;set;}

}