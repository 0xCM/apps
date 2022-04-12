//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static core;

    partial class XedRules
    {
        public static OpVector vector(InstPattern src)
        {
            var dst = OpVector.Empty;
            ref readonly var ops = ref src.OpDetails;
            var count = (byte)ops.Count;
            if(count <= OpVector.MaxLength)
            {
                dst.N = count;
                for(var i=z8; i<count; i++)
                {
                    ref readonly var op = ref ops[i];
                    dst[i] = OpVector.cell(op.Index, op.Name, op.Kind);
                }
            }
            return dst;
        }

        public struct OpVector
        {
            [MethodImpl(Inline)]
            public static Component cell(uint3 pos, OpName name, OpKind kind)
                => new(pos,name,kind);

            public const byte MaxLength = uint3.MaxLiteral;

            ByteBlock64 Data;

            public ref Component this[byte i]
            {
                [MethodImpl(Inline)]
                get => ref @as<Component>(Data[i]);
            }

            public ref byte N
            {
                [MethodImpl(Inline)]
                get => ref Data[63];
            }

            public static OpVector Empty => default;

            public readonly struct Component
            {
                const byte PosIndex = 0;

                const byte NameIndex = 1;

                const byte KindIndex = 2;

                const byte TypeIndex = 3;

                readonly ByteBlock8 Data;

                [MethodImpl(Inline)]
                public Component(uint3 pos, OpName name, OpKind @class)
                {
                    var data = ByteBlock8.Empty;
                    data[NameIndex] = (byte)name;
                    data[PosIndex] = pos;
                    data[KindIndex] = (byte)@class;
                    Data = data;
                }

                public ref readonly uint3 Pos
                {
                    [MethodImpl(Inline)]
                    get => ref @as<uint3>(Data[PosIndex]);
                }

                public ref readonly OpName Name
                {
                    [MethodImpl(Inline)]
                    get => ref @as<OpName>(Data[NameIndex]);
                }

                public ref readonly OpKind Kind
                {
                    [MethodImpl(Inline)]
                    get => ref @as<OpKind>(Data[KindIndex]);
                }

                public OpIndicator Indicator
                {
                    [MethodImpl(Inline)]
                    get => Name.Indicator;
                }
            }
        }
    }
}