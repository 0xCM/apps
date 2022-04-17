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
            public static ReflectedFields init()
                => new ReflectedFields(sys.alloc<ReflectedField>(128));

            readonly Index<FieldKind,ReflectedField> Data;

            [MethodImpl(Inline)]
            ReflectedFields(Index<FieldKind,ReflectedField> src)
            {
                Data = src;
            }

            public byte Count
            {
                [MethodImpl(Inline)]
                get => (byte)Data.Count;
            }

            public ref ReflectedField this[FieldKind kind]
            {
                [MethodImpl(Inline)]
                get => ref Data[kind];
            }

            public ref ReflectedField this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Data[(FieldKind)i];
            }

            public ref ReflectedField this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Data[(FieldKind)i];
            }

            public ReadOnlySpan<ReflectedField> Valid
            {
                [MethodImpl(Inline)]
                get => core.slice(Data.View,1);
            }

            public ReadOnlySpan<ReflectedField> this[byte pos0, byte pos1]
            {
                [MethodImpl(Inline)]
                get => Segment(pos0,pos1);
            }

            public ReflectedFields IndexSort()
                => new ReflectedFields(Data.Storage.Sort());

            [MethodImpl(Inline)]
            public ReadOnlySpan<ReflectedField> Segment(byte pos0, byte pos1)
                => segment(@readonly(Data.Storage), pos0, pos1);

            [MethodImpl(Inline)]
            public static implicit operator Index<ReflectedField> (ReflectedFields src)
                => src.Data.Storage;
        }
    }
}