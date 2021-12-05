//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IScalarType : IType
    {
        BitWidth ContentWidth {get;}

        BitWidth StorageWidth {get;}

        ScalarClass Class {get;}
    }
}