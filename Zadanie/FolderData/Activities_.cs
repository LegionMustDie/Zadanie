//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Zadanie.FolderData
{
    using System;
    using System.Collections.Generic;
    
    public partial class Activities_
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Activities_()
        {
            this.ActivitiesInfo_ = new HashSet<ActivitiesInfo_>();
        }
    
        public int IdActivities { get; set; }
        public Nullable<int> IdActionPlan { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<int> Days { get; set; }
        public Nullable<int> winner { get; set; }
    
        public virtual ActionPlan_ ActionPlan_ { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ActivitiesInfo_> ActivitiesInfo_ { get; set; }
    }
}
