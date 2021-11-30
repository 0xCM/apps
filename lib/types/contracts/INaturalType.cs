//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a type predicated on a natural number
    /// </summary>
    /// <typeparam name="N"></typeparam>
    public interface INaturalType<N> : ITypeDef, IParametricType
        where N : unmanaged, ITypeNat
    {
        uint IParametricType.Arity
            => 1;
    }

    public interface INaturalType<N,T> : INaturalType<N>
        where N : unmanaged, ITypeNat
        where T : INaturalType<N,T>,new()
    {

    }
}