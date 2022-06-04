//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class DumpBin
    {
        public static CmdScript script<T>(DumpBin tool, string name, CmdId id, Index<T> src, FS.FolderPath outdir)
            where T : IFileModule
        {
            var buffer = text.buffer();
            foreach(var module in src)
            {
                var cmd = tool.Command(id, module.Path, outdir);
                buffer.AppendLine(cmd.Format());
            }

            return CmdScript.create(name, buffer.Emit());
        }
    }
}