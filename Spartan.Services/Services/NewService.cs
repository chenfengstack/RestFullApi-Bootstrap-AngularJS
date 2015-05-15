using System;
using System.Collections.Generic;
using System.Linq;
using Spartan.Model.DbContext;
using Spartan.Model.Models;
using Spartan.Services.Base;
using Spartan.Services.Interface;

namespace Spartan.Services.Services
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class NewService : INewService
    {
        private readonly SpartanDB _db;
        public NewService(SpartanDB db)
        {
            this._db = db;
        }


        public IEnumerable<News> GetAllNews()
        {
            var query = _db.News.Include("NewType").AsQueryable();
            return query;
        }

        public News GetNew(int newId)
        {
            var query = _db.News.Include("NewType").SingleOrDefault(_ => _.Id == newId);
            return query;
        }

        public IEnumerable<News> GetNewsByName(string newName)
        {
            var query = _db.News.Include("NewType").Where(_ => _.NewName == newName);
            return query;
        }

        public bool CreateNew(News model)
        {
            try
            {
                _db.News.Add(model);
                return true;
            }
            catch
            {
                //TODO logging
                return false;
            }
        }

        public bool UpdateNew(News oldModel, News model)
        {
            try
            {
                _db.Entry(oldModel).CurrentValues.SetValues(model);
                return true;
            }
            catch
            {
                //TODO logging
                return false;
            }
        }

        public bool UpdateNewState(News oldModel, int state)
        {
            try
            {
                _db.Entry(oldModel).Entity.State = state;
                return true;
            }
            catch
            {
                //TODO logging
                return false;
            }
        }

        public bool DeleteNew(News model)
        {
            try
            {
                _db.News.Remove(model);
                return true;
            }
            catch (Exception)
            {
                //TODO logging
                return false;
            }
        }

        public bool SaveAll()
        {
            try
            {
                _db.SaveChanges();
                return true;
            }
            catch
            {
                //TODO logging
                return false;
            }
        }


        public NewType GetNewType(int newTypeId)
        {
            var query = _db.NewTypes.Find(newTypeId);
            return query;
        }
    }
}
