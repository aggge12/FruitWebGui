using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FruitWebGui.Models
{
    public class ProcessedOutgoingTransactions
    {

        public ProcessedOutgoingTransactions()
        {

        }

        public ProcessedOutgoingTransactions(int id, string status, DateTime TimeProcessed)
        {
            this.id = id;
            this.status = status;
            this.TimeProcessed = TimeProcessed;
        }
        public int id { get; set; }


        public string status { get; set; }

        public DateTime? TimeProcessed { get; set; }

        /*[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContentOfOutgoingTransaction> ContentOfOutgoingTransaction { get; set; }*/
    }
}