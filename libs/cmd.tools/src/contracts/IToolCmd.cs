//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IToolCmd : IExecCmd
    {
        Name CmdName {get;}

        ToolCmdArgs Args {get;}
    }
}