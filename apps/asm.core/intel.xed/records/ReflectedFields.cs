//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedRules
    {
        public struct ReflectedFields
        {
            public const byte FieldCount = 128;

            public static ReflectedFields init()
                => new ReflectedFields(sys.alloc<FieldDef>(FieldCount));

            readonly Index<FieldKind,FieldDef> Data;

            [MethodImpl(Inline)]
            ReflectedFields(Index<FieldKind,FieldDef> src)
            {
                Data = src;
            }

            public byte Count
            {
                [MethodImpl(Inline)]
                get => (byte)Data.Count;
            }

            public ref FieldDef this[FieldKind kind]
            {
                [MethodImpl(Inline)]
                get => ref Data[kind];
            }

            public ref FieldDef this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Data[(FieldKind)i];
            }

            public ref FieldDef this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Data[(FieldKind)i];
            }

            public ReadOnlySpan<FieldDef> Valid
            {
                [MethodImpl(Inline)]
                get => core.slice(Data.View,1);
            }

            public ReadOnlySpan<FieldDef> this[byte pos0, byte pos1]
            {
                [MethodImpl(Inline)]
                get => Segment(pos0,pos1);
            }

            public ReflectedFields IndexSort()
                => new ReflectedFields(Data.Storage.Sort());

            [MethodImpl(Inline)]
            public ReadOnlySpan<FieldDef> Segment(byte pos0, byte pos1)
                => segment(@readonly(Data.Storage), pos0, pos1);

            [MethodImpl(Inline)]
            public static implicit operator Index<FieldDef> (ReflectedFields src)
                => src.Data.Storage;
        }
    }
}