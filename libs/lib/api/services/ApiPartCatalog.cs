//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a catalog over a <see cref='IPart'/>
    /// </summary>
    public class ApiPartCatalog : IApiPartCatalog
    {
        /// <summary>
        /// The identity of the assembly that defines and owns the catalog
        /// </summary>
        public PartId PartId {get;}

        /// <summary>
        /// The assembly that defines and owns the catalog
        /// </summary>
        public Assembly Component {get;}

        /// <summary>
        /// The data types defined by the assembly
        /// </summary>
        public Index<ApiCompleteType> ApiTypes {get;}

        /// <summary>
        /// The api hosts known to the catalog, including both operation and data type hosts
        /// </summary>
        public ApiHosts ApiHosts {get;}

        /// <summary>
        /// The host-defined operations
        /// </summary>
        public Index<MethodInfo> Methods {get;}

        public ApiPartCatalog(PartId part, Assembly component, Index<ApiCompleteType> types, IApiHost[] apihosts, Type[] svchosts)
        {
            PartId = part;
            Component = component;
            ApiTypes = types;
            //OperationHosts = apihosts.Map(h => (IApiHost)h);
            ApiHosts = apihosts;
            Methods = apihosts.SelectMany(x => x.Methods);
        }

        /// <summary>
        /// Specifies whether the catalog contains content from an identified assembly
        /// </summary>
        public bool IsIdentified
            => PartId != 0;
    }
}