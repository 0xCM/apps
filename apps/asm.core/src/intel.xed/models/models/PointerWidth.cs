//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-reg-class.h
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct XedModels
    {
        public readonly struct PointerWidth
        {
            public PointerWidthKind Kind {get;}

            [MethodImpl(Inline)]
            public PointerWidth(PointerWidthKind kind)
            {
                Kind = kind;
            }

            public NativeSize Size
            {
                [MethodImpl(Inline)]
                get => NativeSize.code(((uint)Kind)*8);
            }

            public char Spec
                => Symbols.expr(Kind).Format()[0];

            public text15 Name
                => Kind.ToString().ToLower();

            public string Format()
                => Name.Format();

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public PointerWidthRecord ToRecord(byte seq)
            {
                var dst = new PointerWidthRecord();
                dst.Seq = seq;
                dst.Name = Name;
                dst.Spec = Spec;
                dst.Size = Size;
                return dst;
            }

            [MethodImpl(Inline)]
            public static implicit operator PointerWidth(PointerWidthKind kind)
                => new PointerWidth(kind);

            public static PointerWidth Empty => default;
        }
    }
}