//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static Chars;

    [ApiHost]
    public readonly partial struct AsmParser
    {
        static Fence<char> SigFence => (LParen, RParen);

        static Fence<char> OpCodeFence => (Lt, Gt);

        const string Implication = " => ";

        public static bool comment(ReadOnlySpan<char> src, out AsmInlineComment dst)
            => AsmInlineComment.parse(src, out dst);

    }
}