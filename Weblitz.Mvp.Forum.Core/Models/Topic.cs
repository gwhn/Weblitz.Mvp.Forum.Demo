using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Weblitz.Mvp.Forum.Core.Models
{
    [Table(Name = "Topics")]
    public class Topic : IEntity
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(CanBeNull = false)]
        public string Title { get; set; }

        [Column(CanBeNull = false)]
        public string Body { get; set; }

        [Column]
        public bool Sticky { get; set; }

        [Column]
        public int ForumId { get; set; }

        private EntityRef<Forum> _forum;

        [Association(Storage = "_forum", ThisKey = "ForumId")]
        public Forum Forum
        {
            get { return _forum.Entity; }
            set { _forum.Entity = value; }
        }

        private EntitySet<Post> _posts = new EntitySet<Post>();

        [Association(Storage = "_posts", OtherKey = "TopicId")]
        public EntitySet<Post> Posts
        {
            get { return _posts; }
            set { _posts.Assign(value); }
        }
    }
}