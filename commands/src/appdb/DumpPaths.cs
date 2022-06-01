//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct DumpPaths
    {
        public readonly FS.FolderPath Root {get;}

        [MethodImpl(Inline)]
        public DumpPaths(FS.FolderPath input, FS.FolderPath output)
        {
            Root = output;
        }

        public FS.FolderPath Targets(ProcDumpIdentity id)
            => Root + FS.folder(id.Format());

        public ReadOnlySpan<FS.FilePath> Files()
            => Root.Files(FS.Dmp).Sort();

        public FS.FilePath Current()
        {
            var files = Files();
            var count = files.Length;
            if(count != 0)
                return skip(files, count - 1);
            else
                return FS.FilePath.Empty;
        }
    }
}