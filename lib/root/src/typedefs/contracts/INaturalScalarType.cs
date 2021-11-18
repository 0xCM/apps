//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IScalarType : ITypeDef
    {

    }

    public interface INaturalScalarType<N,T> : IScalarType, INaturalType<N>
        where T : INaturalScalarType<N,T>, new()
        where N : unmanaged, ITypeNat
    {

    }
}