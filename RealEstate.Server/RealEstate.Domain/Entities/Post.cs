using Microsoft.EntityFrameworkCore;
using RealEstate.Shared.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Domain.Entities
{
    [Table(nameof(Post), Schema = "dbo")]
    [Index(nameof(Deleted), nameof(ApproveBy), nameof(PostTypeId), nameof(RealEstateTypeId), nameof(UserId), Name = $"IX_{nameof(Post)}")]
    public class Post : IFullAudited
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? DetailAddress {  get; set; }
        [Required(ErrorMessage = "Trường diện tích không được bỏ trống")]
        [Range(1, double.MaxValue)]
        public double Area {  get; set; }
        /// <summary>
        /// Giá cho thuê/bán
        /// </summary>
        public double? Price {  get; set; }
        /// <summary>
        /// Đối tượng cho thuê
        /// </summary>
        public double? RentalObject {  get; set; }
        /// <summary>
        /// Link video youtube
        /// </summary>
        [MaxLength(250)]
        public string? YoutubeLink { get; set; }
        public bool IsActive {  get; set; }
        /// <summary>
        /// Thời gian duyệt
        /// </summary>
        public DateTime? ApproveAt { get; set; }
        /// <summary>
        /// Người duyệt
        /// </summary>
        public int? ApproveBy { get; set; }
        public int UserId { get; set; }
        public int PostTypeId {  get; set; }
        public int RealEstateTypeId { get;set; }
        #region audit
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public bool Deleted { get; set; }
        #endregion
    }
}
