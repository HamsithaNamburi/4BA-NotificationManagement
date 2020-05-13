using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace UserManagement
{
    //public class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
    //        try
    //        {
    //            logger.Debug("init main function");
    //            CreateWebHostBuilder(args).Build().Run();
    //        }
    //        catch (Exception ex)
    //        {
    //            logger.Error(ex, "Error in init");
    //            throw;
    //        }
    //        finally
    //        {
    //            NLog.LogManager.Shutdown();
    //        }
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

        }


    
        //public static IHostBuilder CreateWebHostBuilder(string[] args) =>



        //Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //    webBuilder.UseStartup<Startup>()
        //    .ConfigureLogging((hostingContext, logging) =>
        //    {
        //        logging.AddLog4Net();
        //        logging.SetMinimumLevel(LogLevel.Debug);
        //    });
        //});
        public static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();

                });

    }
}
