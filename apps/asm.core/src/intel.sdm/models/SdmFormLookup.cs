//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    public class SdmFormLookup
    {
        readonly ConstLookup<Identifier,Index<AsmFormRecord>> Data;

        public SdmFormLookup(Dictionary<Identifier,List<AsmFormRecord>> src)
        {
            Data = src.Map(x => (x.Key, (Index<AsmFormRecord>)x.Value.ToArray())).ToDictionary();
        }

        public ReadOnlySpan<Identifier> Kinds
        {
            [MethodImpl(Inline)]
            get => Data.Keys;
        }

        public Index<AsmFormRecord> this[Identifier kind]
        {
            [MethodImpl(Inline)]
            get => Data[kind];
        }

        public Index<AsmFormRecord> Linearize()
            => core.map(Data.Values, x => x.Storage).SelectMany(x => x).Sort();
    }
}