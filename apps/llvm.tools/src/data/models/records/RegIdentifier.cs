//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct RegIdentifier : IComparable<RegIdentifier>, IEquatable<RegIdentifier>
    {
        /// <summary>
        /// The instruction id, in-synch with tablegen output
        /// </summary>
        public readonly ushort Id;

        /// <summary>
        /// The identified instruction name
        /// </summary>
        public readonly text15 Name;

        [MethodImpl(Inline)]
        public RegIdentifier(ushort id, text15 instname)
        {
            Id = id;
            Name = instname;
        }

        public string Format()
            => string.Format("{0:D5} {1}", Id, Name);


        public override string ToString()
            => Format();

        public bool Equals(RegIdentifier src)
            => Id == src.Id && Name == src.Name;

        [MethodImpl(Inline)]
        public int CompareTo(RegIdentifier src)
            => Id.CompareTo(src.Id);

        public override int GetHashCode()
            => Id;

        public override bool Equals(object src)
            => src is RegIdentifier x && Equals(x);
    }
}