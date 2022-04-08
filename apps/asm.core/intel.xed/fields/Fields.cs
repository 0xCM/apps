//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using static XedModels;

    partial class XedRules
    {
        public ref struct Fields
        {
            Span<Field> Data;

            const uint MaxCount = 128;

            [MethodImpl(Inline)]
            public Fields(PageBlock2 src)
            {
                Data = recover<Field>(src.Bytes);
            }

            public uint Count
            {
                [MethodImpl(Inline)]
                get => (uint)min(Data.Length, MaxCount);
            }

            [MethodImpl(Inline)]
            public FieldSet Members()
            {
                var members = FieldSet.create();
                for(var i=0; i<Count; i++)
                {
                    ref readonly var field = ref this[i];
                    if(field.IsNonEmpty)
                        members.Include(field.Kind);
                }
                return members;
            }

            public ref Field this[uint index]
            {
                [MethodImpl(Inline)]
                get => ref seek(Data,index);
            }

            public ref Field this[int index]
            {
                [MethodImpl(Inline)]
                get => ref seek(Data,index);
            }

            [MethodImpl(Inline)]
            public ref Field Update(in FieldPack src)
            {
                ref var dst = ref this[(uint)src.Field];
                dst = field(src.Field, src.Value());
                return ref this[src.Field];
            }

            public ref Field this[FieldKind kind]
            {
                [MethodImpl(Inline)]
                get => ref seek(Data,(byte)kind);
            }

            [MethodImpl(Inline)]
            public ref Field Update(FieldKind kind, Register src)
            {
                ref var dst = ref this[(uint)kind];
                dst = field(kind, src);
                return ref dst;
            }
        }
    }
}