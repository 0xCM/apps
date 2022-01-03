//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;

    using static Root;

    [DataType("asm.varcode",15*8, 16*8)]
    public readonly struct AsmVariationCode : IEquatable<AsmVariationCode>, IComparable<AsmVariationCode>
    {
        public readonly text15 Name;

        [MethodImpl(Inline)]
        public AsmVariationCode(text15 name)
        {
            Name = name;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsNonEmpty;
        }

        public string Format()
            => Name.Format();

        public override string ToString()
            => Format();


        [MethodImpl(Inline)]
        public bool Equals(AsmVariationCode src)
            => Name.Equals(src.Name);

        public override int GetHashCode()
            => Name.GetHashCode();

        public override bool Equals(object src)
            => src is AsmVariationCode x && Equals(x);

        public int CompareTo(AsmVariationCode src)
            => Name.CompareTo(src.Name);

        public static AsmVariationCode Empty
        {
            [MethodImpl(Inline)]
            get => new AsmVariationCode(text15.Empty);
        }
    }
}