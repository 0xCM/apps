//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    public class SdmFormLookup
    {
        readonly ConstLookup<Identifier,Index<SdmFormRecord>> Data;

        public SdmFormLookup(Dictionary<Identifier,List<SdmFormRecord>> src)
        {
            Data = src.Map(x => (x.Key, (Index<SdmFormRecord>)x.Value.ToArray())).ToDictionary();
        }

        public ReadOnlySpan<Identifier> Kinds
        {
            [MethodImpl(Inline)]
            get => Data.Keys;
        }

        public Index<SdmFormRecord> this[Identifier kind]
        {
            [MethodImpl(Inline)]
            get => Data[kind];
        }

        public Index<SdmFormRecord> Linearize()
            => core.map(Data.Values, x => x.Storage).SelectMany(x => x).Sort();
    }
}