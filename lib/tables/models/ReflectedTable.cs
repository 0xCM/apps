//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Describes an extant table
    /// </summary>
    public class ReflectedTable
    {
        public Type Type {get;}

        public TableId Id {get;}

        public ClrTableField[] Fields {get;}

        public LayoutKind? Layout {get;}

        public CharSet? CharSet {get;}

        public byte? Pack {get;}

        public uint? Size {get;}

        [MethodImpl(Inline)]
        public ReflectedTable(Type type, TableId id, ClrTableField[] fields, LayoutKind? layout = null, CharSet? charset = null, byte? pack = null, uint? size = null)
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