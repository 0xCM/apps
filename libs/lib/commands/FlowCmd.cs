//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct FlowCmd : IFlowCmd
    {
        public IActor Actor {get;}

        [MethodImpl(Inline)]
        public FlowCmd(IActor actor)
        {
            Actor = actor;
        }
    }
}