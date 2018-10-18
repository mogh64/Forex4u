using FX.Core.Bsse;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using FX.Core.Entities;
using forex4u.Infrastructure;
using forex4u.Models;

namespace forex4u.Repositories
{

    public static class SeedData
    {

        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();
            
            if (!context.StockUsers.Any())
            {
                context.StockUsers.AddRange(
                    new StockUser
                    {
                        
                        FirstName = "admin",
                        LastName = "admin",
                        
                    }
                );
                context.SaveChanges();
            }
        }
    }

}
