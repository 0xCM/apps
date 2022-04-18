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
        public readonly record struct RepIndicator : IComparable<RepIndicator>
        {
            readonly byte Data;

            [MethodImpl(Inline)]
            public RepIndicator(RepPrefix src)
            {
                Data = bit.enable((byte)src, 7);
            }

            public RepPrefix Kind
            {
                [MethodImpl(Inline)]
                get =>  (RepPrefix)bit.set(Data, 7, 0);
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Data == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Data != 0;
            }

            public bool IsNonZero
            {
                [MethodImpl(Inline)]
                get => Data != 0;
            }

            [MethodImpl(Inline)]
            public int CompareTo(RepIndicator src)
                => XedRules.cmp(Kind, src.Kind);

            public string Format()
                => IsEmpty ? EmptyString : XedRender.format(Kind);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator RepIndicator(RepPrefix src)
                => new RepIndicator(src);

            public static RepIndicator Empty => default;
        }
    }
}