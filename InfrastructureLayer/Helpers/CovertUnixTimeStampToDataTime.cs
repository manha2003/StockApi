using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Helpers
{
    public class CovertUnixTimeStampToDataTime
    {
        public static DateTime ConvertUnixTimestampToDateTime(long timestamp)
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(timestamp);
            return dateTimeOffset.LocalDateTime;
        }
    }
}
