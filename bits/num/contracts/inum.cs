//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface inum : IDataType
    {
        byte PackedWidth {get;}

        byte NativeWidth {get;}

        ulong Value {get;}

        bit IsMax  {get;}

        bit IsZero => Value == 0;

        bit IsNonZero => Value != 0;

        DataSize IDataType.Size
            => (PackedWidth,NativeWidth);
    }

    [Free]
    public interface inum<T> : inum, IEquatable<T>, IComparable<T>
        where T : unmanaged, inum<T>
    {
        asci64 IDataType.Name
            => typeof(T).Name;

        byte inum.NativeWidth
            => (byte)core.width<T>();
    }
}