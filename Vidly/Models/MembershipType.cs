﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MembershipType
    {
        public byte MembershipTypeId { get; set; }
        public string Name { get; set; }
        public short SingUpFee { get; set; }
        public byte DurationinMonths { get; set; }
        public byte DiscountRate { get; set; }
    }
}