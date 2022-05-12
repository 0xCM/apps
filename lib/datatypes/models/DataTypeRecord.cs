//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential,Pack=1)]
    public record struct DataTypeRecord : IComparable<DataTypeRecord>, ISequential<DataTypeRecord>
    {
        public const string TableId = "api.datatype";

        public const byte FieldCount = 7;

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
        public ByteSize PackedSize;

        [Render(12)]
        public ByteSize NativeSize;

        public int CompareTo(DataTypeRecord src)
        {
            var result = Part.CompareTo(src.Part);
            if(result == 0)
                result = Name.CompareTo(src.Name);
            return result;
        }


        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{6,32,32,12,12,12,12};

        uint ISequential.Seq
        {
            get => Seq;
            set => Seq = value;
        }
    }
}