//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface INumber
    {
        byte PackedWidth {get;}

        // byte NativeWidth {get;}

        ulong Value {get;}

        // bit IsMax  {get;}

        // bit IsZero => Value == 0;

        // bit IsNonZero => Value != 0;

        // DataSize IDataType.Size
        //     => (PackedWidth,NativeWidth);
    }

    [Free]
    public interface INumber<T> : INumber, IEquatable<T>, IComparable<T>
        where T : unmanaged, INumber<T>
    {
        // asci64 IDataType.Name
        //     => typeof(T).Name;

        // byte INumber.NativeWidth
        //     => (byte)core.width<T>();

        // S Force<S>()
        //     where S : unmanaged;
    }
}