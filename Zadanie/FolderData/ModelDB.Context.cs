﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DBEntities : DbContext
    {
        public DBEntities()
            : base("name=DBEntities")
        {
        }

        private static DBEntities context;
        public static DBEntities GetContext()
        {
            return context ?? (context = new DBEntities());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ActionPlan_> ActionPlan_ { get; set; }
        public virtual DbSet<Activities_> Activities_ { get; set; }
        public virtual DbSet<ActivitiesInfo_> ActivitiesInfo_ { get; set; }
        public virtual DbSet<Activity_> Activity_ { get; set; }
        public virtual DbSet<City_> City_ { get; set; }
        public virtual DbSet<Country_> Country_ { get; set; }
        public virtual DbSet<Directory_> Directory_ { get; set; }
        public virtual DbSet<Event_> Event_ { get; set; }
        public virtual DbSet<Gender_> Gender_ { get; set; }
        public virtual DbSet<JuryAndModerator_> JuryAndModerator_ { get; set; }
        public virtual DbSet<OrganizerParticipants_> OrganizerParticipants_ { get; set; }
        public virtual DbSet<Role_> Role_ { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<User_> User_ { get; set; }
    }
}
