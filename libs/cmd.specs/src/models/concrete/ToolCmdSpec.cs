//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a tool execution specification
    /// </summary>
    public struct ToolCmdSpec : IToolCmd
    {
        public readonly Actor Tool {get;}

        public readonly CmdId CmdId {get;}

        public readonly ToolCmdArgs Args {get;}

        [MethodImpl(Inline)]
        public ToolCmdSpec(Actor tool, CmdId cmd, params ToolCmdArg[] args)
        {
            Tool = tool;
            CmdId = cmd;
            Args = args;
        }

        public string CmdName
        {
            [MethodImpl(Inline)]
            get => CmdId.Format();
        }

        public string Format()
            => ToolCmd.format(this);

        public override string ToString()
            => Format();

        public static ToolCmdSpec Empty
        {
            [MethodImpl(Inline)]
            get => new ToolCmdSpec(Actor.Empty, CmdId.Empty);
        }
    }
}