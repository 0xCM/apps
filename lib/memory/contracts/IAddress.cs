//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IAddress : ITextual, INullity
    {
        NativeSize Capacity {get;}
    }

    public interface IAddress<T> : IAddress
        where T : unmanaged
    {
        T Location {get;}

        NativeSize IAddress.Capacity
            => Sizes.native<T>();

        bool INullity.IsEmpty
            => Location.Equals(default(T));
    }

    public interface IAddress<F,T> : IAddress<T>, INullary<F>, IEquatable<F>, IComparable<F>
        where F : unmanaged, IAddress<F,T>
        where T : unmanaged
    {

    }
}