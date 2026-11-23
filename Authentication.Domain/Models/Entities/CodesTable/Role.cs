using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using TM.Common.Models.Bases;
using TM.Common.Models.Interfaces;
using TM.Common.Utils;

namespace Authentication.Domain.Models.Entities.CodesTable
{
    public class Role : 
        IdentityRole, 
        IActivatableByUser, 
        IModifiableByUser, 
        IModifiable, 
        IActivatable, 
        ICreatableByUser
    {
        public Role() => base.Id = Security.GenerateExtendedGuid("ROL",1);

        public string ModifiedBy { get; set; }
        public DateTime DateTimeModified { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }

        public DateTime DateTimeCreated { get; set; }
    }
}
