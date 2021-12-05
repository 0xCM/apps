//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Specifies a <see cref='ApiMember'/> along with its binary represetnation
    /// </summary>
    public readonly struct ApiMemberCapture : IComparable<ApiMemberCapture>
    {
        public ApiMember Member {get;}

        public ApiCaptureBlock Code {get;}

        [MethodImpl(Inline)]
        public ApiMemberCapture(ApiMember member, ApiCaptureBlock code)
        {
            Member = member;
            Code = code;
        }

        public OpUri Uri
        {
            [MethodImpl(Inline)]
            get => Member.OpUri;
        }

        public CodeBlock Parsed
        {
            [MethodImpl(Inline)]
            get => Code.Parsed;
        }

        public MemoryAddress BaseAddress
        {
            [MethodImpl(Inline)]
            get => Code.BaseAddress;
        }

        public ExtractTermCode TermCode
        {
            [MethodImpl(Inline)]
            get => Code.TermCode;
        }

        [MethodImpl(Inline)]
        public int CompareTo(ApiMemberCapture src)
            => Code.Compare(src.Code);
    }
}