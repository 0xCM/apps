//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    using static XedModels;

    public sealed class XedRegMap
    {
        static RegMapEntry entry(XedRegId id, RegOp reg)
        {
            var dst = default(RegMapEntry);
            dst.RegId = (ushort)id;
            dst.RegClass = reg.RegClass;
            dst.RegSize = reg.Size;
            dst.RegName = reg.Name;
            dst.RegIndex = reg.Index;
            return dst;
        }

        ConstLookup<XedRegId,RegOp> LookupData;

        Index<RegMapEntry> EntryData;

        internal XedRegMap(ConstLookup<XedRegId,RegOp> src)
        {
            LookupData = src;
            EntryData = map(src.Entries,x => entry(x.Key, x.Value));
        }

        public RegOp Map(XedRegId id)
            => LookupData[id];

        public ReadOnlySpan<RegMapEntry> Entries
        {
            [MethodImpl(Inline)]
            get => EntryData;
        }

        public ReadOnlySpan<RegOp> MappedRegs
        {
            [MethodImpl(Inline)]
            get => LookupData.Values;
        }
    }
}