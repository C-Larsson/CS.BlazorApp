namespace SocialApp.Server.Constants
{
    /// <summary>
    /// 
    /// </summary>
    public static class SeriesType
    {

        /// <summary>
        /// 
        /// </summary>
        public const int Weekly = 1;

        /// <summary>
        /// 
        /// </summary>
        public const int Monthly = 2;

        /// <summary>
        /// 
        /// </summary>
        public const int Yearly = 3;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="seriesType"></param>
        /// <returns></returns>
        public static string ToString(int seriesType)
        {
            return seriesType switch
            {
                1 => "Weekly",
                2 => "Monthly",
                3 => "Yearly",
                _ => "Unknown"
            };
        }


    }
}
