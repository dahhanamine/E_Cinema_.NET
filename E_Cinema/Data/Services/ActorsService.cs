using E_Cinema.Data.Base;
using E_Cinema.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Cinema.Data.Services
{
    public class ActorsService : EntityBaseRepository<Actor> ,  IActorsService
    {
        public ActorsService(AppDbContext context) : base(context) { }
      
       
    }
}
