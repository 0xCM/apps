//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Tooling
    {
        [Op]
        public static ToolCmdSpec spec(FS.FilePath path, params ToolCmdArg[] args)
        {
            var dst = new ToolCmdSpec();
            dst.ToolPath = path;
            dst.Args = args.Select(x => x.Format());
            return dst;
        }
    }
}