//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential,Pack=1)]
    public record struct DataTypeInfo : IComparable<DataTypeInfo>, ISequential<DataTypeInfo>
    {
        const string TableId = "api.datatype";

        [Render(6)]
        public uint Seq;

        [Render(32)]
        public PartName Part;

        [Render(32)]
        public asci64 Name;

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

        uint ISequential.Seq
        {
            get => Seq;
            set => Seq = value;
        }

        public static DataTypeInfo Empty => default;
    }
}