//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IApiParts
    {
        /// <summary>
        /// The root of the archive one which the api module set is predicated
        /// </summary>
        FS.FolderPath Source {get;}

        FolderFiles ManagedSources {get;}

        Index<Assembly> Components {get;}

        IApiCatalog Catalog {get;}
    }
}