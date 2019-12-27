using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masterpiece.Domain.Entity.Base
{
    public static class ChangeTrackExt
    {

        public static void EnableAudit(this IChangeTrack obj)
        {
            obj.EnableAudit();
        }

        public static void EnableAudit(this IEnumerable<IChangeTrack> objs)
        {
            foreach (IChangeTrack track in objs)
            {
                track.EnableAudit();
            }
        }
    }
}
