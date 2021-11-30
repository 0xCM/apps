//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct AsmVariationCode
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

        public static AsmVariationCode Empty
        {
            [MethodImpl(Inline)]
            get => new AsmVariationCode(text15.Empty);
        }
    }
}