using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using resm_app.Models.BusinessObjects.Employees;
using resm_app.Models.BusinessObjects.Payments;

namespace resm_app.Models.BusinessObjects.Commissions
{
    [Table("CCNS_Commission",Schema = "dbo")]
    public class Commission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigint")]
        public long Id { get; set; }
        [Column(TypeName = "nvarchar(225)")]
        public string Description { get; set; }
        [Column(TypeName = "bigint")]
        public long ReceivedById { get; set; }
        [Column(TypeName = "nvarchar(125)")]
        public string ReceivedByStr { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DocDate { get; set; }
        [Column(TypeName = "bigint")]
        public long PaymentCode { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal GrandTotalUSD { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal GrandTotalRiel { get; set; }
        [Column(TypeName = "nvarchar(25)")]
        public string Prcnt { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal Rate { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal CommissionTotalUSD { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal CommissionTotalRiel { get; set; }
        [Column(TypeName = "nvarchar(1)")]
        public string LineStatus { get; set; }
        [Column(TypeName = "bigint")]
        public long AcceptById { get; set; }
        [Column(TypeName = "nvarchar(125)")]
        public string AcceptByStr { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? AcceptDate { get; set; }
        [Column(TypeName = "nvarchar(1)")]
        public string AcceptStatus { get; set; }
        [Column(TypeName = "nvarchar(1)")]
        public string Deleted { get; set; }
        
        [Column(TypeName = "nvarchar(225)")]
        public string Remark { get; set; }
        [NotMapped]
        public IEnumerable<Payment> Payments { get; set; }
        [NotMapped]
        public Employee Employee { get; set; }
        
    }
}