using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using Weblitz.Mvp.Forum.Core.Models;

namespace Weblitz.Mvp.Forum.Core.Providers
{
    public class PostProvider : IPostProvider
    {
        private readonly DataContext _dataContext;
        private readonly Table<Post> _posts;

        public PostProvider(string fileOrServerOrConnection)
        {
            _dataContext = new DataContext(fileOrServerOrConnection);
            _posts = _dataContext.GetTable<Post>();
        }

        public IList<Post> List()
        {
            return new List<Post>(_posts);
        }

        public int Create(Post entity)
        {
            _posts.InsertOnSubmit(entity);
            _dataContext.SubmitChanges();
            return entity.Id;
        }

        public Post Get(int id)
        {
            return _posts.FirstOrDefault(e => e.Id == id);
        }

        public bool Update(Post entity)
        {
            try
            {
                var post = _posts.First(e => e.Id == entity.Id);
                post.Body = entity.Body;
                post.Topic = entity.Topic;
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
                var post = _posts.First(e => e.Id == id);
                _posts.DeleteOnSubmit(post);
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