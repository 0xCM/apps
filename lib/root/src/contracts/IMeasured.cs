//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    using System.Runtime.CompilerServices;

    /// <summary>
    /// Characterizes a type that exhibits a notion of finite length
    /// </summary>
    [Free]
    public interface IMeasured : ICounted
    {
        int Length {get;}

        uint ICounted.Count
            => (uint)Length;
    }

    /// <summary>
    /// Characterizes a reified type that  exhibits a notion of length
    /// </summary>
    [Free]
    public interface IMeasured<M> : IMeasured, ICounted<M>
        where M : unmanaged
    {
        int IMeasured.Length
            => Unsafe.As<M,int>(ref Unsafe.AsRef(Length));

        uint ICounted.Count
            => Unsafe.As<M,uint>(ref Unsafe.AsRef(Length));

        new M Length
            => Count;

        M ICounted<M>.Count
            => Length;
    }
}