//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    [StructLayout(LayoutKind.Sequential)]
    public readonly struct CodeBlock<K> : IComparable<CodeBlock<K>>, IEquatable<CodeBlock<K>>
        where K : unmanaged
    {
        public K Kind {get;}

        public CodeBlock Code {get;}

        [MethodImpl(Inline)]
        public CodeBlock(K kind, CodeBlock code)
        {
            Kind = kind;
            Code = code;
        }

        public CodeKey Key
        {
            [MethodImpl(Inline)]
            get => Code.Key;
        }

        public ReadOnlySpan<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => Code.Storage;
        }

        /// <summary>
        /// The encoded operation data
        /// </summary>
        public readonly BinaryCode Encoded
        {
            [MethodImpl(Inline)]
            get => Code;
        }

        /// <summary>
        /// The code's base address
        /// </summary>
        public MemoryAddress BaseAddress
        {
             [MethodImpl(Inline)]
             get => Code.BaseAddress;
        }

        public MemoryRange AddressRange
        {
            [MethodImpl(Inline)]
            get => Code.AddressRange;
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

        [MethodImpl(Inline)]
        public bool Equals(CodeBlock<K> src)
            => Encoded.Equals(src.Encoded);

        public int CompareTo(CodeBlock<K> src)
            => BaseAddress.CompareTo(src.BaseAddress);

        public string Format()
            => string.Concat(BaseAddress.Format(), Chars.Colon, Encoded.Format());

        public override string ToString()
            => Format();

        public static CodeBlock<K> Empty
        {
            [MethodImpl(Inline)]
            get => new CodeBlock<K>(default, CodeBlock.Empty);
        }
    }
}