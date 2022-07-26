//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = CmdScripts;

    /// <summary>
    /// Defines a tool execution specification
    /// </summary>
    public class ToolCmdSpec : IToolCmd
    {
        public readonly Actor Tool;

        public readonly Name CmdName;

        public readonly ToolCmdArgs Args;

        [MethodImpl(Inline)]
        public ToolCmdSpec(Actor tool, Name cmd, params ToolCmdArg[] args)
        {
            Tool = tool;
            CmdName = cmd;
            Args = args;
        }

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        public static ToolCmdSpec Empty
        {
            [MethodImpl(Inline)]
            get => new ToolCmdSpec(Actor.Empty, EmptyString);
        }

        Name IToolCmd.CmdName
            => CmdName;

        ToolCmdArgs IToolCmd.Args
            => Args;
    }
}