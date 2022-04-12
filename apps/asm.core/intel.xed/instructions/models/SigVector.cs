//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedModels;
    using static core;

    partial class XedRules
    {
        public struct SigVector
        {
            public readonly struct Component
            {
                const byte PosIndex = 0;

                const byte NameIndex = 1;

                const byte KindIndex = 2;

                const byte TypeIndex = 3;

                readonly ByteBlock8 Data;

                [MethodImpl(Inline)]
                public Component(uint4 pos, OpName name,  OpKind @class, BitSegType type)
                {
                    var data = ByteBlock8.Empty;
                    data[NameIndex] = (byte)name;
                    data[PosIndex] = pos;
                    data[KindIndex] = (byte)@class;
                    core.@as<BitSegType>(data[TypeIndex]) = type;
                    Data = data;
                }

                public ref readonly uint4 Pos
                {
                    [MethodImpl(Inline)]
                    get => ref @as<uint4>(Data[PosIndex]);
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

                public ref readonly BitSegType Type
                {
                    [MethodImpl(Inline)]
                    get => ref @as<BitSegType>(Data[TypeIndex]);
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