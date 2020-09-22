namespace WebApplication1.Repositories
{
    public class ConnectionHelper
    {
        /// <summary>
        /// 連線字串
        /// </summary>
        private static string _connectionStr = @"Server=localhost;Database=Northwind;Trusted_Connection=True;";

        /// <summary>
        /// 資料庫連線
        /// </summary>
        public static string ConnectionStr { get { return _connectionStr; } }
    }
}