//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ApiCodeBlockHeader
    {
        public static ApiCodeBlockHeader define(OpUri uri, MethodDisplaySig method, ApiCodeBlock code, ExtractTermCode term)
            => new ApiCodeBlockHeader(uri, method, code, term);

        public OpUri Uri {get;}

        public MethodDisplaySig DisplaySig {get;}

        public CodeBlock CodeBlock {get;}

        public ExtractTermCode TermCode {get;}

        [MethodImpl(Inline)]
        public ApiCodeBlockHeader(OpUri uri, MethodDisplaySig sig, CodeBlock code, ExtractTermCode term)
        {
            Uri = uri;
            DisplaySig = sig;
            CodeBlock = code;
            TermCode = term;
        }
    }
}