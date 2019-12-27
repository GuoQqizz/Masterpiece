using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbhsChinese.Code.Cache
{
    /// <summary>
    /// 缓存依赖项
    /// </summary>
    public enum CacheDependencyEnum
    {
        [Description("测试")]
        Test = 1,
        [Description("产品")]
        Product = 2,
        [Description("课时单元步骤")]
        LessonUnitStep = 3,
        [Description("学生")]
        Student = 4,
        [Description("题目内容")]
        SubjectContent = 5,
        [Description("文本对象")]
        TextObject = 6,
        [Description("学生每日统计")]
        SumStudentDaily = 7,
        [Description("学生统计")]
        SumStudent = 8,
        [Description("学生周期统计")]
        SumStudentCycle = 9,
        [Description("题目")]
        Subject = 10,
        [Description("课时")]
        Lesson =11
    }

    /// <summary>
    /// 缓存类型
    /// </summary>
    public enum CacheTypeEnum
    {
        Redis = 1,
        Sql = 2,
        File = 3,
        LocalCache = 4,
        Composite = 5,//本地Cache和Redis混合
    }

    /// <summary>
    /// 缓存依赖的操作类型
    /// </summary>
    public enum CacheDependencyActionType
    {
        Add = 1,
        Update = 2,
        Delete = 4,
        CUD = 8
    }

    public enum CacheStatusEnum
    {
        Enable = 1,//可用
        Disable = 2,//禁用
        Refresh = 3 //刷新
    }

    /// <summary>
    /// 缓存项
    /// </summary>
    public enum CacheKeyEnum
    {
        [Description("测试缓存")]
        [CacheDependencyAttibute(CacheDependencyEnum.Test, new CacheDependencyActionType[] { CacheDependencyActionType.Update, CacheDependencyActionType.Delete })]
        [CacheKeyTypeAttribue(CacheTypeEnum.Redis)]
        Test_Cache = 1,

        [Description("产品缓存")]
        [CacheDependencyAttibute(CacheDependencyEnum.Product, new CacheDependencyActionType[] { CacheDependencyActionType.Update, CacheDependencyActionType.Delete })]
        [CacheKeyTypeAttribue(CacheTypeEnum.Redis)]
        Product_Cache = 2,

        [Description("课时单元步骤缓存")]
        [CacheDependencyAttibute(CacheDependencyEnum.Lesson, new CacheDependencyActionType[] { CacheDependencyActionType.Add, CacheDependencyActionType.Update, CacheDependencyActionType.Delete })]
        [CacheKeyTypeAttribue(CacheTypeEnum.LocalCache)]
        [CacheDurationAttibute(300)]
        Lesson_5UnitStep_Cache = 3,

        [Description("学生信息缓存")]
        [CacheDependencyAttibute(CacheDependencyEnum.Student, new CacheDependencyActionType[] { CacheDependencyActionType.Update, CacheDependencyActionType.Delete })]
        [CacheKeyTypeAttribue(CacheTypeEnum.Redis)]
        Student_Cache = 4,

        [Description("题目内容缓存")]
        [CacheDependencyAttibute("5:2,4|10:2,4")]
        [CacheKeyTypeAttribue(CacheTypeEnum.LocalCache)]
        [CacheDurationAttibute(600)]
        SubjectBody_Cache = 5,

        [Description("文本对象缓存")]
        [CacheDependencyAttibute(CacheDependencyEnum.TextObject, new CacheDependencyActionType[] { CacheDependencyActionType.Add, CacheDependencyActionType.Update, CacheDependencyActionType.Delete })]
        [CacheKeyTypeAttribue(CacheTypeEnum.Redis)]
        TextObject_Cache = 6,

        [Description("学生每日统计缓存")]
        [CacheDependencyAttibute(CacheDependencyEnum.SumStudentDaily, new CacheDependencyActionType[] { CacheDependencyActionType.Add, CacheDependencyActionType.Update, CacheDependencyActionType.Delete })]
        [CacheKeyTypeAttribue(CacheTypeEnum.Redis)]
        SumStudentDaily_Cache = 7,

        [Description("学生统计缓存")]
        [CacheDependencyAttibute(CacheDependencyEnum.SumStudent, new CacheDependencyActionType[] { CacheDependencyActionType.Add, CacheDependencyActionType.Update, CacheDependencyActionType.Delete })]
        [CacheKeyTypeAttribue(CacheTypeEnum.Redis)]
        SumStudent_Cache = 8,

        [Description("课时单元编辑缓存")]
        [CacheKeyTypeAttribue(CacheTypeEnum.Redis)]
        [CacheDurationAttibute(60)]
        UnitStepEdit_Cache = 9,

        [Description("学生最近学习记录")]
        [CacheKeyTypeAttribue(CacheTypeEnum.Redis)]
        [CacheDurationAttibute(900)]
        CurrentStudyRecord_Cache = 10,

        //[Description("后台类目集合缓存")]
        //[CacheDependencyAttibute(CacheDependencyEnum.Catalog, new CacheDependencyActionType[] { CacheDependencyActionType.Add, CacheDependencyActionType.Update, CacheDependencyActionType.Delete })]
        //[CacheKeyTypeAttribue(CacheTypeEnum.LocalCache)]
        //CatalogAll_Cache = 3,

        //[Description("根据广告目录查广告列表")]
        //[CacheDurationAttibute(600)]
        //[CacheKeyTypeAttribue(CacheTypeEnum.Redis)]
        //SchoolAd_Cache = 5,

        //[Description("前台类目结果表缓存")]
        ////[CacheDependencyAttibute(CacheDependencyEnum.FrontCatalog, new CacheDependencyActionType[] { CacheDependencyActionType.Update, CacheDependencyActionType.Delete })]
        //[CacheKeyTypeAttribue(CacheTypeEnum.LocalCache)]
        //FrontCatalogResult_Cache = 13,

        //[Description("前台类目结果表集合缓存")]
        //// [CacheDependencyAttibute(CacheDependencyEnum.FrontCatalog, new CacheDependencyActionType[] { CacheDependencyActionType.Add, CacheDependencyActionType.Update, CacheDependencyActionType.Delete })]
        //[CacheKeyTypeAttribue(CacheTypeEnum.LocalCache)]
        //FrontCatalogAllResult_Cache = 14,

        //[Description("课程优惠活动缓存")]
        //[CacheDependencyAttibute("11:1,2,4|16:1,2,4")]
        //[CacheKeyTypeAttribue(CacheTypeEnum.Redis)]
        //SchoolDiscountActionAllow_Cache = 15,
    }
}
