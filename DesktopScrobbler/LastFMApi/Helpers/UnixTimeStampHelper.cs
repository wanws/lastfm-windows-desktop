﻿using System;

namespace LastFM.Common.Helpers
{
    public static class UnixTimeStampHelper
    {
        public static DateTime GetDateTimeFromUnixTimestamp(string unixTimeStamp)
        {
            var convertedDate = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);

            double timeStampSeconds = 0;

            if (double.TryParse(unixTimeStamp, out timeStampSeconds))
            {
                convertedDate = convertedDate.AddSeconds(timeStampSeconds);
            }

            return convertedDate;
        }

        public static Int32 GetUnixTimeStampFromDateTime(DateTime timeToconvert)
        {
            return (Int32)(timeToconvert.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }
    }
}
