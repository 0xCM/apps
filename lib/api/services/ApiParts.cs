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
        public FS.FolderPath Source {get;}

        public FS.Files ManagedSources {get;}

        public IApiCatalog Catalog {get;}

        public Index<Assembly> Components
            => Catalog.Components;

        internal ApiParts(Assembly control, PartId[] parts, bool libonly)
        {
            Source = ApiRuntimeLoader.path(control).FolderPath;
            ManagedSources = ApiRuntimeLoader.managed(Source, libonly);
            Catalog = ApiRuntimeLoader.catalog(Source, parts, libonly);
        }

        internal ApiParts(Assembly control, FS.FolderPath source, bool libonly)
        {
            Source = source;
            ManagedSources = ApiRuntimeLoader.managed(Source, libonly);
            Catalog = ApiRuntimeLoader.catalog(ManagedSources);
        }
    }
}