//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IToolCmd : IExecCmd
    {
        Name CmdName => default;

        ToolCmdArgs Args => ToolCmdArgs.Empty;
    }

    [Free]
    public interface IToolCmd<C> : IToolCmd
        where C : struct, IToolCmd<C>
    {


    }
}