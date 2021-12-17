//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ILiteralType : IType
    {

    }

    public interface ILiteralType<V> : ILiteralType
        where V : ITyped
    {
        V Value {get;}
    }
}