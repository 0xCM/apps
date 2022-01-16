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

        FileIndex Files {get;}

        public ProjectEventReceiver EventReceiver {get;}

        public ProjectCollection(IProjectWs project, FileIndex files, ProjectEventReceiver receiver)
        {
            Project = project;
            Files = files;
            EventReceiver = receiver;
        }

        public FileRef File(FS.FilePath path)
            => Files[path];

        public FileRef File(uint docid)
            => Files[docid];
    }
}