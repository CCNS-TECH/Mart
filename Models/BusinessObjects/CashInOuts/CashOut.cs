using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace resm_app.Models.BusinessObjects.CashInOuts
{
    [Table("CCNS_CashOut",Schema = "dbo")]
    public class CashOut
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigint")]
        public long Id { get; set; }
        [Column(TypeName = "bigint")]
        [Required]
        public long CashInId { get; set; }
        [Column(TypeName = "bigint")]
        public long CashOutById { get; set; }
        [Column(TypeName = "nvarchar(125)")]
        public string CashOutByStr { get; set; }
        [Column(TypeName = "bigint")]
        public long ReceivedById { get; set; }
        [Column(TypeName = "nvarchar(125)")]
        public string ReceivedByStr { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CashOutDate { get; set; }
        [Column(TypeName = "bigint")]
        public long CloseShiftId { get; set; }
        [Column(TypeName = "nvarchar(125)")]
        public string CloseShiftStr { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DocDate { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal CashOutUSD { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal CashOutRiel { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        [Required]
        public decimal TotalCashInUSD { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal TotalCashInRiel { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,6)")]
        public decimal TotalCashOutUSD { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal TotalCashOutRiel { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal ExchangeRate { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal GrandTotalUSD { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal GrandTotalRiel { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CloseDate { get; set; }
        [Column(TypeName = "bigint")]
        public long CloseById { get; set; }
        [Column(TypeName = "nvarchar(125)")]
        public string CloseByStr { get; set; }
        [Column(TypeName = "nvarchar(1)")]
        public string DocStatus { get; set; }
        [Column(TypeName = "nvarchar(1)")]
        public string Delete { get; set; }

        [Column(TypeName = "bigint")]
        public long PayCodeMin { get; set; }
        [Column(TypeName = "bigint")]
        public long PayCodeMax { get; set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal SaleAmount { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal SaleAmountReil { get; set; }

        public virtual CashIn CashIn { get; set; }
    }
}