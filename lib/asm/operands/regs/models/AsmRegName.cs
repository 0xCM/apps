//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct AsmRegName
    {
        readonly text7 Data;

        [MethodImpl(Inline)]
        public AsmRegName(text7 name)
        {
            Data = name;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsNonEmpty;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }

        public bool Equals(AsmRegName src)
            => Data.Equals(src.Data);

        public string Format()
            => Data.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator AsmRegName(text7 src)
            => new AsmRegName(src);

        public static AsmRegName Empty => new AsmRegName(text7.Empty);
    }
}