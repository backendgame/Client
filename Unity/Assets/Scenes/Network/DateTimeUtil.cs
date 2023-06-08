using UnityEngine;
using System;

public static class DateTimeUtil {
	public const long A_DAY_MILISECONT = 86400000;

    private static DateTime dateTime1970 = System.DateTime.MinValue;
    public static long currentUtcTimeMilliseconds { 
		get {
			if(dateTime1970 == DateTime.MinValue)
				dateTime1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
			return (long)(DateTime.UtcNow - dateTime1970).TotalMilliseconds;
			//return DateTime.UtcNow.GetCurrentUtcTimeMillisecondsAtTime();
		}
	}
	public static long getTimeMili(DateTime _dateTime){
		if(dateTime1970 == DateTime.MinValue)
			dateTime1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
		return (long)(_dateTime - dateTime1970).TotalMilliseconds;
	}
	// public static long GetCurrentUtcTimeMillisecondsAtTime(this DateTime _dateTime) { 
    //     if(dateTime1970 == DateTime.MinValue){
    //         dateTime1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    //     }
	// 	long _value = (long)(_dateTime - dateTime1970).TotalMilliseconds;
	// 	return _value;
	// }
	public static DateTime ParseToUtcTime(long _currentMilliseconds){
		return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(_currentMilliseconds);
	}
	public static DateTime EndOfDay(this DateTime _dateTime){
        return _dateTime.Date.AddDays(1).AddTicks(-1);
    }

	public static System.DateTime GetDateTimeAdd(long miliAdd){
		return new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc).AddMilliseconds(miliAdd + currentUtcTimeMilliseconds);
	}
}
