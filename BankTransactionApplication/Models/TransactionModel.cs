using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BankTransactionApplication.Models
{
    public class TransactionModel
    {
        [Key]
        public int TransactionId { get; set; }
        
        [MaxLength(12)]
        [Column(TypeName = "nvarchar(12)")]
        [DisplayName("Account Number")]
        [Required(ErrorMessage = "Account Number is required.")]
        public string AccountNumber { get; set; }
        
        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Beneficiary Name")]
        [Required(ErrorMessage = "Beneficiary Name is required.")]
        public string BeneficiaryName { get; set; }
        
        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Bank Name")]
        [Required(ErrorMessage = "Bank Name is required.")]
        public string BankName { get; set; }

        [MaxLength(11)]
        [Column(TypeName = "nvarchar(11)")]
        [DisplayName("SWIFTCode")]
        [Required(ErrorMessage = "SWIFTCode is required.")]
        public string SWIFTCode { get; set; }

        [DisplayName("Amount")]
        [Required(ErrorMessage = "Amount is required.")]
        public int Amount { get; set; }

        [DisplayName("Date")]
        [Required(ErrorMessage = "Date is required.")]
        public DateTime Date { get; set; }

    }
}
