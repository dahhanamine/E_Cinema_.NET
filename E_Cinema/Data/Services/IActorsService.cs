﻿using E_Cinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Cinema.Data.Services
{
    public interface IActorsService
    {

        Task<IEnumerable<Actor>> GetAllAsync();

        Task<Actor> GetByIdAsync(int id);

        Task AddAsync(Actor actor);

        Actor Update(int id, Actor newActor);

        void Delete(int id);

    }
}