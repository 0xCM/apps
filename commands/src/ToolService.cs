//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class ToolService<T> : AppService<T>
        where T : ToolService<T>, new()
    {
        public virtual ToolId Id {get;}

        protected OmniScript OmniScript => Service(() => Z0.OmniScript.create(Wf));

        protected ToolService(ToolId id)
        {
            Id = id;
        }

        protected ToolService()
        {

        }

        protected FS.FolderPath Home
            => Env.DevWs + FS.folder("tools") + FS.folder(Id.Format());

        public FS.FolderPath OutDir
            => Paths.ToolOutDir(Id);

        public FS.FilePath Script(FS.FolderPath dir, FS.FileName name)
            => dir + name;

        public FS.FilePath Output(FS.FileName name)
            => OutDir + name;

        public virtual FS.FilePath ToolPath()
            => FS.path(string.Format("{0}.{1}", Id.Format(), FS.Exe));

        protected static string format(FS.FilePath src)
            => src.Format(PathSeparator.BS);

        protected static FS.FilePath input(FS.FolderPath dir, FS.FileName name)
            => dir + name;

        protected static FS.FilePath output(FS.FolderPath dir, FS.FileName name)
            => dir + name;

        protected static FS.FileName file(Identifier src, FS.FileExt ext)
            => FS.file(src.Format(), ext);

        protected static FS.FileName binfile(Identifier src)
            => file(src, FS.Bin);

        protected FS.FileName ToolFile(Identifier id,  Identifier discriminator, FS.FileExt ext)
            => FS.file(string.Format("{0}.{1}.{2}", id, Id, discriminator), ext);
    }
}