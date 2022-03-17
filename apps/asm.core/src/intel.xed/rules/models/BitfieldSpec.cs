//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct BitfieldSpec
        {
            public readonly asci16 Pattern;

            [MethodImpl(Inline)]
            public BitfieldSpec(string src)
            {
                Pattern = src;
            }

            public string Format()
                => Pattern.Format();

            public override string ToString()
                => Format();
        }
    }
}