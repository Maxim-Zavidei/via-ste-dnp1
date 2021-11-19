using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebAPI.Models;
using WebAPI.Persistence;

namespace WebAPI {
    public class Program {
        public static void Main(string[] args) {
            using (AdultContext adultContext = new AdultContext())
            {
                if (!adultContext.Adults.Any())
                {
                    Seed(adultContext);
                }
            }
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        
        private static void Seed(AdultContext adultContext) {
            var Adult1 = new Adult() {
                Id = 1, 
                FirstName = "gsfd", 
                LastName = "fgsdgfsd",
                HairColor = "gsdfgsd",
                EyeColor = "fgnf", 
                Age = 23, 
                Weight = 54, 
                Height = 234, 
                Sex = "M" 
            };
            adultContext.Add(Adult1);
            var Adult2 = new Adult() {
                Id = 2, 
                FirstName = "sgdf", 
                LastName = "fccb",
                HairColor = "xcvb",
                EyeColor = "fxbvc", 
                Age = 233, 
                Weight = 554, 
                Height = 234, 
                Sex = "M" 
            };
            adultContext.Add(Adult2);
            var Adult3 = new Adult() {
                Id = 3, 
                FirstName = "sgdfxcvb", 
                LastName = "fccbbc",
                HairColor = "xcvbc",
                EyeColor = "fxbvcb", 
                Age = 26, 
                Weight = 10, 
                Height = 234, 
                Sex = "F" 
            };
            adultContext.Add(Adult3);
            adultContext.SaveChanges();
        }
    }
}