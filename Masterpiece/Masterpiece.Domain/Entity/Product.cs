using Masterpiece.Domain.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masterpiece.Domain.Entity
{
    [Table("Product")]
    public class Product : EntityBase
    {
        [Key]
        public int Id { get; set; }

        private string name;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                AuditCheck("Name", value);
                name = Name;
            }
        }
    }
}
