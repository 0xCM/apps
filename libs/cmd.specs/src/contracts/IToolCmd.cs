//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IToolCmd : IExecCmd
    {
        CmdId CmdId {get;}

        string CmdName {get;}

        ToolCmdArgs Args {get;}
    }

    [Free]
    public interface IToolCmd<C> : IToolCmd
        where C : struct, IToolCmd<C>
    {
        CmdId IToolCmd.CmdId
            => CmdTypes.identify<C>();

        ToolCmdArgs IToolCmd.Args
            => ToolCmdArgs.args((C)this);
    }
}