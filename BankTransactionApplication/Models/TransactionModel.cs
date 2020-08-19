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
        
        [Column(TypeName = "nvarchar(12)")]
        [DisplayName("Account Number")]
        public string AccountNumber { get; set; }
        
        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Beneficiary Name")]
        public string BeneficiaryName { get; set; }
        
        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Bank Name")]
        public string BankName { get; set; }
       
        [Column(TypeName = "nvarchar(11)")]
        [DisplayName("SWIFTCode")]
        public string SWIFTCode { get; set; }

        [DisplayName("Amount")]
        public int Amount { get; set; }

        [DisplayName("Date")]
        public DateTime Date { get; set; }

    }
}
