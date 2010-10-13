using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Weblitz.Mvp.Forum.Core.Models
{
    [Table(Name = "Forums")]
    public class Forum : IEntity
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(CanBeNull = false)]
        public string Name { get; set; }

        private EntitySet<Topic> _topics = new EntitySet<Topic>();

        [Association(Storage = "_topics", OtherKey = "ForumId")]
        public EntitySet<Topic> Topics
        {
            get { return _topics; }
            set { _topics.Assign(value); }
        }
    }
}