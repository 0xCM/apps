//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [Record(TableId), StructLayout(LayoutKind.Sequential,Pack=1)]
    public record struct DataTypeRecord : IComparable<DataTypeRecord>, ISequential<DataTypeRecord>
    {
        public const string TableId = "api.datatype";

        public const byte FieldCount = 7;

        public uint Seq;

        public PartName Part;

        public asci64 Name;

        public BitWidth PackedWidth;

        public BitWidth NativeWidth;

        public ByteSize PackedSize;

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