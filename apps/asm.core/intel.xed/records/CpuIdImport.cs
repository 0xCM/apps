//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [StructLayout(StructLayout,Pack=1),Record(TableId)]
        public record struct CpuIdImport : IComparable<CpuIdImport>, ISequential<CpuIdImport>
        {
            public const string TableId = "cpuid.imported";

            [Render(6)]
            public ushort Seq;

            [Render(64)]
            public asci64 Definition;

            [Render(32)]
            public asci32 Isa;

            [MethodImpl(Inline)]
            public CpuIdImport(asci32 isa, uint key, asci64 spec)
            {
                Seq = 0;
                Definition = spec;
                Isa = isa;
            }

            uint ISequential.Seq
            {
                get => Seq;
                set => Seq = (ushort)value;
            }

            public int CompareTo(CpuIdImport src)
            {
                var result = Definition.CompareTo(src.Definition);
                return result;
            }
        }
    }
}