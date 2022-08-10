//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IApiCatalog
    {
        Index<IApiPartCatalog> PartCatalogs(params PartId[] parts);

        Index<IApiHost> PartHosts(params PartId[] parts);

        IPart[] Parts {get;}

        PartId[] PartIdentities {get;}

        Index<Assembly> Components {get;}

        ReadOnlySpan<string> ComponentNames {get;}

        ApiPartCatalogs Catalogs {get;}

        bool PartCatalog(PartId part, out IApiPartCatalog catalog);

        bool FindPart(PartId id, out IPart dst);

        bool Assembly(PartId id, out Assembly dst);
    }
}