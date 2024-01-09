﻿using Microsoft.EntityFrameworkCore;
using RealEstate.Shared.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Domain.Entities
{
    [Table(nameof(Media), Schema = "dbo")]
    [Index(nameof(PostId), Name = $"IX_{nameof(Media)}")]
    public class Media : IFullAudited
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = null!;
        [MaxLength(512)]
        public string Description { get; set; } = null!;
        [MaxLength(2048)]
        public string MediaUrl { get; set; } = null!;
        public int PostId { get; set; }
        #region audit
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public bool Deleted { get; set; }
        #endregion
    }
}
