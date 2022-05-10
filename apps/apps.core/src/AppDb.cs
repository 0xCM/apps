//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class AppDb : AppService<AppDb>
    {
        FS.FolderPath Root;

        public AppDb WithRoot(FS.FolderPath root)
        {
            var dst = AppDb.create(Wf);
            dst.Root = root;
            return dst;
        }

        protected override void Initialized()
        {
            Root = ProjectDb.Root;
        }

        [MethodImpl(Inline)]
        public DbTargets Targets(string scope)
            => new DbTargets(Root, scope);

        public DbSources Sources()
            => new DbSources(Root, "sources");

        public DbSources Sources(string scope)
            => Sources().Scoped(scope);

        public DbTargets LangTargets()
            => Targets("lang");

        public DbTargets SdeTargets()
            => Targets("sde");

        public DbSources IntelSources()
            => Sources("intel");

        public DbSources CpuIdSources()
            => IntelSources().Scoped("sde.cpuid");

        public DbSources IntelNotationDocs()
            => IntelSources().Scoped("notation");

        public DbSources IntelEncodingDocs()
            => IntelSources().Scoped("encoding");

        public DbSources MsSources()
            => IntelSources().Scoped("ms");

        public DbTargets Api()
            => Targets("api");

        public DbTargets Logs()
            => Targets("logs");

        public DbTargets CgStage()
            => Targets("cgstage");
    }
}