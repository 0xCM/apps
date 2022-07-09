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
}