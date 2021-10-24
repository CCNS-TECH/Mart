using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resm_app.Models.BusinessObjects.Categories;
using resm_app.Models.BusinessObjects.Taxs;
using resm_app.Models.BusinessObjects.UoMs;

namespace resm_app.Models.BusinessObjects.Products
{
    [Table("CCNS_Item",Schema = "dbo")]
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigint")]
        public long Id { get; set; }
        
        [Column(TypeName = "nvarchar(15)")]
        public string  ItemCode { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        [Required(ErrorMessage = "Item Name is required")]
        public string ItemEn { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string ItemStr { get; set; }
        
        [Column(TypeName = "bigint")]
        [Required(ErrorMessage = "Category is required")]
        public long CateId { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string CateStr { get; set; }
        
        [Column(TypeName = "bigint")]
        [Required(ErrorMessage = "SubCategory is required")]
        public long SubCateL0Id { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string SubCateL0Str { get; set; }
        
        [Column(TypeName = "bigint")]
        public long SubCateL1Id { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string SubCateL1Str { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        public decimal InStock { get; set; }
        
        [Column(TypeName = "bigint")]
        [Required(ErrorMessage = "Group UoM is required")]
        public long GUoMId { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string GUoMStr { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        public string Inv { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        public string InvPch { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        public string InvSale { get; set; }
        
        [Column(TypeName = "bigint")]
        public long SaleUoMId { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string SaleUoMStr { get; set; }
        
        [Column(TypeName = "bigint")]
        public long InvUoMId { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string InvUoMStr { get; set; }
        
        [Column(TypeName = "bigint")]
        public long PchUoMId { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string PchUoMStr { get; set; }
        
        [Column(TypeName = "bigint")]
        public long TaxId { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string TaxStr { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        public decimal TaxRate { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        public decimal Cost { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        [Required(ErrorMessage = "Sale Price is required")]
        public decimal SalePrice { get; set; }
        
        [Column(TypeName = "bigint")]
        public long QrCodeId { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string QrCodeGuidStr { get; set; }
        
        [Column(TypeName = "nvarchar(25)")]
        public string Barcode { get; set; }
        
        [Column(TypeName = "bigint")]
        [Required(ErrorMessage = "Price List is required")]
        public long PriceListId { get; set; }
        
        [Column(TypeName = "nvarchar(125)")]
        public string PriceListStr { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string PrintTo { get; set; }
        
        [Column(TypeName = "nvarchar(3)")]
        public string ManageBy { get; set; }
        
        [Column(TypeName = "nvarchar(25)")]
        public string ItemType { get; set; }
        
        [Column(TypeName = "date")]
        public DateTime? DeletedDate { get; set; }
        
        [Column(TypeName = "date")]
        public DateTime? CreatedDate { get; set; }
        
        [Column(TypeName = "date")]
        public DateTime? UpdatedDate { get; set; }
        
        [Column(TypeName = "bigint")]
        public long CreatedById { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string CreatedByName { get; set; }
        
        [Column(TypeName = "bigint")]
        public long UpdatedById { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string UpdatedByName { get; set; }
        
        [Column(TypeName = "bigint")]
        public long DeletedById { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string DeletedByName { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string Img { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string OldImg { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        public string Status { get; set; }
        
        [Column(TypeName = "nvarchar(1)")]
        public string Deleted { get; set; }
        
        [NotMapped]
        public Category Category { get; set; }
        [NotMapped]
        public SubCategoryL1 SubCategoryL1 { get; set; }
        [NotMapped]
        public SubCategoryL2 SubCategoryL2 { get; set; }
        [NotMapped]
        public PriceList PriceList { get; set; }
        [NotMapped]
        public UoM UoM { get; set; }
        [NotMapped]
        public GroupUoM GroupUoM { get; set; }
        [NotMapped]
        public Tax Tax { get; set; }
        
        
    }
}