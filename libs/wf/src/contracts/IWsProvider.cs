//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IWsProvider : IRootedArchive, IService
    {
        ref readonly WsId WsId {get;}

        FS.FolderPath Home {get;}

        FS.FolderPath IRootedArchive.Root
            => Home;
    }
}