//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public interface ISourceCode : INullity, IMeasured, ICounted, IFinite, IHashed
    {
        uint CellSize {get;}

        ReadOnlySpan<byte> Data {get;}
    }

    public interface ISourceCode<T> : ISourceCode
        where T : unmanaged, IEquatable<T>
    {
        ReadOnlySpan<T> Cells {get;}

        uint ISourceCode.CellSize
            => size<T>();

        ReadOnlySpan<byte> ISourceCode.Data
            => bytes(Cells);
    }

    public interface ISourceCode<H,T> : ISourceCode<T>, IComparable<H>, IEquatable<H>
        where T : unmanaged, IEquatable<T>
        where H : ISourceCode<H,T>
    {

    }
}