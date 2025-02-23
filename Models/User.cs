using System.ComponentModel.DataAnnotations;

namespace UnderservedCommunitiesLearningPlatform.Models
{
    public abstract class User
    {
        [Key]
        public string UserID { get; set; }
    }
}
