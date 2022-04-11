//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        public readonly record struct RexIndicator : IComparable<RexIndicator>
        {
            public static RexIndicator W => new RexIndicator('w');

            public static RexIndicator R => new RexIndicator('r');

            public static RexIndicator X => new RexIndicator('x');

            public static RexIndicator B => new RexIndicator('b');

            public static int order(char c)
            {
                var result = 0;
                switch(c)
                {
                    case 'W':
                    case 'w':
                        result = 4;
                    break;
                    case 'R':
                    case 'r':
                        result = 3;
                    break;
                    case 'X':
                    case 'x':
                        result = 2;
                    break;
                    case 'B':
                    case 'b':
                        result = 1;
                    break;
                }
                return result;
            }

            public static RexIndicator parse(char c)
            {
                var dst = RexIndicator.Empty;
                switch(c)
                {
                    case 'W':
                    case 'w':
                    case 'R':
                    case 'r':
                    case 'X':
                    case 'x':
                    case 'B':
                    case 'b':
                        dst = new RexIndicator(c);
                    break;
                }
                return dst;
            }

            public static bool parse(char c, out RexIndicator dst)
            {
                dst = parse(c);
                return dst.IsNonEmpty;
            }

            readonly byte Data;

            [MethodImpl(Inline)]
            internal RexIndicator(char c)
            {
                Data = (byte)Char.ToLower(c);
            }

            public char Symbol
            {
                [MethodImpl(Inline)]
                get => (char)Data;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Data == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Data != 0;
            }

            public string Format()
                => Symbol.ToString();

            public override string ToString()
                => Format();

            public int CompareTo(RexIndicator src)
            {
                var a = order(Symbol);
                var b = order(src.Symbol);
                return a.CompareTo(b);
            }

            [MethodImpl(Inline)]
            public static explicit operator byte(RexIndicator src)
                => src.Data;

            public static RexIndicator Empty => default;
        }
    }
}