//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct MethodSig : ITextual, IComparable<MethodSig>, IEquatable<MethodSig>
    {
        public ClrMethodArtifact Source {get;}

        public TextBlock Formatted {get;}

        [MethodImpl(Inline)]
        public MethodSig(ClrMethodArtifact src, string formatted)
        {
            Source = src;
            Formatted = formatted;
        }

        public string Format()
            => Formatted;

        public override string ToString()
            => Format();

        public int CompareTo(MethodSig src)
            => Formatted.CompareTo(src.Formatted);

        public bool Equals(MethodSig src)
            => Formatted.Equals(src.Formatted);

        public override int GetHashCode()
            => Formatted.GetHashCode();

        public override bool Equals(object src)
            => src is MethodSig x && Equals(x);

        public static MethodSig Empty
        {
            get => new MethodSig(ClrMethodArtifact.Empty, EmptyString);
        }
    }
}