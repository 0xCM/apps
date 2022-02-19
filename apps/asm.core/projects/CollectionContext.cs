//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    public class CollectionContext
    {
        public static CollectionContext create(IProjectWs project, CollectionEventReceiver receiver = null)
            => new CollectionContext(project, FileCatalog.load(project), receiver);

        public IProjectWs Project {get;}

        public FileCatalog Files {get;}

        public CollectionEventReceiver EventReceiver {get;}

        public CollectionContext(IProjectWs project, FileCatalog files, CollectionEventReceiver receiver = null)
        {
            Project = project;
            Files = files;
            EventReceiver = receiver ?? new();
        }

        public FileRef FileRef(FS.FilePath path)
            => Files[path];

        public FileRef FileRef(uint docid)
            => Files[docid];
    }
}