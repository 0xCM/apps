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

        Name<asci64> IActor.Name
            => ToolId.Name;
    }
}