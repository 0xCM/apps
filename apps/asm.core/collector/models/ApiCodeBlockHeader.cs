//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ApiCodeBlockHeader
    {
        public OpUri Uri {get;}

        public @string DisplaySig {get;}

        public CodeBlock CodeBlock {get;}

        public ExtractTermCode TermCode {get;}

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