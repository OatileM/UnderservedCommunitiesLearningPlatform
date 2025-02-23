using System.ComponentModel.DataAnnotations;

namespace UnderservedCommunitiesLearningPlatform.Models
{
    public interface User
    {
        [Key]
        public string UserID { get; set; }

    }
}
