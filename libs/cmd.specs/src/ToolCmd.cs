//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a tool execution specification
    /// </summary>
    public struct ToolCmd : IToolCmd
    {
        public CmdId CmdId {get;}

        public ToolCmdArgs Args {get;}

        [MethodImpl(Inline)]
        public ToolCmd(CmdId id, params ToolCmdArg[] args)
        {
            CmdId = id;
            Args = args;
        }

        public string CmdName
        {
            [MethodImpl(Inline)]
            get => CmdId.Format();
        }

        public string Format()
            => ToolCmdArgs.format(this);

        public override string ToString()
            => Format();

        public static ToolCmd Empty
        {
            [MethodImpl(Inline)]
            get => new ToolCmd(CmdId.Empty);
        }
    }
}