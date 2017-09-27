using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FruitWebGui.Models
{
    public class Fruit
    {
        public Fruit()
        {

        }

        public Fruit(int id, string Name, int qtt, int price)
        {
            this.id = id;
            this.Name = Name;
            this.QuantityInSupply = qtt;
            this.price = price;
        }

        public int id { get; set; }
        public int price { get; set; }

        public string Name { get; set; }

        public int QuantityInSupply { get; set; }



        /*[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContentOfIncomingTransaction> ContentOfIncomingTransaction { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContentOfOutgoingTransaction> ContentOfOutgoingTransaction { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FruitSupplier> FruitSupplier { get; set; }*/
    }
}