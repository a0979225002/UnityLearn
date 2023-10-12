using System;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

namespace Script.Global
{
    public class TimeData<T>
    {
        public float Time { get; set; }
        public T Data { get; set; }
    }

    public class Utils
    {
        public static TimeData<T> TestFunctionTime<T>(Func<T> a)
        {
            var sw = new Stopwatch();
            sw.Start();
            var b = a();
            sw.Stop();
            Debug.LogFormat("Time 測試 該方法執行時間 {0} ms", sw.Elapsed.TotalMilliseconds);
            return new TimeData<T>
            {
                Time = (float)sw.Elapsed.TotalMilliseconds,
                Data = b
            };
        }
    }
}