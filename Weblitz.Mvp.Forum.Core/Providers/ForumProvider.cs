using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;

namespace Weblitz.Mvp.Forum.Core.Providers
{
    public class ForumProvider : IForumProvider
    {
        private readonly DataContext _dataContext;
        private readonly Table<Models.Forum> _forums;

        public ForumProvider(string fileOrServerOrConnection)
        {
            _dataContext = new DataContext(fileOrServerOrConnection);
            _forums = _dataContext.GetTable<Models.Forum>();
        }

        public IList<Models.Forum> List()
        {
            return new List<Models.Forum>(_forums);
        }

        public int Create(Models.Forum entity)
        {
            _forums.InsertOnSubmit(entity);
            _dataContext.SubmitChanges();
            return entity.Id;
        }

        public Models.Forum Get(int id)
        {
            return _forums.FirstOrDefault(e => e.Id == id);
        }

        public bool Update(Models.Forum entity)
        {
            try
            {
                var forum = _forums.First(e => e.Id == entity.Id);
                forum.Name = entity.Name;
                forum.Topics = entity.Topics;
                _dataContext.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var forum = _forums.First(e => e.Id == id);
                _forums.DeleteOnSubmit(forum);
                _dataContext.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Dispose()
        {
            if (_dataContext != null) _dataContext.Dispose();
        }
    }
}