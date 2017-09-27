using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FruitWebGui.Models
{
    public class ContentOfOutgoingTransaction
    {
        public int id { get; set; }

        public int Fruit { get; set; }

        public int ProcessedOutgoingTransaction { get; set; }

        public int Amount { get; set; }

        public ContentOfOutgoingTransaction(int id, int Fruit, int ProcessedOutgoingTransaction, int Amount)
        {
            this.id = id;
            this.Fruit = Fruit;
            this.ProcessedOutgoingTransaction = ProcessedOutgoingTransaction;
            this.Amount = Amount;
        }

    }
}