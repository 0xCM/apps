//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    public class WsContext
    {
        public static WsContext create(IProjectWs project, WsDataFlows flows, WsEventReceiver receiver = null)
            => new WsContext(project, flows, receiver);

        public IProjectWs Project {get;}

        public FileCatalog Files {get;}

        public WsDataFlows Flows {get;}

        public WsEventReceiver EventReceiver {get;}

        WsContext(IProjectWs project, WsDataFlows flows, WsEventReceiver receiver = null)
        {
            Project = project;
            Files = flows.FileCatalog;
            Flows = flows;
            EventReceiver = receiver ?? new();
        }

        public FileRef FileRef(FS.FilePath path)
            => Files[path];

        public FileRef FileRef(uint docid)
            => Files[docid];

        public bool Root(FS.FilePath dst, out FileRef src)
            => Flows.Root(dst, out src);
    }
}