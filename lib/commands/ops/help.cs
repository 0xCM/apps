//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Cmd
    {
        [MethodImpl(Inline), Op]
        public static ToolHelp help(ToolId tool, string doc, string description, CmdOptionSpec[] options)
            => new ToolHelp(tool, doc, description, options);
    }
}