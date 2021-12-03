using E_Cinema.Data.Base;
using E_Cinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Cinema.Data.Services
{
    public class CinemasService:EntityBaseRepository<Cinema> ,  ICinemasService
    {
        public CinemasService(AppDbContext context) : base(context) { }
}
}
