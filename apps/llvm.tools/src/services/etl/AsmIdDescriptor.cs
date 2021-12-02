//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public struct AsmIdDescriptor : IComparable<AsmIdDescriptor>, IEquatable<AsmIdDescriptor>
    {
        public readonly ushort Id;

        public readonly Identifier InstName;

        [MethodImpl(Inline)]
        public AsmIdDescriptor(ushort id, Identifier instname)
        {
            Id = id;
            InstName = instname;
        }

        public string Format()
            => string.Format("{0:D5} {1}", Id, InstName);


        public override string ToString()
            => Format();

        public bool Equals(AsmIdDescriptor src)
            => Id == src.Id && InstName == src.InstName;

        [MethodImpl(Inline)]
        public int CompareTo(AsmIdDescriptor src)
            => Id.CompareTo(src.Id);

        public override int GetHashCode()
            => Id;

        public override bool Equals(object src)
            => src is AsmIdDescriptor x && Equals(x);
    }
}