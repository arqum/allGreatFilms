//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AllGreatFilms.BusinessObjectLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class movie_quotes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public movie_quotes()
        {
            this.users = new HashSet<user>();
        }
    
        public int quote_id { get; set; }
        public int movie_id { get; set; }
        public string quote { get; set; }
    
        public virtual movie movie { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user> users { get; set; }
    }
}
