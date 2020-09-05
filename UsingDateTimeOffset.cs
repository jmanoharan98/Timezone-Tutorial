using System;
					
public class Program
{
	public static void Main()
	{
		TimeZone localZone = TimeZone.CurrentTimeZone;
		Console.WriteLine("Local Timezone - {0}", localZone.StandardName);
		
		//Current Time
		DateTime localDateTime = DateTime.Now;
		Console.WriteLine("Local DateTime - {0}", localDateTime);
		
		DateTimeOffset localTimeWithOffset = new DateTimeOffset(localDateTime);
		Console.WriteLine("Local Time with offset - {0}", localTimeWithOffset);
		
		//Convert local to Pacific Time
		TimeZoneInfo pstTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
		DateTimeOffset pacificTimeWithOffset = localTimeWithOffset.ToOffset(pstTimeZone.GetUtcOffset(localTimeWithOffset));
		Console.WriteLine("Pacific Time with offset - {0}", pacificTimeWithOffset);
		
		//Convert Pacific to Central Time
		TimeZoneInfo cstTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
		DateTimeOffset centralTimeWithOffset = pacificTimeWithOffset.ToOffset(cstTimeZone.GetUtcOffset(pacificTimeWithOffset));
		Console.WriteLine("Central Time with offset - {0}", centralTimeWithOffset);

		//Convert DateTimeOffset to UTC
		DateTimeOffset utcTimeWithOffset = centralTimeWithOffset.ToUniversalTime();
		Console.WriteLine("Central time to UTC with offset - {0}", utcTimeWithOffset);

		//Convert DateTimeOffset to Epoch
		long epoch = centralTimeWithOffset.ToUnixTimeMilliseconds();
		Console.WriteLine("Central time To epoch millis - {0}", epoch);
		long epochSeconds = centralTimeWithOffset.ToUnixTimeSeconds();
		Console.WriteLine("Central time To epoch seconds - {0}", epochSeconds);
		
		//Convert DateTimeOffset to DateTime
		DateTime utcDateTime = centralTimeWithOffset.UtcDateTime;
		Console.WriteLine("Central time To UTC DateTime - {0}", utcDateTime);
		DateTime centralDateTime = centralTimeWithOffset.DateTime;
		Console.WriteLine("Central time To DateTime - {0}", centralDateTime);
	}
}
