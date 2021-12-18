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
    {
        V Value {get;}
    }
}