//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly record struct InstLock : IComparable<InstLock>
        {
            readonly byte Data;

            [MethodImpl(Inline)]
            public InstLock(bit lockable, bit locked)
            {
                Data = 0;
                if(lockable)
                {
                    if(locked)
                        Data = 2;
                    else
                        Data=1;
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

            public int CompareTo(InstLock src)
                => new LockSort(this).CompareTo(new LockSort(src));

            public static InstLock Empty => default;

            public string Format()
                => IsEmpty ? EmptyString : Locked.Format();

            public override string ToString()
                => Format();
        }
    }
}