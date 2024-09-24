using System.ComponentModel.DataAnnotations;

namespace TvShowApi.Domain.Entities
{
    public class TvShow
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool Favorite { get; set; }
    }
}
