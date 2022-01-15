//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Represents a syntactically-valid label
    /// </summary>
    public readonly struct AsmBlockLabel : IAsmSourcePart
    {
        public Identifier Name {get;}

        [MethodImpl(Inline)]
        public AsmBlockLabel(Identifier name)
            => Name = name;

        AsmPartKind IAsmSourcePart.PartKind
        {
            [MethodImpl(Inline)]
            get => AsmPartKind.BlockLabel;
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
            => Name.IsEmpty ? EmptyString : string.Format("{0}:", Name);

        public override string ToString()
            => Format();

        public static AsmBlockLabel Empty
        {
            [MethodImpl(Inline)]
            get => new AsmBlockLabel(Identifier.Empty);
        }

        [MethodImpl(Inline)]
        public static implicit operator AsmBlockLabel(string src)
            => new AsmBlockLabel(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmLabel(AsmBlockLabel src)
            => new AsmLabel(src.Name);

        [MethodImpl(Inline)]
        public static implicit operator AsmCell(AsmBlockLabel src)
            => asm.cell(src.Format(), AsmPartKind.BlockLabel);
    }
}