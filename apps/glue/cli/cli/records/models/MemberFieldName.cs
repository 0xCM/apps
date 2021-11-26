//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct MemberFieldName : IRecord<MemberFieldName>
    {
        public const string TableId = "image.fieldname";

        public Count Sequence;

        public ByteSize HeapSize;

        public Count Length;

        public Address32 Offset;

        public string Value;

        [MethodImpl(Inline)]
        public MemberFieldName(Count seq, ByteSize heap, Address32 offset, string value)
        {
            Sequence = seq;
            HeapSize = heap;
            Length = value.Length;
            Offset = offset;
            Value = value;
        }
    }
}