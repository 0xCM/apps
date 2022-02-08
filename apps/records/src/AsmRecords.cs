//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct AsmRecords
    {
        [MethodImpl(Inline)]
        public static CorrelationToken token(uint docid, Address32 ip)
            => math.or(math.sll(docid, 24),  (uint)ip);
    }
}