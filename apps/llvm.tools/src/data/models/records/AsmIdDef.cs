//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public struct AsmIdDef : IComparable<AsmIdDef>, IEquatable<AsmIdDef>
    {
        /// <summary>
        /// The instruction id, in-synch with tablegen output
        /// </summary>
        public readonly ushort Id;

        /// <summary>
        /// The identified instruction name
        /// </summary>
        public readonly Identifier InstName;

        [MethodImpl(Inline)]
        public AsmIdDef(ushort id, Identifier instname)
        {
            Id = id;
            InstName = instname;
        }

        public string Format()
            => string.Format("{0:D5} {1}", Id, InstName);


        public override string ToString()
            => Format();

        public bool Equals(AsmIdDef src)
            => Id == src.Id && InstName == src.InstName;

        [MethodImpl(Inline)]
        public int CompareTo(AsmIdDef src)
            => Id.CompareTo(src.Id);

        public override int GetHashCode()
            => Id;

        public override bool Equals(object src)
            => src is AsmIdDef x && Equals(x);
    }
}