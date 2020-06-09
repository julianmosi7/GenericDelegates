namespace NorthwindDbLib
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Adress
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Adress()
        {
            Persons = new HashSet<Person>();
        }

        public int id { get; set; }

        public string country { get; set; }

        public string city { get; set; }

        public string streetname { get; set; }

        public string postalcode { get; set; }

        public string streetnumber { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Person> Persons { get; set; }
    }
}
