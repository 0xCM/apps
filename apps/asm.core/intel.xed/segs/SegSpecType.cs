//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct SegSpecType
        {
            public readonly byte Id;

            [MethodImpl(Inline)]
            public SegSpecType(byte id)
            {
                Id = id;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Id == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Id != 0;
            }

            public string Format()
                => SegSpecs.find(this).Format();

            public override string ToString()
                => Format();

            public static SegSpecType Empty => default;
        }
    }
}