//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly record struct DataType : IDataType<DataType>, IComparable<DataType>
    {
        public readonly asci64 Name;

        public readonly DataSize Size;

        [MethodImpl(Inline)]
        public DataType(asci64 name, DataSize size)
        {
            Name = name;
            Size = size;
        }

        public string Format()
            => Name.Format();

        public override string ToString()
            => Format();

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Name.Hash | Size.Hash;
        }

        public override int GetHashCode()
            => Hash;

        public int CompareTo(DataType src)
            => Name.CompareTo(src.Name);

        asci64 IDataType.Name
            => Name;

        DataSize IDataType.Size
            => Size;
    }
}