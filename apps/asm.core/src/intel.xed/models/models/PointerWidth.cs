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

            public char Spec {get;}

            public text15 Name {get;}

            public PointerWidth(Sym<PointerWidthKind> src)
            {
                Kind = src.Kind;
                Spec = src.Expr.Format()[0];
                Name = src.Kind.ToString().ToLower();
            }

            public NativeSize Size
            {
                [MethodImpl(Inline)]
                get => Sizes.native(((uint)Kind)*8);
            }

            public string Format()
                => Name.Format();

            public override string ToString()
                => Format();

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
            public static implicit operator PointerWidth(Sym<PointerWidthKind> src)
                => new PointerWidth(src);

            public static PointerWidth Empty => default;
        }
    }
}