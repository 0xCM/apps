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
    public interface ISeqEmitter<S,T>
        where S : IType
        where T : IType
    {
        Outcome Emit(ISeq<S> src, ISink<T> dst);
    }

    [Free]
    public interface ISeqEmitter<S,C,T>
        where S : IType
        where T : IType
    {
        Outcome Emit(ISeq<S> src, C config, ISink<T> dst);
    }

    [Free]
    public interface ISeqEmitter<S>
        where S : IType
    {
        Outcome Emit(ISeq<S> src, StreamWriter dst);
    }
}