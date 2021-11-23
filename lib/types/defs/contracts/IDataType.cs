//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IDataType
    {
        Identifier TypeName {get;}

        BitWidth ContentWidth {get;}

        BitWidth StorageWidth {get;}
    }
}
