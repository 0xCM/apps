//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    /// <summary>
    /// Characterizes the api set exposed by a part
    /// </summary>
    [Free]
    public interface IApiPartCatalog
    {
        /// <summary>
        /// The defining assembly
        /// </summary>
        Assembly Component {get;}

        /// <summary>
        /// The operation hosts
        /// </summary>
        Index<IApiHost> OperationHosts {get;}

        /// <summary>
        /// Api types
        /// </summary>
        Index<ApiCompleteType> ApiTypes {get;}

        /// <summary>
        /// The known types that reify contracted operation services, potentially generic
        /// </summary>
        Index<Type> ServiceHosts {get;}

        /// <summary>
        /// The identity of the assembly that defines and owns the catalog
        /// </summary>
        PartId PartId {get;}

        /// <summary>
        /// The api hosts known to the catalog, including both operation and data type hosts
        /// </summary>
        ApiHosts ApiHosts {get;}

        /// <summary>
        /// The operations defined by <see cref='ApiHosts'/>
        /// </summary>
        Index<MethodInfo> Methods {get;}

        string ComponentPath {get;}

        bool Host(ApiHostUri uri, out IApiHost host);

        /// <summary>
        /// The component's manifest module
        /// </summary>
        Module ManifestModule {get;}

        /// <summary>
        /// Specifies whether the catalog contains content from an identified assembly
        /// </summary>
        bool IsIdentified {get;}

        /// <summary>
        /// Specifies whether the catalog describes any api hosts
        /// </summary>
        bool IsNonEmpty {get;}

        /// <summary>
        /// Specifies whether the catalog describes any api hosts
        /// </summary>
        bool IsEmpty {get;}

    }
}