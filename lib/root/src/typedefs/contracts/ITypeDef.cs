//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ITypeDef
    {
        bool IsSized {get;}

        Identifier TypeName {get;}
    }

    public interface ITypeDef<T> : ITypeDef
        where T : ITypeDef<T>, new()
    {

    }
}