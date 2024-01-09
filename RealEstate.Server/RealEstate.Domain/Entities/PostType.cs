using RealEstate.Shared.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Domain.Entities
{
    [Table(nameof(PostType), Schema = "dbo")]
    public class PostType : IFullAudited
    {
        [Key]
        public int Id {  get; set; }
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        #region audit
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public bool Deleted { get; set; }
        #endregion
    }
}
