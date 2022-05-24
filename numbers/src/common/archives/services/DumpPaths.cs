//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct DumpPaths
    {
        public readonly FS.FolderPath InputRoot {get;}

        public readonly FS.FolderPath OutputRoot {get;}

        [MethodImpl(Inline)]
        public DumpPaths(FS.FolderPath input, FS.FolderPath output)
        {
            InputRoot = input;
            OutputRoot = output;
        }

        public FS.FolderPath Targets(ProcDumpIdentity id)
            => OutputRoot + FS.folder(id.Format());

        public ReadOnlySpan<FS.FilePath> Files()
            => InputRoot.Files(FS.Dmp).Sort();

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