﻿using E_Cinema.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Cinema.Data
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options ): base(options)
        {

        }

       /* protected override void onModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_Movie>().HasKey(am => new 
            {
                am.ActorId ,
                am.MovieId 
            });
            base.OnModelCreating(modelBuilder);
        }*/
    }
}
