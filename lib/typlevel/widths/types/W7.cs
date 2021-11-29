//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 7070
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using DW = DataWidth;
    using TS = TypeSignKind;

    using W = W7;

    /// <summary>
    /// Defines a type-level representation of <see cref='DW.W7'/>
    /// </summary>
    public readonly struct W7 : WData<W>
    {
        public const DW Width = DW.W7;

        public const TS Sign = TS.Unsigned;

        /// <summary>
        /// An instance-level representative
        /// </summary>
        public static W W => default;

        /// <summary>
        /// The width identity
        /// </summary>
        public const string Identifier = "w7";

        public string Id
            => Identifier;

        public DW DataWidth
            => Width;

        public TS TypeSign
            => Sign;

        [MethodImpl(Inline)]
        public static implicit operator int(W src)
            => (int)Width;

        [MethodImpl(Inline)]
        public static implicit operator DW(W src)
            => Width;

        [MethodImpl(Inline)]
        public static implicit operator DataWidth<W>(W src)
            => default;

        [MethodImpl(Inline)]
        public bool Equals(W w)
            => true;

        [MethodImpl(Inline)]
        public string Format()
            => Width.FormatValue();

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => (int)Width;

        public override bool Equals(object obj)
            => obj is W;
    }
}