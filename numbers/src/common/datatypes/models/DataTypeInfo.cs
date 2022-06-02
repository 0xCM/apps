//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential,Pack=1)]
    public record struct DataTypeInfo : IComparable<DataTypeInfo>
    {
        const string TableId = "api.datatype";

        [Render(32)]
        public PartName Part;

        [Render(32)]
        public string Name;

        [Render(12)]
        public bool Concrete;

        [Render(12)]
        public BitWidth PackedWidth;

        [Render(12)]
        public BitWidth NativeWidth;

        [Render(12)]
        public ByteSize NativeSize;

        public int CompareTo(DataTypeInfo src)
        {
            var result = Part.CompareTo(src.Part);
            if(result == 0)
                result = Name.CompareTo(src.Name);
            return result;
        }

        public static DataTypeInfo Empty => default;
    }
}