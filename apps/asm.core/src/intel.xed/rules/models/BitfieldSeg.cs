//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct BitfieldSeg
        {
            public readonly FieldKind Field;

            public readonly text7 Pattern;

            [MethodImpl(Inline)]
            public BitfieldSeg(FieldKind field,text7 pattern)
            {
                Field = field;
                Pattern = pattern;
            }

            public string Format()
                => format(this);

            public override string ToString()
                => Format();
        }
    }
}