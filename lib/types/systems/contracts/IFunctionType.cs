//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IFunctionType : IType
    {
        Index<Operand> Operands {get;}

        Operand Return {get;}

        Facets Facets {get;}
    }

    public interface IFunctionType<K> : IFunctionType, IType<K>
        where K : unmanaged
    {

    }
}