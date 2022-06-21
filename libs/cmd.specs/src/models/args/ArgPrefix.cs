//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using C = AsciCode;

    public readonly struct ArgPrefix : IEquatable<ArgPrefix>
    {
        /// <summary>
        /// Creates a <see cref='ArgPrefix'/> from the leading source element(s)
        /// </summary>
        /// <param name="src"></param>
        [MethodImpl(Inline), Op]
        public static ArgPrefix prefix(string src)
            => prefix(chars(src));

        /// <summary>
        /// Creates a <see cref='ArgPrefix'/> from the leading source element(s)
        /// </summary>
        /// <param name="src"></param>
        [MethodImpl(Inline), Op]
        public static ArgPrefix prefix(ReadOnlySpan<char> src)
        {
            var count = src.Length;
            if(count == 0)
                return ArgPrefix.Empty;
            else if(count == 1)
                return new ArgPrefix((C)skip(src, 0));
            else
                return new ArgPrefix((C)skip(src, 0), (C)skip(src, 1));
        }

        /// <summary>
        /// Defines an <see cref='ArgPrefix'/> from a specified asci character
        /// </summary>
        /// <param name="c0">The delimiter</param>
        [MethodImpl(Inline), Op]
        public static ArgPrefix prefix(char c0)
            => new ArgPrefix((C)c0);

        /// <summary>
        /// Defines an <see cref='ArgPrefix'/> from a specified asci code
        /// </summary>
        /// <param name="c0">The delimiter</param>
        [MethodImpl(Inline), Op]
        public static ArgPrefix prefix(C c0)
            => new ArgPrefix(c0);

        /// <summary>
        /// Defines an <see cref='ArgPrefix'/> from two specified characters
        /// </summary>
        /// <param name="c0">The first part of the delimiter</param>
        /// <param name="c1">The second part of the delimiter</param>
        [MethodImpl(Inline), Op]
        public static ArgPrefix prefix(char c0, char c1)
            => new ArgPrefix((C)c0, (C)c1);

        /// <summary>
        /// Defines an <see cref='ArgPrefix'/> from two specified asci codes
        /// </summary>
        /// <param name="c0">The first part of the prefix</param>
        /// <param name="c1">The second part of the prefix</param>
        [MethodImpl(Inline), Op]
        public static ArgPrefix prefix(C c0, C c1)
            => new ArgPrefix((C)c0, (C)c1);

        public static string format(ArgPrefix src)
        {
            var len = src.Length;
            if(len == 0)
                return EmptyString;
            else if(len == 1)
            {
                Span<char> content = stackalloc char[1]{(char)src.C0};
                return new string(content);
            }
            else
            {
                Span<char> content = stackalloc char[2]{(char)src.C0, (char)src.C1};
                return new string(content);
            }
        }

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
            => format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator string(ArgPrefix src)
            => src.Format();

        [MethodImpl(Inline)]
        public static implicit operator ArgPrefix(string src)
            => prefix(src);

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