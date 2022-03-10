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
        public static XedRegMap Service => Instance;

        static XedRegMap create()
        {
            var symsrc = Symbols.index<XedRegId>();
            var symdst = Symbols.index<RegKind>();
            var dst = dict<XedRegId,RegOp>();

            var a = Symbols.index<RegKind>().View.Map(x => (x.Expr.Format(), x.Kind)).ToDictionary();
            var b = Symbols.index<XedRegId>().View;
            foreach(var xedreg in b)
            {
                var match = xedreg.Expr.Format().ToLower();
                if(a.TryGetValue(match, out var kind))
                    dst[xedreg.Kind] = kind;
            }

            return new XedRegMap(dst);
        }

        static RegMapEntry entry(XedRegId id, RegOp reg)
        {
            var dst = default(RegMapEntry);
            dst.RegId = (ushort)id;
            dst.RegClass = reg.RegClass;
            dst.RegSize = reg.Size;
            dst.RegName = reg.Name;
            dst.RegIndex = (byte)reg.Index;
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
        {
            if(LookupData.Find(id, out var reg))
                return reg;
            else
                return RegOp.Empty;
        }

        public bool Map(XedRegId id, out RegOp dst)
            => LookupData.Find(id, out dst);

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

        static XedRegMap Instance = create();
    }
}