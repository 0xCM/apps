//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IReifiedType
    {
        ITypeDef Definition {get;}

        bool Sized => false;
    }

    public interface IReifiedType<T> : IReifiedType
        where T : IReifiedType<T>
    {
        ITypeDef IReifiedType.Definition => new TypeDef(typeof(T).Name, Sized);
    }

    public interface IReifiedType<N,T> : IReifiedType<T>
        where T : IReifiedType<N,T>
        where N : unmanaged, ITypeNat
    {
        bool IReifiedType.Sized => true;
    }
}