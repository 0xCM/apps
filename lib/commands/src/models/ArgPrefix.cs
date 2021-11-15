//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    [DataType]
    public readonly struct ArgPrefix : IDataTypeEquatable<ArgPrefix>
    {
        internal readonly AsciCode C0;

        internal readonly AsciCode C1;

        [MethodImpl(Inline)]
        internal ArgPrefix(AsciCode c0)
        {
            C0 = c0;
            C1 = AsciCode.Null;
        }

        [MethodImpl(Inline)]
        internal ArgPrefix(AsciCode c0, AsciCode c1)
        {
            C0 = c0;
            C1 = c1;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => C0 == AsciCode.Null;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => C0 != AsciCode.Null;
        }

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => (uint)C0 | (uint)((uint)C1 << 16);
        }

        public byte Length
        {
            [MethodImpl(Inline)]
            get => IsEmpty ? z8 : (C1 == AsciCode.Null ? (byte)1 : (byte)2);
        }

        public bool Equals(ArgPrefix src)
            => C0 == src.C0 && C1 == src.C1;

        public override bool Equals(object src)
            => src is ArgPrefix x && Equals(x);

        public override int GetHashCode()
            => (int)Hash;

        [MethodImpl(Inline)]
        public string Format()
            => Cmd.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator string(ArgPrefix src)
            => src.Format();

        [MethodImpl(Inline)]
        public static implicit operator ArgPrefix(string src)
            => Cmd.prefix(src);

        [MethodImpl(Inline)]
        public static bool operator ==(ArgPrefix a, ArgPrefix b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(ArgPrefix a, ArgPrefix b)
            => !a.Equals(b);

        public static ArgPrefix Empty
            => default;

        public static ArgPrefix DoubleDash
            => new ArgPrefix(AsciCode.Dash, AsciCode.Dash);

        public static ArgPrefix Dash
            => new ArgPrefix(AsciCode.Dash);

        public static ArgPrefix FSlash
            => new ArgPrefix(AsciCode.FS);

        public static ArgPrefix Space
            => new ArgPrefix(AsciCode.Space);

        public static ArgPrefix Default
            => DoubleDash;
    }
}