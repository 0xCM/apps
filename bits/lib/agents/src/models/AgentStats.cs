//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public struct AgentStats
    {
        public readonly int AgentCount;

        [MethodImpl(Inline)]
        public AgentStats(int count)
        {
            AgentCount = count;
        }
    }
}