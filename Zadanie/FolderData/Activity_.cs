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
    
    public partial class Activity_
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Activity_()
        {
            this.ActivitiesInfo_ = new HashSet<ActivitiesInfo_>();
        }
    
        public int IdActivity { get; set; }
        public string NameActivity { get; set; }
        public Nullable<double> Day { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ActivitiesInfo_> ActivitiesInfo_ { get; set; }
    }
}
