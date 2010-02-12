using System;
using System.ComponentModel.DataAnnotations;
using UCDArch.Core.DomainModel;

namespace UCDArchTemplates.Models
{
    public class Order : DomainObjectWithTypedId<int>
    {
        /// <summary>
        /// This is a placeholder constructor for NHibernate.
        /// A no-argument constructor must be avilable for NHibernate to create the object.
        /// </summary>
        public Order() { }

        public Order(Customer orderedBy)
        {
            //Check.Require(orderedBy != null, "orderedBy may not be null");

            OrderedBy = orderedBy;
        }

        public virtual DateTime OrderDate { get; set; }

        [Required]
        public virtual string ShipAddress { get; set; }

        [Required]
        public virtual Customer OrderedBy { get; set; }
    }
}