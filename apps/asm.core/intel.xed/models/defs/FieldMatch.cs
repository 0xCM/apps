//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedFields
    {
        public readonly struct FieldMatch
        {
            readonly Vector256<byte> Entries;

            [MethodImpl(Inline)]
            internal FieldMatch(Vector256<byte> src)
            {
                Entries = src;
            }

            [MethodImpl(Inline)]
            public FieldKind Entry(uint5 index)
                => (FieldKind)cpu.vcell(Entries,index);

            public FieldKind this[uint5 index]
            {
                [MethodImpl(Inline)]
                get => Entry(index);
            }
        }
    }
}