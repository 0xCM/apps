//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct AsmSymbol
    {
        internal uint Seq {get;}

        public @string Name {get;}

        public MemoryAddress Location {get;}

        [MethodImpl(Inline)]
        internal AsmSymbol(uint seq, @string name, MemoryAddress location)
        {
            Seq = seq;
            Name = name;
            Location = location;
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

        public static AsmSymbol Empty
            => new AsmSymbol(0u, EmptyString,0);
    }
}