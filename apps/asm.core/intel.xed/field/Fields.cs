//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using static XedModels;
    using static XedPatterns;

    partial class XedRules
    {
        public ref struct Fields
        {
            Span<Field> Data;

            FieldSet MemberData;

            const uint MaxCount = 128;

            [MethodImpl(Inline)]
            public Fields(Span<Field> src, FieldSet members = default)
            {
                Data = src;
                MemberData = members;
                if(MemberData.IsEmpty)
                    CalcMembers();
            }

            [MethodImpl(Inline)]
            public Fields(PageBlock2 src, FieldSet members = default)
            {
                Data = recover<Field>(src.Bytes);
                MemberData = members;

                if(MemberData.IsEmpty)
                    CalcMembers();
            }

            [MethodImpl(Inline)]
            void CalcMembers()
            {
                for(var i=0; i<Count; i++)
                {
                    ref readonly var field = ref this[i];
                    if(field.IsNonEmpty)
                        MemberData.Include(field.Kind);
                }
            }

            public uint Count
            {
                [MethodImpl(Inline)]
                get => (uint)min(Data.Length, MaxCount);
            }

            [MethodImpl(Inline)]
            public FieldSet Members(bool recalc = false)
            {
                if(recalc)
                    CalcMembers();
                return MemberData;
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

            public ref Field this[FieldKind kind]
            {
                [MethodImpl(Inline)]
                get => ref this[(uint)kind];
            }

            [MethodImpl(Inline)]
            public ref Field Field(FieldKind kind, bit src)
            {
                ref var dst = ref this[(uint)kind];
                dst = field(kind, src);
                return ref dst;
            }

            [MethodImpl(Inline)]
            public ref Field Field(FieldKind kind, byte src)
            {
                ref var dst = ref this[(uint)kind];
                dst = field(kind, src);
                return ref dst;
            }

            [MethodImpl(Inline)]
            public ref Field Field(FieldKind kind, ushort src)
            {
                ref var dst = ref this[(uint)kind];
                dst = field(kind, src);
                return ref dst;
            }

            [MethodImpl(Inline)]
            public ref Field Field(FieldKind kind, Register src)
            {
                ref var dst = ref this[(uint)kind];
                dst = field(kind, src);
                return ref dst;
            }

            [MethodImpl(Inline)]
            public ref Field Field(FieldKind kind, InstClass src)
            {
                ref var dst = ref this[(uint)kind];
                dst = field(kind, src);
                return ref dst;
            }

            [MethodImpl(Inline)]
            public ref Field Field(FieldKind kind, BCastKind src)
            {
                ref var dst = ref this[(uint)kind];
                dst = field(kind, src);
                return ref dst;
            }

            [MethodImpl(Inline)]
            public ref Field Field(FieldKind kind, ChipCode src)
            {
                ref var dst = ref this[(uint)kind];
                dst = field(kind, src);
                return ref dst;
            }

            [MethodImpl(Inline)]
            public ref Field Field(FieldKind kind, uint src)
            {
                ref var dst = ref this[(uint)kind];
                dst = field(src);
                return ref dst;
            }
        }
    }
}