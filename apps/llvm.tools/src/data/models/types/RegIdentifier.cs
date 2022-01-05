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
        /// The name of the identified register
        /// </summary>
        public readonly text15 RegName;

        [MethodImpl(Inline)]
        public RegIdentifier(ushort id, text15 name)
        {
            Id = id;
            RegName = name;
        }

        public string Format()
            => string.Format("{0:D5} {1}", Id, RegName);


        public override string ToString()
            => Format();

        public bool Equals(RegIdentifier src)
            => Id == src.Id && RegName == src.RegName;

        [MethodImpl(Inline)]
        public int CompareTo(RegIdentifier src)
            => Id.CompareTo(src.Id);

        public override int GetHashCode()
            => Id;

        public override bool Equals(object src)
            => src is RegIdentifier x && Equals(x);
    }
}