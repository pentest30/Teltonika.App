namespace Teltonika.Core
{
    public class AppSettings
    {
        /// <summary>
        /// 
        /// </summary>
        public string ConnectionString { get; set; }
        public ServerConfig ServerConfig { get; set; }
    }

    public class ServerConfig
    {
        public int Port { get; set; }
    }


   
}
