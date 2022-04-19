//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IRecordSink
    {
        void Deposit(ValueType src);
    }

    /// <summary>
    /// Defines a T-record sink
    /// </summary>
    /// <typeparam name="T">The record type</typeparam>
    [Free]
    public interface IRecordSink<T> : IRecordSink, ISink<T>
        where T : struct
    {
        void Deposit(in T src);

        void ISink<T>.Deposit(T src)
            => Deposit(in src);

        void IRecordSink.Deposit(ValueType src)
            => Deposit((T)src);
    }
}