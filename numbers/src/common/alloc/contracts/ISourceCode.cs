//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IAllocated<A>
    {
        A Allocated {get;}
    }

    public interface ISourceCode : IAllocated<SourceText>, ICorrelated
    {


    }

    public interface ISourceCode<T> : ISourceCode, IEquatable<T>, IComparable<T>
        where T : ISourceCode<T>
    {

    }

}