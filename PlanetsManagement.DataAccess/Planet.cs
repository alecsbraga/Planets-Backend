//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PlanetsManagement.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Planet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Planet()
        {
            this.Planets_Robots1 = new HashSet<Planets_Robots>();
        }
    
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public System.Guid StatusId { get; set; }
        public string Image { get; set; }
        public string LastCaptainUpdate { get; set; }
    
        public virtual Status Status { get; set; }
        public virtual Planets_Robots Planets_Robots { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Planets_Robots> Planets_Robots1 { get; set; }
    }
}
