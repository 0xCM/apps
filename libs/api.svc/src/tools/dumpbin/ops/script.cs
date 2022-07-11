//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class DumpBin
    {
        public static CmdScript script<T>(DumpBin tool, string script, CmdName name, ReadOnlySeq<T> src, FS.FolderPath outdir)
            where T : IFileModule
        {
            var buffer = text.buffer();
            foreach(var module in src)
            {
                var cmd = tool.Command(name, module.Path, outdir);
                buffer.AppendLine(cmd.Format());
            }

            return CmdScripts.create(script, buffer.Emit());
        }
    }
}