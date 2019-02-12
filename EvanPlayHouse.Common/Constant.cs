using System;
namespace EvanPlayHouse.Common
{
    public static class Constant
    {
        #region API

        public const long SpeculativeLimit = 1048576 * 5;/*MB*/
        public const string BaseEndpoint = "http://whatever.com";
        public const string ApiEndpoint = BaseEndpoint + "/api";
        public static TimeSpan ApiTimeout = TimeSpan.FromMinutes(3);
        public const int MaxRetries = 3;
        public const string AppName = "EvanPlayHouse";

        #endregion
    }
}
