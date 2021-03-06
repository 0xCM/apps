//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class text
    {
        [Op]
        public static ClosedInterval<int> enclosed(string src, int offset, Fence<char> fence)
            => enclosed(span(src),offset,fence);

        [Op]
        public static ClosedInterval<int> enclosed(ReadOnlySpan<char> src, int offset, Fence<char> fence)
        {
            const uint Searching = 0;
            const uint FoundLeft = 1;
            const uint MatchedRight = 2;
            var count = src.Length;
            var state = Searching;
            var lCount = 0u;
            var rCount = 0u;
            var i0 = 0;
            var i1 = 0;
            for(var i=offset; i<count; i++)
            {
                ref readonly var c = ref core.skip(src,i);
                switch(state)
                {
                    case Searching:
                        if(c == fence.Left)
                        {
                            state = FoundLeft;
                            lCount++;
                            i0 = i;
                        }
                    break;
                    case FoundLeft:
                        if(c == fence.Left)
                            lCount++;
                        else if(c == fence.Right)
                        {
                            rCount++;
                            if((lCount - rCount) == 0)
                            {
                                state = MatchedRight;
                            }
                        }
                    break;
                }

                if(state == MatchedRight)
                {
                    i1 = i;
                    break;
                }
            }
            return i1 - i0 > 0 ? (i0 + 1, i1 - 1) : (0,0);
        }
    }
}