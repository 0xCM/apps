//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static WsNames;

    public sealed class DevWs : IWorkspaceObselete<DevWs>
    {
        [MethodImpl(Inline)]
        public static DevWs create(FS.FolderPath root)
            => new DevWs(root);

        FS.FolderPath _WsRoot;

        [MethodImpl(Inline)]
        DevWs(FS.FolderPath root)
        {
            _WsRoot = root;
        }

        public FS.FolderPath Root
        {
            [MethodImpl(Inline)]
            get => _WsRoot;
        }

        public IProjectDb ProjectDb()
            => ProjectDbWs.create(FS.dir("d:/views/db/targets"));

        public IWorkspaceObselete Gen()
            => GenWs.create(_WsRoot + FS.folder(gen));

        public string Format()
            => _WsRoot.Format();

        public override string ToString()
            => Format();
    }
}