//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Online_Bus_Reservation_System.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Route
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Route()
        {
            this.Schedules = new HashSet<Schedule>();
        }
    
        public int RouteId { get; set; }
        public int CityFrom { get; set; }
        public int CityTo { get; set; }
        public decimal Fare { get; set; }
    
        public virtual City City { get; set; }
        public virtual City City1 { get; set; }
        public virtual Route Route1 { get; set; }
        public virtual Route Route2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
