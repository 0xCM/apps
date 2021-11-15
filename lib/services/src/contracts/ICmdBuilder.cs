//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ICmdBuilder : ITextual
    {
        ToolCmdSpec Emit(bool clear = true);

        ToolId Tool {get;}
    }
}