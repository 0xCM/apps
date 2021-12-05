//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ISizedType : IType
    {
        BitWidth ContentWidth {get;}

        BitWidth StorageWidth {get;}
    }
}