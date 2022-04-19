using SimpleMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleMVC.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDBContext context)
        {
            context.Database.EnsureCreated();

            if (context.Classifications.Any())
            {
                return;   // DB has been seeded
            }

            var classifications = new Classification[]
            {
            new Classification{ Name = "Question\\Inquiry"},
            new Classification{ Name = "Software Issue"},
            new Classification{ Name = "Hardware Issue"},
            };
            foreach (var c  in classifications)
            {
                context.Classifications.Add(c);
            }
            context.SaveChanges();


        }
    }
}