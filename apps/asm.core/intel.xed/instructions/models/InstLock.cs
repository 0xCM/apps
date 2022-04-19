//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [DataWidth(Width, 8)]
        public readonly record struct LockIndicator : IComparable<LockIndicator>
        {
            public const byte Width = uint2.Width;

            readonly byte Data;

            [MethodImpl(Inline)]
            public LockIndicator(bit lockable, bit locked)
            {
                Data = 0;
                if(lockable)
                {
                    if(locked)
                        Data = 2;
                    else
                        Data = 1;
                }
            }

            public bit Lockable
            {
                [MethodImpl(Inline)]
                get => Data == 1 || Data == 2;
            }

            public bit Locked
            {
                [MethodImpl(Inline)]
                get => Data == 2;
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

            [MethodImpl(Inline)]
            public int CompareTo(LockIndicator src)
                => new LockSort(this).CompareTo(new LockSort(src));

            public static LockIndicator Empty => default;

            public string Format()
                => IsEmpty ? EmptyString : Locked.Format();

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static explicit operator uint2(LockIndicator src)
                => (uint2)src.Data;

            [MethodImpl(Inline)]
            public static explicit operator uint(LockIndicator src)
                => (uint)src.Data;

        }
    }
}