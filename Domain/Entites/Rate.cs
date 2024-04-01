using BlogPost.Domain.Common;
using System;
using System.Collections.Generic;
using System.Threading;

namespace BlogPost.Domain.Entities
{ 
    public class Rate : BaseDomainEntity
    {
        public int Value {get;set;}
        public int PostId {get;set;}

    }
}

