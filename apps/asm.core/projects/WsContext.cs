//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    public class WsContext
    {
        public static WsContext create(IProjectWs project, ToolFlowIndex flows, WsEventReceiver receiver = null)
            => new WsContext(project, FileCatalog.load(project), flows, receiver);

        public IProjectWs Project {get;}

        public FileCatalog Files {get;}

        public ToolFlowIndex Flows {get;}

        public WsEventReceiver EventReceiver {get;}

        public WsContext(IProjectWs project, FileCatalog files, ToolFlowIndex flows, WsEventReceiver receiver = null)
        {
            Project = project;
            Files = files;
            Flows = flows;
            EventReceiver = receiver ?? new();
        }

        public FileRef FileRef(FS.FilePath path)
            => Files[path];

        public FileRef FileRef(uint docid)
            => Files[docid];
    }
}