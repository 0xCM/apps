//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static core;

    partial class XedRules
    {
        public readonly struct BitfieldSpec
        {
            public readonly BfSpecKind Kind;

            public readonly asci16 Pattern;

            [MethodImpl(Inline)]
            public BitfieldSpec(ReadOnlySpan<byte> src)
            {
                if(src.Length != 0)
                    Kind = (BfSpecKind)skip(src,0);
                else
                    Kind = 0;
                if(src.Length > 1)
                    Pattern = new(slice(src,1));
                else
                    Pattern = asci16.Null;
            }

            [MethodImpl(Inline)]
            public BitfieldSpec(BfSpecKind kind, string src)
            {
                Kind = kind;
                Pattern = src;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Kind == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Kind != 0;
            }

            public string Format()
                => IsNonEmpty ? Pattern.Format() : EmptyString;

            public override string ToString()
                => Format();

            public static BitfieldSpec Empty => new BitfieldSpec(0,EmptyString);
        }
    }
}