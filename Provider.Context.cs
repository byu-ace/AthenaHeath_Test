﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AthenaHeath_Test
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class AetheaProviderEntities : DbContext
    {
        public AetheaProviderEntities()
            : base("name=AetheaProviderEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual int ImportAtheanProvider(Nullable<bool> acceptingnewPatients, string ansinameCode, string ansispecialtyCode, Nullable<bool> billable, Nullable<bool> createenCounteronCheckin, string displayName, string entityType, string firstName, Nullable<bool> hideInPortal, string lastName, string providerID, string providerType, string providerTypeId, string schedulingName, string specialty, Nullable<int> supervisingProviderID, string supervisingProviderUserName, string createdBy)
        {
            var acceptingnewPatientsParameter = acceptingnewPatients.HasValue ?
                new ObjectParameter("AcceptingnewPatients", acceptingnewPatients) :
                new ObjectParameter("AcceptingnewPatients", typeof(bool));
    
            var ansinameCodeParameter = ansinameCode != null ?
                new ObjectParameter("AnsinameCode", ansinameCode) :
                new ObjectParameter("AnsinameCode", typeof(string));
    
            var ansispecialtyCodeParameter = ansispecialtyCode != null ?
                new ObjectParameter("AnsispecialtyCode", ansispecialtyCode) :
                new ObjectParameter("AnsispecialtyCode", typeof(string));
    
            var billableParameter = billable.HasValue ?
                new ObjectParameter("Billable", billable) :
                new ObjectParameter("Billable", typeof(bool));
    
            var createenCounteronCheckinParameter = createenCounteronCheckin.HasValue ?
                new ObjectParameter("CreateenCounteronCheckin", createenCounteronCheckin) :
                new ObjectParameter("CreateenCounteronCheckin", typeof(bool));
    
            var displayNameParameter = displayName != null ?
                new ObjectParameter("DisplayName", displayName) :
                new ObjectParameter("DisplayName", typeof(string));
    
            var entityTypeParameter = entityType != null ?
                new ObjectParameter("EntityType", entityType) :
                new ObjectParameter("EntityType", typeof(string));
    
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var hideInPortalParameter = hideInPortal.HasValue ?
                new ObjectParameter("HideInPortal", hideInPortal) :
                new ObjectParameter("HideInPortal", typeof(bool));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var providerIDParameter = providerID != null ?
                new ObjectParameter("ProviderID", providerID) :
                new ObjectParameter("ProviderID", typeof(string));
    
            var providerTypeParameter = providerType != null ?
                new ObjectParameter("ProviderType", providerType) :
                new ObjectParameter("ProviderType", typeof(string));
    
            var providerTypeIdParameter = providerTypeId != null ?
                new ObjectParameter("ProviderTypeId", providerTypeId) :
                new ObjectParameter("ProviderTypeId", typeof(string));
    
            var schedulingNameParameter = schedulingName != null ?
                new ObjectParameter("SchedulingName", schedulingName) :
                new ObjectParameter("SchedulingName", typeof(string));
    
            var specialtyParameter = specialty != null ?
                new ObjectParameter("Specialty", specialty) :
                new ObjectParameter("Specialty", typeof(string));
    
            var supervisingProviderIDParameter = supervisingProviderID.HasValue ?
                new ObjectParameter("SupervisingProviderID", supervisingProviderID) :
                new ObjectParameter("SupervisingProviderID", typeof(int));
    
            var supervisingProviderUserNameParameter = supervisingProviderUserName != null ?
                new ObjectParameter("SupervisingProviderUserName", supervisingProviderUserName) :
                new ObjectParameter("SupervisingProviderUserName", typeof(string));
    
            var createdByParameter = createdBy != null ?
                new ObjectParameter("CreatedBy", createdBy) :
                new ObjectParameter("CreatedBy", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ImportAtheanProvider", acceptingnewPatientsParameter, ansinameCodeParameter, ansispecialtyCodeParameter, billableParameter, createenCounteronCheckinParameter, displayNameParameter, entityTypeParameter, firstNameParameter, hideInPortalParameter, lastNameParameter, providerIDParameter, providerTypeParameter, providerTypeIdParameter, schedulingNameParameter, specialtyParameter, supervisingProviderIDParameter, supervisingProviderUserNameParameter, createdByParameter);
        }
    }
}