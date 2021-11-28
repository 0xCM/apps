//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;

    using static Root;

    /// <summary>
    /// Pairs an api member with the executable code derived from that member
    /// </summary>
    public class ApiMemberCode
    {
        /// <summary>
        /// The extraction index
        /// </summary>
        public uint Sequence {get;}

        /// <summary>
        /// The member to which executable code is attached
        /// </summary>
        public ApiMember Member {get;}

        /// <summary>
        /// The extraction termination code
        /// </summary>
        public ExtractTermCode TermCode {get;}

        /// <summary>
        /// The encoded data
        /// </summary>
        public ApiCodeBlock Encoded {get;}

        [MethodImpl(Inline)]
        public ApiMemberCode(ApiMember member, ApiCodeBlock code, uint seq = 0, ExtractTermCode term = 0)
        {
            Sequence = seq;
            Member = member;
            Encoded = code;
            TermCode = term;
        }

        [MethodImpl(Inline)]
        ApiMemberCode(ApiMember member, BinaryCode code)
        {
            Sequence = 0;
            Member = member;
            Encoded = ApiCodeBlock.Empty;
            TermCode = 0;
        }

        public CliToken MemberToken
        {
            [MethodImpl(Inline)]
            get => Member.Token;
        }

        public CliSig CliSig
        {
            [MethodImpl(Inline)]
            get => Member.CliSig;
        }

        public OpUri OpUri
        {
            [MethodImpl(Inline)]
            get => Encoded.OpUri;
        }

        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => Encoded.Length;
        }

        public byte[] Storage
        {
            [MethodImpl(Inline)]
            get => Encoded.Storage;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Encoded.Length;
        }

        public ref readonly byte this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Encoded[index];
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Encoded.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Encoded.IsNonEmpty;
        }

        public MemoryAddress Address
        {
            [MethodImpl(Inline)]
            get => Encoded.BaseAddress;
        }

        public ApiClassKind KindId
             => Member.ApiClass;

        public OpIdentity Id
            => Member.Id;

        public OpUri Uri
            => Member.OpUri;

        public ApiHostUri Host
             => Uri.Host;

        public MethodInfo Method
             => Member.Method;


        public bool Equals(ApiMemberCode src)
            => Encoded.Equals(src.Encoded);

        public override int GetHashCode()
            => Uri.GetHashCode();

        public override bool Equals(object src)
            => src is ApiMemberCode m && Equals(m);

        public string Format(int uripad)
            => string.Concat(Member.OpUri.Format().PadRight(uripad), Encoded.Format());

        public string Format()
            => Format(80);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator BinaryCode(ApiMemberCode src)
            => src.Encoded.Encoded;

        public static ApiMemberCode Empty
            => new ApiMemberCode(ApiMember.Empty, BinaryCode.Empty);
    }
}