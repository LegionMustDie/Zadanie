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
    
    public partial class User_
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User_()
        {
            this.JuryAndModerator_ = new HashSet<JuryAndModerator_>();
            this.OrganizerParticipants_ = new HashSet<OrganizerParticipants_>();
        }
    
        public int IdUser { get; set; }
        public string IdNumber { get; set; }
        public string Password { get; set; }
        public Nullable<int> IdRole { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JuryAndModerator_> JuryAndModerator_ { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrganizerParticipants_> OrganizerParticipants_ { get; set; }
        public virtual Role_ Role_ { get; set; }
    }
}
