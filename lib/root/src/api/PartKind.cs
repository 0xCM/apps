//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct PartKind : ITextual, IEquatable<PartKind>
    {
        readonly byte Class;

        [MethodImpl(Inline)]
        public PartKind(PartId id)
        {
            Class = (byte)id;
        }

        public PartId ClassId
        {
            [MethodImpl(Inline)]
            get => (PartId)Class;
        }

        public string Format()
            => ClassId.Format();

        public bool Equals(PartKind src)
            => Class == src.Class;

        public override bool Equals(object src)
            => src is PartKind k && Equals(k);

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => Class;

        [MethodImpl(Inline)]
        public static implicit operator PartKind(PartId src)
            => new PartKind(src);

        [MethodImpl(Inline)]
        public static implicit operator PartId(PartKind src)
            => src.ClassId;
    }
}