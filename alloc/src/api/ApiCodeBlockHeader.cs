//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ApiCodeBlockHeader
    {
        public readonly OpUri Uri;

        public readonly @string DisplaySig;

        public readonly CodeBlock CodeBlock;

        public readonly ExtractTermCode TermCode;

        [MethodImpl(Inline)]
        public ApiCodeBlockHeader(OpUri uri, string sig, CodeBlock code, ExtractTermCode term)
        {
            Uri = uri;
            DisplaySig = sig;
            CodeBlock = code;
            TermCode = term;
        }
    }
}