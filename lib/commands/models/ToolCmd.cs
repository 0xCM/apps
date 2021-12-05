//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;


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

        public string Format()
            => Cmd.format(this);

        public override string ToString()
            => Format();

        public static ToolCmd Empty
        {
            [MethodImpl(Inline)]
            get => new ToolCmd(CmdId.Empty);
        }
    }
}