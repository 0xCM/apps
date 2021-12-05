//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Reflection.Metadata;

    using static Root;
    using static core;

    [StructLayout(LayoutKind.Sequential)]
    public readonly struct CliHandleData : ITextual, IComparable<CliHandleData>, IEquatable<CliHandleData>
    {
        [MethodImpl(Inline), Op]
        public static CliHandleData from(Handle src)
            => @as<Handle,CliHandleData>(src);

        [MethodImpl(Inline), Op]
        public static CliHandleData from(EntityHandle src)
        {
            var row = uint32(src) & 0xFFFFFF;
            var kind = (CliTableKind)(uint32(src) >> 24);
            return new CliHandleData(kind,row);
        }

        [MethodImpl(Inline), Op]
        public static Handle handle(CliHandleData src)
            => @as<CliHandleData,Handle>(src);

        [MethodImpl(Inline), Op]
        public Handle handle(CliToken src)
            => handle(new CliHandleData(src.Table, src.Row));

        [MethodImpl(Inline), Op]
        public static EntityHandle handle(uint src)
            => @as<uint,EntityHandle>(src);

        public uint RowId {get;}

        public CliTableKind Table {get;}

        [MethodImpl(Inline)]
        public CliHandleData(CliTableKind table, uint row)
        {
            RowId = row;
            Table = table;
        }

        [MethodImpl(Inline)]

        public bool Equals(CliHandleData src)
            => Table == src.Table && RowId == src.RowId;

        [MethodImpl(Inline)]
        public int CompareTo(CliHandleData src)
            => Table != src.Table ? ((byte)Table).CompareTo((byte)src.Table) : RowId.CompareTo(src.RowId);

        public string Format()
            => string.Format("{0:X2}:{1:x6}", (byte)Table, RowId);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Handle(CliHandleData src)
            => handle(src);

        [MethodImpl(Inline)]
        public static implicit operator CliHandleData(Handle src)
            => from(src);
    }
}