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
        public DbTargets Targets()
            => new DbTargets(Root, EmptyString);

        [MethodImpl(Inline)]
        public DbTargets Targets(string scope)
            => new DbTargets(Root, scope);

        public DbSources Sources(string scope)
            => new DbSources(Root, scope);
    }
}