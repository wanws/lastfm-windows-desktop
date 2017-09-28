﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastFM.ApiClient.Enums
{
    public static class ReasonCodes
    {
        public enum IgnoredReason
        {
            AllOk = 0,
            ArtistIgnored = 1,
            TrackIgnored = 2,
            TimestampTooOld = 3,
            TimestampTooNew = 4,
            ScrobbleLimitExceeded = 5
        }
    }
}