//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct ToolCmdLine : IComparable<ToolCmdLine>
    {
        [MethodImpl(Inline), Op]
        public static ToolCmdLine define(ToolId tool, params string[] src)
            => new ToolCmdLine(tool, Cmd.cmdline(src));

        [MethodImpl(Inline), Op]
        public static ToolCmdLine define(ToolId tool, CmdModifier modifier, params string[] src)
            => new ToolCmdLine(tool, modifier, Cmd.cmdline(src));

        public readonly ToolId Tool;

        public readonly CmdModifier Modifier;

        public readonly CmdLine Command;

        [MethodImpl(Inline)]
        public ToolCmdLine(ToolId tool, CmdLine cmd)
        {
            Tool = tool;
            Modifier = EmptyString;
            Command = cmd;
        }

        [MethodImpl(Inline)]
        public ToolCmdLine(ToolId tool, CmdModifier modifier, CmdLine cmd)
        {
            Tool = tool;
            Modifier = modifier;
            Command = cmd;
        }

        public string Format()
            => Command.Format();

        public override string ToString()
            => Format();

        public int CompareTo(ToolCmdLine src)
            => Tool.CompareTo(src.Tool);
    }
}