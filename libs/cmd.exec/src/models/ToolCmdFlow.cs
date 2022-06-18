//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class ToolCmdFlow<S,T> : DataFlow<Tool,S,T>
    {
        public ToolCmdFlow(Tool tool, S src, T dst)
            : base(tool, src, dst)
        {

        }
    }
}