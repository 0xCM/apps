//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    public class ProjectCollection
    {
        public IProjectWs Project {get;}

        public FileCatalog Files {get;}

        public ProjectEventReceiver EventReceiver {get;}

        public ProjectCollection(IProjectWs project, FileCatalog files, ProjectEventReceiver receiver)
        {
            Project = project;
            Files = files;
            EventReceiver = receiver;
        }

        public FileRef FileRef(FS.FilePath path)
            => Files[path];

        public FileRef FileRef(uint docid)
            => Files[docid];
    }
}