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
}