//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ApiParts : IApiParts
    {
        /// <summary>
        /// The root of the archive one which the api module set is predicated
        /// </summary>
        public FS.FolderPath Home {get;}

        public FolderFiles ManagedSources {get;}

        public IApiCatalog Catalog {get;}

        internal ApiParts(Assembly control, FS.FolderPath home, FolderFiles ma,  PartId[] parts)
        {
            Home = home;
            ManagedSources = ma;
            Catalog = ApiLoader.catalog(home, parts, true);
        }

        internal ApiParts(Assembly control, FS.FolderPath home, FolderFiles ma, IApiCatalog catalog)
        {
            Home = home;
            ManagedSources = ma;
            Catalog = catalog;
        }
    }
}