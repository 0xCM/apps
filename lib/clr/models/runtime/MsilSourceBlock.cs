//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct MsilSourceBlock
    {
        /// <summary>
        /// The source method token
        /// </summary>
        public readonly CliToken Token;

        /// <summary>
        /// The source method signature
        /// </summary>
        public readonly CliSig Sig;

        /// <summary>
        /// The encoded cil
        /// </summary>
        public readonly BinaryCode Encoded;

        /// <summary>
        /// Applied attributes
        /// </summary>
        public readonly MethodImplAttributes Attributes;

        [MethodImpl(Inline)]
        public MsilSourceBlock(CliToken id, CliSig sig, BinaryCode encoded, MethodImplAttributes attributes = default)
        {
            Token = id;
            Sig = sig;
            Encoded = encoded;
            Attributes = attributes;
        }

        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => Encoded.Size;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Token.IsEmpty && Sig.IsEmpty && Encoded.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Token.IsNonEmpty || Sig.IsNonEmpty || Encoded.IsNonEmpty;
        }

        public bool Complete
        {
            [MethodImpl(Inline)]
            get => Token.IsNonEmpty && Sig.IsNonEmpty && Encoded.IsNonEmpty;
        }

        public static MsilSourceBlock Empty
        {
            [MethodImpl(Inline)]
            get => new MsilSourceBlock(CliToken.Empty, CliSig.Empty, BinaryCode.Empty);
        }

        public ReadOnlySpan<byte> View
        {
            [MethodImpl(Inline)]
            get => Encoded.View;
        }
    }
}