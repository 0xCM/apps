//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.InteropServices;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct HashEntry : IComparable<HashEntry>
    {
        public const string TableId = "text.hashed";

        public uint Key;

        public Hash32 Code;

        public TextBlock Content;

        public int CompareTo(HashEntry src)
            => Key.CompareTo(src.Key);
    }
}