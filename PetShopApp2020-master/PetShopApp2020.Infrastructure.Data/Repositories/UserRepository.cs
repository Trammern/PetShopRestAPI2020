﻿using Microsoft.EntityFrameworkCore;
using PetShopApp.Core.DomainServices;
using PetShopApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShopApp2020.Infrastructure.Data.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly PetShopAppContext db;

        public UserRepository(PetShopAppContext context)
        {
            db = context;
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users.ToList();
        }

        public User Get(long id)
        {
            return db.Users.FirstOrDefault(b => b.Id == id);
        }

        public void Add(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
        }

        public void Edit(User entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Remove(long id)
        {
            var item = db.Users.FirstOrDefault(b => b.Id == id);
            db.Users.Remove(item);
            db.SaveChanges();
        }
    }
}
