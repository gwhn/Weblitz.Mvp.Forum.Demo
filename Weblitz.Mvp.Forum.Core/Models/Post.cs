using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Weblitz.Mvp.Forum.Core.Models
{
    [Table(Name = "Posts")]
    public class Post : IEntity
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(CanBeNull = false)]
        public string Body { get; set; }

        [Column]
        public int TopicId { get; set; }

        private EntityRef<Topic> _topic;

        [Association(Storage = "_topic", ThisKey = "TopicId")]
        public Topic Topic
        {
            get { return _topic.Entity; }
            set { _topic.Entity = value; }
        }
    }
}