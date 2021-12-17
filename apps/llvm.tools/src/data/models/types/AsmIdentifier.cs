//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public struct AsmIdentifier : IComparable<AsmIdentifier>, IEquatable<AsmIdentifier>
    {
        /// <summary>
        /// The instruction id, in-synch with tablegen output
        /// </summary>
        public readonly ushort Id;

        /// <summary>
        /// The identified instruction name
        /// </summary>
        public readonly text31 InstName;

        [MethodImpl(Inline)]
        public AsmIdentifier(ushort id, text31 instname)
        {
            Id = id;
            InstName = instname;
        }

        public string Format()
            => string.Format("{0:D5} {1}", Id, InstName);


        public override string ToString()
            => Format();

        public bool Equals(AsmIdentifier src)
            => Id == src.Id && InstName.Equals(src.InstName);

        [MethodImpl(Inline)]
        public int CompareTo(AsmIdentifier src)
            => Id.CompareTo(src.Id);

        public override int GetHashCode()
            => Id;

        public override bool Equals(object src)
            => src is AsmIdentifier x && Equals(x);
    }
}