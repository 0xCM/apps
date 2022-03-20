//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly struct OpAspect
        {
            readonly byte IndexData;

            readonly ushort ValueData;

            [MethodImpl(Inline)]
            internal OpAspect(OpAspectIndex index, ushort value)
            {
                IndexData = (byte)index;
                ValueData = value;
            }

            public OpAspectIndex AspectIndex
            {
                [MethodImpl(Inline)]
                get => (OpAspectIndex)IndexData;
            }

            public OpAspectKind AspectKind
            {
                [MethodImpl(Inline)]
                get => IndexData == 0 ? 0 : (OpAspectKind)Pow2.pow(IndexData - 1);
            }

            [MethodImpl(Inline)]
            public static implicit operator OpAspect(XedRegId src)
                => new OpAspect(OpAspectIndex.Reg, (ushort)src);

            [MethodImpl(Inline)]
            public static implicit operator OpAspect(NontermKind src)
                => new OpAspect(OpAspectIndex.NT, (ushort)src);

            [MethodImpl(Inline)]
            public static implicit operator OpAspect(OpWidthCode src)
                => new OpAspect(OpAspectIndex.Width, (ushort)src);

            [MethodImpl(Inline)]
            public static implicit operator OpAspect(ElementKind src)
                => new OpAspect(OpAspectIndex.EType, (ushort)src);

            [MethodImpl(Inline)]
            public static implicit operator OpAspect(ElementType src)
                => new OpAspect(OpAspectIndex.EType, (ushort)src.Kind);

            [MethodImpl(Inline)]
            public static implicit operator OpAspect(OpVisibility src)
                => new OpAspect(OpAspectIndex.Visibilty, (ushort)src);

            [MethodImpl(Inline)]
            public static implicit operator OpAspect(VisibilityKind src)
                => new OpAspect(OpAspectIndex.Visibilty, (ushort)src);

            [MethodImpl(Inline)]
            public static implicit operator OpAspect(Visibility src)
                => new OpAspect(OpAspectIndex.Visibilty, (ushort)src);

            [MethodImpl(Inline)]
            public static implicit operator OpAspect(OpType src)
                => new OpAspect(OpAspectIndex.Type, (ushort)src);

            [MethodImpl(Inline)]
            public static implicit operator OpAspect(OpAction src)
                => new OpAspect(OpAspectIndex.Action, (ushort)src);

            [MethodImpl(Inline)]
            public static implicit operator OpAspect(byte src)
                => new OpAspect(OpAspectIndex.Index, (ushort)src);
        }
    }
}