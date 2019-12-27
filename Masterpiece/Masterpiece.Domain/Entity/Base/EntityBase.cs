using Masterpiece.Domain.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Masterpiece.Domain.Entity
{
    public class EntityBase : IChangeTrack
    {
        private Dictionary<string, AuditTrail> changedFields
        {
            set; get;
        }

        private bool enableAudit = false;

        public EntityBase()
        {
            changedFields = new Dictionary<string, AuditTrail>();
        }

        public void EnableAudit()
        {
            enableAudit = true;
        }

        public void DisableAudit()
        {
            enableAudit = false;
        }

        public bool IsEnableAudit()
        {
            return enableAudit;
        }

        public void ReAudit()
        {
            this.enableAudit = true;
            foreach (KeyValuePair<string, AuditTrail> item in changedFields)
            {
                item.Value.OldValue = item.Value.NewValue;
            }
        }

        public void ForceAudit()
        {
            changedFields.Clear();
            this.enableAudit = true;
            PropertyInfo[] properties = this.GetType().GetProperties();
            foreach (PropertyInfo p in properties)
            {
                object value = p.GetValue(this);
                changedFields.Add(p.Name, new AuditTrail(p.Name, value, value));
            }
        }

        protected void AuditCheck(string fieldName, object newValue)
        {
            AuditTrail trail = null;
            if (changedFields.ContainsKey(fieldName))
            {
                trail = changedFields[fieldName];
            }

            if (!enableAudit && trail == null)
            {
                trail = new AuditTrail(fieldName, newValue, newValue);
                changedFields.Add(fieldName, trail);
            }
            else if (enableAudit && trail == null)
            {
                object oldValue = null;
                if (newValue != null && newValue.GetType() != typeof(string))
                {
                    oldValue = Activator.CreateInstance(newValue.GetType());
                }

                trail = new AuditTrail(fieldName, oldValue, newValue);
                changedFields.Add(fieldName, trail);
            }
            else if (enableAudit && trail != null)
            {
                trail.NewValue = newValue;
            }
        }

        public List<string> ChangedFields()
        {
            return changedFields.Where(x => x.Value.HasChanged()).Select(x => x.Key).ToList();
        }
    }
}
}
