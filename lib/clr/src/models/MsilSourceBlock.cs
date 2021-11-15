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

    public readonly struct MsilSourceBlock
    {
        [MethodImpl(Inline), Op]
        public static MsilSourceBlock create(CliToken id, CliSig sig, BinaryCode encoded, MethodImplAttributes attributes = default)
            => new MsilSourceBlock(id, sig, encoded);

        /// <summary>
        /// The source method token
        /// </summary>
        public CliToken Token {get;}

        /// <summary>
        /// The source method signature
        /// </summary>
        public CliSig Sig {get;}

        /// <summary>
        /// The encoded cil
        /// </summary>
        public BinaryCode Encoded {get;}

        /// <summary>
        /// Applied attributes
        /// </summary>
        public MethodImplAttributes Attributes {get;}

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