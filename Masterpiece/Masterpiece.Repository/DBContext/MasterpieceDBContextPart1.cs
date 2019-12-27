using Masterpiece.Domain.Entity;
using System.Data.Entity;

namespace Masterpiece.Repository.DBContext
{
    public class MasterpieceDBContextPart1 : DbContext
    {
        //public DbSet<sum_AssessmentDetail> sum_AssessmentDetails { get; set; }
        //public DbSet<sum_PKSummarize> sum_PKSummarizes { get; set; }
        //public DbSet<sum_ReadDetail> sum_ReadDetails { get; set; }
        //public DbSet<sum_ReadSummarize> sum_ReadSummarizes { get; set; }
        //public DbSet<sum_ReciteTextDetail> sum_ReciteTextDetails { get; set; }
        //public DbSet<sum_ReciteTextSummarize> sum_ReciteTextSummarizes { get; set; }
        //public DbSet<sum_SpeakingDetail> sum_SpeakingDetails { get; set; }
        //public DbSet<sum_SpeakingSummarize> sum_SpeakingSummarizes { get; set; }
        //public DbSet<sum_StructureDetail> sum_StructureDetails { get; set; }
        //public DbSet<sum_StructureSummarize> sum_StructureSummarizes { get; set; }
        //public DbSet<sum_StudySummarize> sum_StudySummarizes { get; set; }
        //public DbSet<sum_StudySummarizeDay> sum_StudySummarizeDays { get; set; }
        //public DbSet<sum_TestDetail> sum_TestDetails { get; set; }
        //public DbSet<sum_TestSummarize> sum_TestSummarizes { get; set; }
        //public DbSet<sum_WordDetail> sum_WordDetails { get; set; }
        //public DbSet<sum_WordSummarize> sum_WordSummarizes { get; set; }
        //public DbSet<sum_YinBiaoDetail> sum_YinBiaoDetails { get; set; }
        //public DbSet<sum_YinBiaoSummarize> sum_YinBiaoSummarizes { get; set; }
        //public DbSet<sys_Category> sys_Categorys { get; set; }
        //public DbSet<sys_Composition> sys_Compositions { get; set; }
        //public DbSet<sys_Dictionary> sys_Dictionarys { get; set; }
        //public DbSet<sys_ECTranslation> sys_ECTranslations { get; set; }
        //public DbSet<sys_Error> sys_Errors { get; set; }
        //public DbSet<sys_FillBlanks> sys_FillBlankss { get; set; }
        //public DbSet<sys_Item> sys_Items { get; set; }
        //public DbSet<sys_ItemGroup> sys_ItemGroups { get; set; }
        //public DbSet<sys_Select> sys_Selects { get; set; }
        //public DbSet<sys_Speaking> sys_Speakings { get; set; }
        //public DbSet<sys_Test> sys_Tests { get; set; }
        //public DbSet<sys_TestPart> sys_TestParts { get; set; }
        //public DbSet<wx_Activity> wx_Activitys { get; set; }
        //public DbSet<wx_ActivityApply> wx_ActivityApplys { get; set; }
        //public DbSet<wx_AssessmentDetail> wx_AssessmentDetails { get; set; }
        //public DbSet<wx_AssessmentDetailTemp> wx_AssessmentDetailTemps { get; set; }
        //public DbSet<wx_IgnoreSchool> wx_IgnoreSchools { get; set; }
        //public DbSet<wx_RegTrialAccount> wx_RegTrialAccounts { get; set; }
        //public DbSet<wx_UserAttachStudent> wx_UserAttachStudents { get; set; }
        //public DbSet<wx_UserContactDetail> wx_UserContactDetails { get; set; }
        //public DbSet<wx_UserInfo> wx_UserInfos { get; set; }
        //public DbSet<wx_Activity1> wx_Activity1s { get; set; }
        //public DbSet<wx_Activity2> wx_Activity2s { get; set; }
        //public DbSet<wx_Activity3> wx_Activity3s { get; set; }
        //public DbSet<wx_Activity4> wx_Activity4s { get; set; }
        //public DbSet<wx_Activity5> wx_Activity5s { get; set; }
        //public DbSet<wx_Activity6> wx_Activity6s { get; set; }
        //public DbSet<wx_Activity7> wx_Activity7s { get; set; }
        //public DbSet<wx_Activity8> wx_Activity8s { get; set; }
        //public DbSet<wx_Activity9> wx_Activity9s { get; set; }
        //public DbSet<wx_Activity10> wx_Activity10s { get; set; }
        //public DbSet<wx_Activity11> wx_Activity11s { get; set; }
        //public DbSet<wx_Activity12> wx_Activity12s { get; set; }
        //public DbSet<wx_Activity13> wx_Activity13s { get; set; }
        //public DbSet<wx_Activity14> wx_Activity14s { get; set; }
        //public DbSet<wx_Activity15> wx_Activity15s { get; set; }
        //public DbSet<wx_Activity16> wx_Activity16s { get; set; }
        //public DbSet<wx_Activity17> wx_Activity17s { get; set; }
        //public DbSet<wx_Activity18> wx_Activity18s { get; set; }
        //public DbSet<wx_Activity19> wx_Activity19s { get; set; }
        //public DbSet<wx_Activity20> wx_Activity20s { get; set; }
        //public DbSet<wx_Activity21> wx_Activity21s { get; set; }
        //public DbSet<wx_Activity22> wx_Activity22s { get; set; }
        //public DbSet<wx_Activity23> wx_Activity23s { get; set; }

        //public DbSet<wx_Activity24> wx_Activity24s { get; set; }
        //public DbSet<wx_Activity25> wx_Activity25s { get; set; }
        //public DbSet<wx_Activity26> wx_Activity26s { get; set; }
        //public DbSet<wx_Activity27> wx_Activity27s { get; set; }
        //public DbSet<wx_Activity28> wx_Activity28s { get; set; }
        //public DbSet<wx_Activity29> wx_Activity29s { get; set; }
        //public DbSet<wx_Activity30> wx_Activity30s { get; set; }
        //public DbSet<wx_Activity31> wx_Activity31s { get; set; }
        //public DbSet<wx_Activity32> wx_Activity32s { get; set; }
        //public DbSet<wx_Activity33> wx_Activity33s { get; set; }
        //public DbSet<wx_Activity34> wx_Activity34s { get; set; }

        public MasterpieceDBContextPart1() : base("AbhsChineseDBContext")
        {
            Database.SetInitializer<MasterpieceDBContext>(null);
            this.Configuration.AutoDetectChangesEnabled = false;
            this.Configuration.ValidateOnSaveEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //string assembleFileName = Assembly.GetExecutingAssembly().CodeBase.Replace("AbhsChinese.Data.DLL", "AbhsChinese.Mapping.DLL").Replace("file:///", "");
            //Assembly asm = Assembly.LoadFile(assembleFileName);

            //var typesToRegister = asm.GetTypes()
            //.Where(type => !String.IsNullOrEmpty(type.Namespace))
            //.Where(type => type.BaseType != null
            //&& type.BaseType.IsGenericType
            //&& type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));

            //foreach (var type in typesToRegister)
            //{
            //    dynamic configurationInstance = Activator.CreateInstance(type);
            //    modelBuilder.Configurations.Add(configurationInstance);
            //}
            //base.OnModelCreating(modelBuilder);
        }
    }
}