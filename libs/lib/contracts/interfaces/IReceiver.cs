//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    public interface IReceiver
    {
        void Deposit(dynamic src);
    }

    [Free]
    public interface IReceiver<T> : IReceiver
    {
        void Deposit(in T src);

        void IReceiver.Deposit(dynamic src)
            => Deposit((T)src);
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