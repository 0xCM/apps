//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IReceiver<T>
    {
        void Deposit(in T src);
    }

    public interface IReceiver<A,B>
    {
        void Deposit(in A a, in B b);
    }

    public interface IReceiver<A,B,C>
    {
        void Deposit(in A a, in B b, in C c);
    }
}