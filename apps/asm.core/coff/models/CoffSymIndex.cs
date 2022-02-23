//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CoffSymIndex
    {
        readonly Index<CoffSection> SectionData;

        readonly Index<CoffSymRecord> SymData;

        public CoffSymIndex(CoffSection[] sections, CoffSymRecord[] syms)
        {
            SectionData = sections;
            SymData = syms;
        }

        [MethodImpl(Inline)]
        public ReadOnlySpan<CoffSymRecord> Symbols()
            => SymData;

        [MethodImpl(Inline)]
        public ReadOnlySpan<CoffSymRecord> Symbols(Hex32 doc)
            => SymData.Where(x => x.DocId == doc);

        [MethodImpl(Inline)]
        public ReadOnlySpan<CoffSymRecord> Symbols(Hex32 docid, ushort section)
            => SymData.Where(x => x.DocId == docid && x.SectionNumber == section);

        [MethodImpl(Inline)]
        public ReadOnlySpan<CoffSection> Sections()
            => SectionData;

        public bool Symbol(Hex32 docid, Address32 address, out CoffSymRecord dst)
        {
            var result = false;
            dst = default;
            for(var i=0; i<SymData.Count; i++)
            {
                ref readonly var sym = ref SymData[i];
                if(sym.DocId == docid && sym.Address == address)
                {
                    dst = sym;
                    result = true;
                    break;

                }
            }
            return result;
        }
    }

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly struct CoffSymId : IEquatable<CoffSymId>
    {
        internal readonly Hex32 DocId;

        internal readonly uint Section;

        internal readonly Address32 Address;

        readonly Hash32 HashCode;

        [MethodImpl(Inline)]
        internal CoffSymId(Hex32 doc, ushort section, Address32 address)
        {
            DocId = doc;
            Section = section;
            Address = address;
            HashCode = alg.hash.combine(((uint)Address & 0xFFFFFF) | (Section << 24), DocId);
        }

        public override int GetHashCode()
            => HashCode;

        [MethodImpl(Inline)]
        public bool Equals(CoffSymId src)
            => DocId == src.DocId && Section == src.Section && Address == src.Address;

        public override bool Equals(object src)
            => src is CoffSymId x && Equals(x);

    }
}