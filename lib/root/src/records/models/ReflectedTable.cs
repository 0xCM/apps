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

    /// <summary>
    /// Describes an extant table
    /// </summary>
    public class ReflectedTable
    {
        public Type Type {get;}

        public TableId Id {get;}

        public RecordField[] Fields {get;}

        public LayoutKind? Layout {get;}

        public CharSet? CharSet {get;}

        public byte? Pack {get;}

        public uint? Size {get;}

        [MethodImpl(Inline)]
        public ReflectedTable(Type type, TableId id, RecordField[] fields, LayoutKind? layout = null, CharSet? charset = null, byte? pack = null, uint? size = null)
        {

            Type = type;
            Id = id;
            Fields = fields;
            Layout = layout;
            CharSet = charset;
            Pack = pack;
            Size = size;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Id.IsEmpty || Fields == null;
        }
    }
}