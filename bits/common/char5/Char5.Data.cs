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

        const byte Capacity = 32;

        static ReadOnlySpan<byte> AsciCodes
            => new byte[Capacity]{
                (byte)'\0', (byte)'a', (byte)'b', (byte)'c', (byte)'d', (byte)'e', (byte)'f', (byte)'g',
                (byte)'h', (byte)'i', (byte)'j', (byte)'k', (byte)'l', (byte)'m', (byte)'n', (byte)'o',
                (byte)'p', (byte)'q', (byte)'r', (byte)'s', (byte)'t',
                (byte)'u', (byte)'v', (byte)'w', (byte)'x', (byte)'y', (byte)'z', (byte)'_', (byte)'/', (byte)'0', (byte)'1', 0,
                };

        static Index<char> AsciChars()
            => core.map(AsciCodes, c => (char)c);

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