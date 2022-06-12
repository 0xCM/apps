//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    public static class XAppDb
    {
        const string xed = "xed";

        public static ITargetArchive CgStage(this IAppDb db)
            => db.Targets("cgstage");

        public static ITargetArchive CgStage(this IAppDb db, string scope)
            => db.Targets($"cgstage/{scope}");

        public static ISourceArchive IntelSources(this IAppDb db)
            => db.Sources("intel");

        public static ITargetArchive IntelTargets(this IAppDb db)
            => db.Targets("intel");

        public static ITargetArchive SdeTargets(this IAppDb db)
            => db.Targets().Targets("sde");

        public static ITargetArchive LlvmTargets(this IAppDb db)
            => db.Targets("llvm");

        public static ISourceArchive LlvmSources(this IAppDb db)
            => db.Sources("llvm");

        public static ITargetArchive ApiTargets(this IAppDb db, string scope)
            => db.Targets($"api/{scope}");

        public static ITargetArchive MsilTargets(this IAppDb db)
            => db.ApiTargets("msil");

        public static ITargetArchive MsilTargets(this IAppDb db, string scope)
            => db.ApiTargets($"msil/{scope}");

        public static ISourceArchive CpuIdSources(this IAppDb db)
            => db.IntelSources().Sources("sde.cpuid");
    }
}