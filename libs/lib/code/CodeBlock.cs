//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Encoded x86 bytes extracted from a memory source with a known (nonzero) location
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct CodeBlock : IHashed
    {
        /// <summary>
        /// The head of the memory location from which the data originated
        /// </summary>
        public readonly MemoryAddress BaseAddress;

        /// <summary>
        /// The encoded content
        /// </summary>
        public readonly BinaryCode Code;

        [MethodImpl(Inline)]
        public CodeBlock(MemoryAddress src, byte[] data)
        {
            BaseAddress = src;
            Code = new BinaryCode(data ?? core.array<byte>());
        }

        [MethodImpl(Inline)]
        public CodeBlock(MemoryAddress src, in BinaryCode code)
        {
            BaseAddress = src;
            Code = code;
        }

        [MethodImpl(Inline)]
        CodeBlock(ulong zero)
        {
            BaseAddress = zero;
            Code = Array.Empty<byte>();
        }

        public MemoryRange AddressRange
        {
            [MethodImpl(Inline)]
            get => (BaseAddress, BaseAddress + (MemoryAddress)Code.Length);
        }

        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => Code.Size;
        }

        public byte[] Storage
        {
            [MethodImpl(Inline)]
            get => Code.Storage;
        }

        public ReadOnlySpan<byte> View
        {
            [MethodImpl(Inline)]
            get => Code.View;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Code.Length;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Code.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Code.IsNonEmpty;
        }

        public ref readonly byte this[long index]
        {
            [MethodImpl(Inline)]
            get => ref Code[index];
        }

        public ref readonly byte this[ulong index]
        {
            [MethodImpl(Inline)]
            get => ref Code[index];
        }

        [MethodImpl(Inline)]
        public bool Equals(CodeBlock src)
            => Code.Equals(src.Code);

        public string Format()
            => Code.Format();


        public override string ToString()
            => Format();

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Code.Hash;
        }

        public override int GetHashCode()
            => Hash;

        public override bool Equals(object src)
            => src is CodeBlock x && Equals(x);


        [MethodImpl(Inline)]
        public static implicit operator byte[](CodeBlock src)
            => src.Storage;

        [MethodImpl(Inline)]
        public static implicit operator BinaryCode(CodeBlock src)
            => src.Code;

        [MethodImpl(Inline)]
        public static implicit operator ReadOnlySpan<byte>(CodeBlock src)
            => src.View;

        [MethodImpl(Inline)]
        public static bool operator==(CodeBlock a, CodeBlock b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator!=(CodeBlock a, CodeBlock b)
            => !a.Equals(b);

        public static CodeBlock Empty
            => new CodeBlock(0);
    }
}