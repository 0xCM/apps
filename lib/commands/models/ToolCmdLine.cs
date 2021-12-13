//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;

    using static Root;

    public struct ToolCmdLine : IComparable<ToolCmdLine>
    {
        public ToolId Tool {get;}

        public CmdModifier Modifier {get;}

        public CmdLine Command {get;}

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