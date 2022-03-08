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

        public WsEventReceiver Receiver {get;}

        WsContext(IProjectWs project, WsDataFlows flows, WsEventReceiver receiver = null)
        {
            Project = project;
            Files = flows.FileCatalog;
            Flows = flows;
            Receiver = receiver ?? new();
            Receiver.Initialized(this);
        }

        public FileRef FileRef(FS.FilePath path)
            => Files[path];

        public FileRef FileRef(uint docid)
            => Files[docid];

        public FileRef Root(in FS.FilePath dst)
        {
            if(Flows.Root(dst, out var src))
                return src;
            else
                return Z0.FileRef.Empty;
        }

        public FileRef Root(in FileRef dst)
        {
            if(Flows.Root(dst.Path, out var src))
                return src;
            else
                return Z0.FileRef.Empty;
        }
    }
}