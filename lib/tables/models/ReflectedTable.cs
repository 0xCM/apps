//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    /// <summary>
    /// Describes an extant table
    /// </summary>
    public class ReflectedTable
    {
        [Op]
        public static ReflectedTable load(Type type)
        {
            var layout = type.Tag<StructLayoutAttribute>();
            var id = TableId.identify(type);
            LayoutKind? kind = null;
            CharSet? charset = null;
            byte? pack = null;
            uint? size = null;
            layout.OnSome(a =>{
                kind = a.Value;
                charset = a.CharSet;
                pack = (byte)a.Pack;
                size = (uint)a.Size;
            });

            return new ReflectedTable(type, id, Tables.fields(type), kind, charset, pack,size);
        }

        public readonly Type Type;

        public readonly TableId Id;

        public readonly ClrTableField[] Fields;

        public readonly LayoutKind? Layout;

        public readonly CharSet? CharSet;

        public readonly byte? Pack;

        public readonly uint? Size;

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