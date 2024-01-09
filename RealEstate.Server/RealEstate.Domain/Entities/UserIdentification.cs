﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Domain.Entities
{
    [Table(nameof(UserIdentification), Schema = "dbo")]
    public class UserIdentification
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string IdNo { get; set; } = null!;
        [MaxLength(100)]
        public string Fullname { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        [MaxLength(100)]
        public string Sex { get; set; } = null!;
        [MaxLength(100)]
        public string Nationality {  get; set; } = null!;
        [MaxLength(250)]
        public string PlaceOfOrigin {  get; set; } = null!;
        [MaxLength(250)]
        public string PlaceOfResidence {  get; set; } = null!;
        public DateTime ExpiredDate { get; set; }
    }
}