//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using C = Chars;

    partial struct Char5
    {
        const byte Base = 'a' - 1;

        const byte FirstLetter = 1;

        const byte FirstSymbol = FirstLetter + 26;

        const byte CharCount = 32;

        public static ReadOnlySpan<Code> Codes
            => new Code[CharCount]{
                Code.Null, Code.A, Code.B, Code.C, Code.D, Code.E, Code.F, Code.G, Code.H, Code.I,
                Code.J, Code.K, Code.L, Code.M, Code.N, Code.O, Code.P, Code.Q, Code.R, Code.S, Code.T,
                Code.U, Code.V, Code.W, Code.X, Code.Y, Code.Z, Code._, Code.Null,Code.Null, Code.Null, Code.Null,
                };

        static ReadOnlySpan<byte> AsciCodes
            => new byte[CharCount]{
                0, 97, 98, 99, 100, 101, 102, 103, 104, 105,
                106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116,
                117, 118, 119, 120, 121, 122, 95, 0,0, 0, 0,
                };

        static ReadOnlySpan<char> AsciChars
            => new char[CharCount]{
                '\0', 'a', 'b', 'c', 'd', 'e', 'f', 'g',
                'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q',
                'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '_', '0',
                '0', '0','0',
                };

        public static void codegen()
        {
            var @base = 'a' - 1;
            var top = text.emitter();
            top.Append("new byte[32]");
            top.Append(C.LBrace);
            top.Append($"{0}");
            top.Append(C.Comma);

            top.Append(C.Space);
            top.Append($"{1}");
            top.Append(C.Comma);

            top.Append(C.Space);
            top.Append($"{2}");
            top.Append(C.Comma);

            for(char i='a'; i<= 'z'; i++)
            {
                var c = i - @base;
                top.Append(C.Space);
                top.Append($"{(byte)c}");
                top.Append(C.Comma);
                //Write($"{(byte)c} = '{i}' = {(byte)i}");
            }
            top.Append(C.Space);
            top.Append("29");
            top.Append(C.Comma);

            top.Append(C.Space);
            top.Append("30");
            top.Append(C.Comma);

            top.Append(C.Space);
            top.Append("31");
            top.Append(C.Comma);

            top.Append(C.RBrace);


            var left = text.emitter();
            left.Append("new byte[32]");
            left.Append(C.LBrace);

            left.Append((byte)'0');
            left.Append(C.Comma);

            left.Append(C.Space);
            left.Append((byte)C.Underscore);
            left.Append(C.Comma);

            left.Append(C.Space);
            left.Append((byte)'0');
            left.Append(C.Comma);

            for(char i='a'; i<= 'z'; i++)
            {
                left.Append(C.Space);
                left.Append((byte)i);
                left.Append(C.Comma);
            }
            left.Append(C.Space);
            left.Append("0");
            left.Append(C.Comma);

            left.Append(C.Space);
            left.Append("0");
            left.Append(C.Comma);

            left.Append(C.Space);
            left.Append("0");
            left.Append(C.Comma);

            left.Append(C.RBrace);


            var right = text.emitter();
            right.Append("new char[32]");
            right.Append(C.LBrace);

            right.Append("'0'");
            right.Append(C.Comma);

            right.Append(C.Space);
            right.Append("'_'");
            right.Append(C.Comma);

            right.Append(C.Space);
            right.Append("'0'");
            right.Append(C.Comma);

            for(char i='a'; i<= 'z'; i++)
            {
                right.Append(C.Space);
                right.Append($"'{i}'");
                right.Append(C.Comma);
            }

            right.Append(C.Space);
            right.Append("'0'");
            right.Append(C.Comma);

            right.Append(C.Space);
            right.Append("'0'");
            right.Append(C.Comma);

            right.Append(C.Space);
            right.Append("'0'");
            right.Append(C.Comma);

            right.Append(C.RBrace);
        }
    }
}