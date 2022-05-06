//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    [Free]
    public interface ISeq : IMeasured, ITextual
    {
        Type ElementType {get;}

        string ITextual.Format()
            => GetType().Name;
    }

    [Free]
    public interface ISeq<T> : ISeq
    {

        ReadOnlySpan<T> Elements {get;}

        Type ISeq.ElementType
            => typeof(T);

        uint ICounted.Count
            => (uint)Elements.Length;

        int IMeasured.Length
            => Elements.Length;

        bool INullity.IsEmpty
            => Elements.Length == 0;
    }

    [Free]
    public interface ISeq<N,T> : ISeq<T>
        where N : unmanaged, ITypeNat
    {
        uint ICounted.Count
            => core.nat32u<N>();
    }
}