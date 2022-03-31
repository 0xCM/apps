//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    using R = XedRules;

    using static core;

    using static XedModels;

    partial class XedFields
    {
        public abstract class FieldView<T>
            where T : FieldView<T>, new()
        {


        }

        public abstract class ScalarFieldView<F,T> : FieldView<F>
            where F : ScalarFieldView<F,T>,new()
            where T : unmanaged
        {
            public abstract T ScalarValue(R.FieldValue src);
        }

        public class EnumFieldView<E,T> : FieldView<EnumFieldView<E,T>>
            where E : unmanaged, Enum
            where T : unmanaged
        {
            readonly Symbols<E> Sym = Symbols.index<E>();

            [MethodImpl(Inline)]
            public ref readonly E TypedValue(in R.FieldValue src)
                => ref @as<ulong,E>(src.Data);

            [MethodImpl(Inline)]
            public ref readonly T NumericValue(in R.FieldValue src)
                => ref @as<ulong,T>(src.Data);

            public string Name(in R.FieldValue src)
            {
                var dst = EmptyString;
                if(Sym.MapKind(TypedValue(src), out var sym))
                    dst = sym.Name;
                return dst;
            }

            public string Expr(in R.FieldValue src)
            {
                var dst = EmptyString;
                if(Sym.MapKind(TypedValue(src), out var sym))
                    dst = sym.Expr.Text;
                return dst;
            }
        }

        public readonly struct FieldViews
        {

            public sealed class XedRegView : EnumFieldView<XedRegId,ushort>
            {


            }

            public sealed class InstClassView : EnumFieldView<IClass,ushort>
            {


            }

            public sealed class VexClassView : EnumFieldView<VexClass,byte>
            {


            }

            public sealed class VexKindView : EnumFieldView<VexKind,byte>
            {


            }

            public sealed class BCastView : EnumFieldView<BCastKind,byte>
            {


            }

            public sealed class ChipView : EnumFieldView<ChipCode,byte>
            {


            }

            public sealed class ModeView : EnumFieldView<ModeKind,byte>
            {


            }

            public sealed class BrDispWidthView : EnumFieldView<BrDispWidth,byte>
            {


            }

            public sealed class BitView : ScalarFieldView<BitView,bit>
            {
                public override bit ScalarValue(R.FieldValue src)
                    => (bit)src;
            }

            public sealed class U2View : ScalarFieldView<U2View,uint2>
            {
                public override uint2 ScalarValue(R.FieldValue src)
                    => (uint2)src;
            }

            public sealed class U3View : ScalarFieldView<U3View,uint3>
            {
                public override uint3 ScalarValue(R.FieldValue src)
                    => (uint3)src;
            }

            public sealed class U4View : ScalarFieldView<U4View,uint4>
            {
                public override uint4 ScalarValue(R.FieldValue src)
                    => (uint4)src;
            }

            public sealed class U8View : ScalarFieldView<U8View,byte>
            {
                public override byte ScalarValue(R.FieldValue src)
                    => (byte)src;
            }

            public sealed class U16View : ScalarFieldView<U16View,ushort>
            {
                public override ushort ScalarValue(R.FieldValue src)
                    => (ushort)src;
            }

            public sealed class U64View : ScalarFieldView<U64View,ulong>
            {
                public override ulong ScalarValue(R.FieldValue src)
                    => (ulong)src;
            }

            public sealed class Hex4View : ScalarFieldView<Hex4View,Hex4>
            {
                public override Hex4 ScalarValue(R.FieldValue src)
                    => (Hex4)src;
            }

            public sealed class Hex8View : ScalarFieldView<Hex8View,Hex8>
            {
                public override Hex8 ScalarValue(R.FieldValue src)
                    => (Hex8)src;
            }
        }
    }
}