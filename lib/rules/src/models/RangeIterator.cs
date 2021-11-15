//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct RuleModels
    {
        public readonly struct RangeIterator
        {
            public long Step {get;}

            [MethodImpl(Inline)]
            public RangeIterator(long step)
            {
                Step = step;
            }
        }
    }
}