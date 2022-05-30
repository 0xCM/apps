//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IToolCmd
    {
        CmdId CmdId {get;}

        string CmdName {get;}

        ToolCmdArgs Args {get;}
    }

    [Free]
    public interface IToolCmd<C> : IToolCmd
        where C : struct, IToolCmd
    {
        CmdId IToolCmd.CmdId
            => CmdId.from<C>();

        ToolCmdArgs IToolCmd.Args
            => Cmd.toolargs((C)this);
    }
}