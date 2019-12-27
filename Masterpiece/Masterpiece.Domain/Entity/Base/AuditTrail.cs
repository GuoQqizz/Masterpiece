using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masterpiece.Domain.Entity.Base
{
    public class AuditTrail
    {
        public AuditTrail(string fieldName, object oldValue, object newValue)
        {
            FieldName = fieldName;
            OldValue = oldValue;
            NewValue = newValue;
        }

        public string FieldName
        {
            set;get;
        }

        public object OldValue
        {
            set;get;
        }

        public object NewValue
        {
            set;get;
        }

        public bool HasChanged()
        {
            if ((OldValue != null && !OldValue.Equals(NewValue))
                || (OldValue == null && NewValue != null))
            {
                return true;
            }

            return false;
        }
    }
}
