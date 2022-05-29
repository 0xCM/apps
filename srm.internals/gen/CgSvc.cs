//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CgSvc : AppService<CgSvc>
    {
        public CgSvc()
        {
        }

        public ShellGen Shells()
            => Service(() => ShellGen.create(Wf));

        public FS.FolderPath CodeGenDir(string scope)
            => Env.ZDev + FS.folder("generated/src") + FS.folder(scope);

    }
}