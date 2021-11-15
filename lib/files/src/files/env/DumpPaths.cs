//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static core;

    public readonly struct DumpPaths
    {
        public FS.FolderPath InputRoot {get;}

        public FS.FolderPath OutputRoot {get;}

        public DumpPaths(FS.FolderPath input, FS.FolderPath output)
        {
            InputRoot = input;
            OutputRoot = output;
        }

        public FS.FolderPath OutputDir(ProcDumpIdentity id)
            => OutputRoot + FS.folder(id.Format());

        public ReadOnlySpan<FS.FilePath> DumpFiles()
            => InputRoot.Files(FS.Dmp).Sort();

        public FS.FilePath CurrentDump()
        {
            var files = DumpFiles();
            var count = files.Length;
            if(count != 0)
                return skip(files, count - 1);
            else
                return FS.FilePath.Empty;
        }
    }
}