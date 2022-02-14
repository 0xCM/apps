//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    public interface ISourceCode : ICorrelated, IHashed
    {
        SourceText Source {get;}

        uint IHashed.Hash
            => Source.Hash;
    }

    public interface ISourceCode<T> : ISourceCode, IEquatable<T>, IComparable<T>
        where T : ISourceCode<T>
    {

    }

    public interface ISourceCode<T,D> : ISourceCode<T>
        where T : ISourceCode<T,D>
    {
        D Data {get;}
    }
}