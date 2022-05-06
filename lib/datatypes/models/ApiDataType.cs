//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [Record(TableId)]
    public record struct ApiDataType : IComparable<ApiDataType>
    {
        public static Index<ApiDataType> discover(Assembly[] src)
        {
            var types = src.Types().Tagged<DataTypeAttribute>();
            var count = types.Length;
            var buffer = alloc<ApiDataType>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var type = ref skip(types,i);
                var tag = type.Tag<DataTypeAttribute>().Require();
                ref var dst = ref seek(buffer,i);
                dst = new ApiDataType(type.DisplayName(), tag.Name, type.IsOpenGeneric(), tag.Kind, tag.PackedWidth, tag.NativeWidth, tag.Virtual);
            }
            return buffer.Sort();
        }

        public const string TableId = "api.datatype";

        public const byte FieldCount = 7;

        public Identifier Name;

        public @string Specifier;

        public bool Parametric;

        public object Kind;

        public uint PackedWidth;

        public uint NativeWidth;

        public bool Virtual;

        [MethodImpl(Inline)]
        public ApiDataType(Identifier name, @string syntax, bool parametric, object kind, uint packed, uint native, bool @virtual)
        {
            Name = name;
            Specifier = syntax;
            Parametric = parametric;
            Kind = kind;
            PackedWidth = packed;
            NativeWidth = native;
            Virtual = @virtual;
        }

        public DataSize Size
        {
            [MethodImpl(Inline)]
            get => (PackedWidth,NativeWidth);
        }

        public int CompareTo(ApiDataType src)
            => Name.CompareTo(src.Name);

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{32,48,12,12,12,12,12};
    }
}