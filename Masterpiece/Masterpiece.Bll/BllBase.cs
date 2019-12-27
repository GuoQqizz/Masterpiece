using AbhsChinese.Code.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masterpiece.Bll
{
   public abstract class BllBase
    {
        protected DbContextFactory contextFactory;

        public BllBase(DbContextFactory contextFactory)
        {
            this.contextFactory = contextFactory;
            //this.contextFactory.DBContext.Database.Log = Log;
        }

        protected string tranId;
        public void BeginTran()
        {
            tranId = Guid.NewGuid().ToString();
        }

        public void CommitTran()
        {
            CacheHelper.NotifyRefreshCacheForTranCommit(tranId);
            tranId = "";
        }

        public void RollbackTran()
        {
            tranId = "";
        }
    }
}
