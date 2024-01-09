namespace RealEstate.Shared.Common
{
    public interface IFullAudited : ICreatedBy, IModifiedBy, ISoftDelted
    {
    }
    public interface ICreatedBy
    {
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
    }

    public interface IModifiedBy
    {
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
    }
    public interface ISoftDelted
    {
        public bool Deleted { get; set; }
    }
}
