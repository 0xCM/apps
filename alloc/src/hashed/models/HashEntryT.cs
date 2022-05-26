//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Hashed
    {
        [Record(TableId), StructLayout(LayoutKind.Sequential)]
        public struct HashEntry<T> : IComparable<HashEntry<T>>
            where T : IEquatable<T>
        {
            public const string TableId = "text.hashed";

            public uint Key;

            public Hash32 Code;

            public T Content;

            public int CompareTo(HashEntry<T> src)
                => Key.CompareTo(src.Key);
        }
    }
}