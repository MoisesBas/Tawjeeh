﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tawjeeh.Api.Models
{
    public class VerifyOTPViewModel
    {
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string OTP { get; set; }
    }
}