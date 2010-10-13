using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using Weblitz.Mvp.Forum.Core.Models;

namespace Weblitz.Mvp.Forum.Core.Providers
{
    public class TopicProvider : ITopicProvider
    {
        private readonly DataContext _dataContext;
        private readonly Table<Topic> _topics;

        public TopicProvider(string fileOrServerOrConnection)
        {
            _dataContext = new DataContext(fileOrServerOrConnection);
            _topics = _dataContext.GetTable<Topic>();
        }

        public IList<Topic> List()
        {
            return new List<Topic>(_topics);
        }

        public int Create(Topic entity)
        {
            _topics.InsertOnSubmit(entity);
            _dataContext.SubmitChanges();
            return entity.Id;
        }

        public Topic Get(int id)
        {
            return _topics.FirstOrDefault(e => e.Id == id);
        }

        public bool Update(Topic entity)
        {
            try
            {
                var topic = _topics.First(e => e.Id == entity.Id);
                topic.Title = entity.Title;
                topic.Body = entity.Body;
                topic.Sticky = entity.Sticky;
                topic.Forum = entity.Forum;
                topic.Posts = entity.Posts;
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
                var topic = _topics.First(e => e.Id == id);
                _topics.DeleteOnSubmit(topic);
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