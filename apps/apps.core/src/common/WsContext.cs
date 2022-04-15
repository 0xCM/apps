//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    public class WsContext
    {
        public static WsContext create(IProjectProvider projects, IProjectWs project, WsDataFlows flows)
            => new WsContext(projects, project, flows);

        public IProjectProvider Projects {get;}

        public IProjectWs Project {get;}

        public FileCatalog Catalog {get;}

        public WsDataFlows Flows {get;}

        WsContext(IProjectProvider projects, IProjectWs project, WsDataFlows flows)
        {
            Projects = projects;
            Project = project;
            Catalog = flows.FileCatalog;
            Flows = flows;
        }

        public Index<FileRef> Files(FileKind k)
            => Catalog.Entries(k);

        public Index<FileRef> Files(FileKind k0, FileKind k1)
            => Catalog.Entries(k0,k1);

        public Index<FileRef> Files(FileKind k0, FileKind k1, FileKind k2)
            => Catalog.Entries(k0,k1,k2);

        public FileRef Ref(FS.FilePath path)
            => Catalog[path];

        public FileRef File(uint docid)
            => Catalog[docid];

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