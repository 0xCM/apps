//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ITool : IActor
    {
        Actor ToolId {get;}

        Name IActor.Name
            => ToolId.Name;
    }
}