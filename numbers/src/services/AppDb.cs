//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class AppDb : AppService<AppDb>
    {
        FS.FolderPath WsRoot;

        FS.FolderPath ProjectRoot;

        FS.FolderPath ProjectDbRoot;

        public DbTargets Projects()
            => new DbTargets(ProjectRoot,EmptyString);

        public DbTargets Project(string name)
            => Projects().Targets(name);

        protected override void Initialized()
        {
            WsRoot = Ws.Root;
            ProjectRoot = WsRoot + FS.folder("projects");
            ProjectDbRoot = ProjectRoot + FS.folder("db");
        }

        public DbTargets CgTarget(CgTarget dst)
            => new DbTargets(Env.DevRoot + FS.folder($"codegen/{Symbols.format(dst)}/src"));

        [MethodImpl(Inline)]
        public DbTargets Targets()
            => new DbTargets(ProjectDbRoot, EmptyString);

        [MethodImpl(Inline)]
        public DbTargets Targets(string scope)
            => new DbTargets(ProjectDbRoot, scope);

        public DbSources Sources(string scope)
            => new DbSources(ProjectDbRoot + FS.folder("sources"), scope);
    }
}