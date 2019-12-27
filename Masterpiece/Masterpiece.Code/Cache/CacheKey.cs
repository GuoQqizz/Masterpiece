using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbhsChinese.Code.Cache
{
    /// <summary>
    /// 缓存键配置类
    /// </summary>
    public class CacheKey
    {

        public static Dictionary<CacheKeyEnum, string> CacheKeyExpression = new Dictionary<CacheKeyEnum, string>();
        private static void InitCacheKey()
        {
            string cachePrefix = "AC_";
            CacheKeyExpression[CacheKeyEnum.Test_Cache] = cachePrefix + "Test_Cache_{0}";
            CacheKeyExpression[CacheKeyEnum.Product_Cache] = cachePrefix + "Product_Cache_{0}";
            CacheKeyExpression[CacheKeyEnum.UnitStepEdit_Cache] = cachePrefix + "UnitStepEdit_Cache_{0}";
            CacheKeyExpression[CacheKeyEnum.CurrentStudyRecord_Cache] = cachePrefix + "CurrentStudyRecord_Cache_{0}";
            CacheKeyExpression[CacheKeyEnum.Student_Cache] = cachePrefix + "Student_Cache_{0}";
            CacheKeyExpression[CacheKeyEnum.Lesson_5UnitStep_Cache] = cachePrefix + "Lesson_5UnitStep_Cache_{0}";
            CacheKeyExpression[CacheKeyEnum.SubjectBody_Cache] = cachePrefix + "SubjectContent_Cache_{0}"; 
            //CacheKeyExpression[CacheKeyEnum.CatalogAll_Cache] = cachePrefix + "CatalogAll_Cache";
            //CacheKeyExpression[CacheKeyEnum.Catalog_Cache] = cachePrefix + "Catalog_Cache_{0}";
            //CacheKeyExpression[CacheKeyEnum.SchoolPackage_Cache] = cachePrefix + "SchoolPackage_Cache_{0}";
            //CacheKeyExpression[CacheKeyEnum.SchoolPackageExt_Cache] = cachePrefix + "SchoolPackageExt_Cache_{0}";
            //CacheKeyExpression[CacheKeyEnum.SchoolPackageCatalogTree_Cache] = cachePrefix + "SchoolPackageCatalogTree_Cache_{0}";
            //CacheKeyExpression[CacheKeyEnum.SchoolPackageCatalogTreeIncludeLesson_Cache] = cachePrefix + "SchoolPackageCatalogTreeIncludeLesson_Cache_{0}";
        }

        static CacheKey()
        {
            InitCacheKey();
        }

        public static string GetCacheKey(CacheKeyEnum cacheKeyEnum, object id)
        {
            return string.Format(CacheKeyExpression[cacheKeyEnum], id == null ? "0" : id.ToString());
        }

        public static string GetCacheKey(CacheKeyEnum cacheKeyEnum, params string[] paras)
        {
            return string.Format(CacheKeyExpression[cacheKeyEnum], paras);
        }
    }
}
