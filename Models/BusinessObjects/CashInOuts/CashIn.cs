using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace resm_app.Models.BusinessObjects.CashInOuts
{
    [Table("CCNS_CashIn",Schema = "dbo")]
    public class CashIn
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigint")]
        public long Id { get; set; }
        [Column(TypeName = "bigint")]
        [Required]
        public long CashInById { get; set; }
        [Column(TypeName = "nvarchar(125)")]
        public string CashInByStr { get; set; }
        [Column(TypeName = "bigint")]
        [Required]
        public long ReceivedById { get; set; }
        [Column(TypeName = "nvarchar(125)")]
        public string ReceivedByStr { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CashInDate { get; set; }
        [Column(TypeName = "bigint")]
        [Required(ErrorMessage = "Shift is Required")]
        public long ShiftId { get; set; }
        [Column(TypeName = "nvarchar(125)")]
        public string ShiftStr { get; set; }
        
        [Column(TypeName = "datetime")]
        public DateTime? DocDate { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        [Required(ErrorMessage = "CashIn is Required")]
        public decimal CashInUSD { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal CashInRiel { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        [Required(ErrorMessage = "Total USD is Required")]
        public decimal TotalUSD { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal TotalRiel { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        [Required]
        public decimal ExchangeRate { get; set; }
        [Column(TypeName = "nvarchar(1)")]
        public string DocStatus { get; set; }
        [Column(TypeName = "nvarchar(1)")]
        public string Delete { get; set; }

        [Column(TypeName = "bigint")]
        public long PaymentCode { get; set; }

    }
}