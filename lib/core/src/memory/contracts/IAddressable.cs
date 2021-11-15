//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes an object that advertises its memory location
    /// </summary>
    public interface IAddressable : ITextual
    {
        MemoryAddress Address {get;}

        string ITextual.Format()
            => Address.Format();
    }

    /// <summary>
    /// Characterizes an object that advertises a parametric memory location
    /// </summary>
    /// <typeparam name="T">The parametric address type</typeparam>
    public interface IAddressable<T> : IAddressable
        where T : unmanaged, IAddress
    {
        new T Address {get;}

        MemoryAddress IAddressable.Address
            => core.@as<T,ulong>(Address);
    }

    /// <summary>
    /// Characterizes a reified addressable object
    /// </summary>
    /// <typeparam name="F">The reification type</typeparam>
    /// <typeparam name="T">The address type</typeparam>
    public interface IAddressable<F,T> : IAddressable<T>
        where F : IAddressable<F,T>, new()
        where T : unmanaged, IAddress
    {

    }
}