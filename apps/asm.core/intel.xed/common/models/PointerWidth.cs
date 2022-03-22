//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        public readonly struct PointerWidth
        {
            public PointerWidthKind Kind {get;}

            public text7 Spec {get;}

            public text15 Name {get;}

            public PointerWidth(Sym<PointerWidthKind> src)
            {
                Kind = src.Kind;
                Spec =  XedRender.format(src.Kind);
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

            public PointerWidthInfo ToRecord(byte seq)
            {
                var dst = new PointerWidthInfo();
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