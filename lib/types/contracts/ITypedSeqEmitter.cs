//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.IO;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface ITypedSeqEmitter<S,T>
        where S : ITyped
        where T : ITyped
    {
        Outcome Emit(ITypedSeq<S> src, ISink<T> dst);
    }

    [Free]
    public interface ITypedSeqEmitter<S,C,T>
        where S : ITyped
        where T : ITyped
    {
        Outcome Emit(ITypedSeq<S> src, C config, ISink<T> dst);
    }

    [Free]
    public interface ITypedSeqEmitter<S>
        where S : ITyped
    {
        Outcome Emit(ITypedSeq<S> src, StreamWriter dst);
    }
}