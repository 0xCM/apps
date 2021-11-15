//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;
    using System.Linq;

    using static Root;
    using static core;

    public class ApiRuntimeCatalog : IApiCatalog
    {
        /// <summary>
        /// The parts included in the datset
        /// </summary>
        Index<IPart> _Parts;

        /// <summary>
        /// The dataset part identities
        /// </summary>
        Index<PartId> _PartIdentities;

        /// <summary>
        /// The part components included in the datset
        /// </summary>
        Index<Assembly> _PartComponents;

        /// <summary>
        /// The catalogs corresponding to each datset part
        /// </summary>
        ApiPartCatalogs _Catalogs;

        /// <summary>
        /// The hosts provided by the dataset parts
        /// </summary>
        Index<IApiHost> _ApiHosts;

        /// <summary>
        /// The operations provided by the datset hosts
        /// </summary>
        Index<MethodInfo> _Operations;

        Index<string> _ComponentNames;

        public ApiRuntimeCatalog(Index<IPart> parts, Index<Assembly> components, ApiPartCatalogs catalogs, Index<IApiHost> hosts, Index<PartId> partIds, Index<MethodInfo> ops)
        {
            _Parts = parts;
            _PartComponents = components;
            _Catalogs = catalogs;
            _ApiHosts = hosts;
            _PartIdentities = partIds;
            _Operations = ops;
            _ComponentNames = components.Select(x => x.GetName().Name);
        }

        public Index<IApiHost> FindHosts(ReadOnlySpan<ApiHostUri> src)
        {
            var dst = list<IApiHost>();
            var search = _ApiHosts.View;
            var kSrc = src.Length;
            var kSearch = search.Length;
            for(var i=0; i<kSrc; i++)
            {
                var match = skip(src,i);
                if(match.IsEmpty)
                    Throw.sourced("I can't deal with empty uri's");

                for(var j=0; j<kSearch; j++)
                {
                    var candidate = skip(search,j);
                    if(candidate.HostUri == match)
                    {
                        dst.Add(candidate);
                        break;
                    }
                }
            }
            return dst.ToArray();
        }

        public ReadOnlySpan<IPart> Parts
        {
            [MethodImpl(Inline)]
            get => _Parts;
        }

        public ReadOnlySpan<string> ComponentNames
        {
            [MethodImpl(Inline)]
            get => _ComponentNames;
        }

        public Index<Assembly> Components
        {
            [MethodImpl(Inline)]
            get => _PartComponents;
        }

        public ReadOnlySpan<PartId> PartIdentites
        {
            [MethodImpl(Inline)]
            get => _PartIdentities;
        }

        public ReadOnlySpan<IApiHost> ApiHosts
        {
            [MethodImpl(Inline)]
            get => _ApiHosts;
        }

        public ReadOnlySpan<MethodInfo> Methods
        {
            [MethodImpl(Inline)]
            get => _Operations;
        }

        public bool FindPart(PartId id, out IPart dst)
        {
            var count = _Parts.Length;
            var src = _Parts.View;
            dst = default;
            for(var i=0; i<count; i++)
            {
                ref readonly var part = ref skip(src,i);
                if(part.Id == id)
                {
                    dst = part;
                    return true;
                }
            }
            return false;
        }

        public bool FindComponent(PartId id, out Assembly dst)
        {
            var src = _PartComponents.View;
            var count = src.Length;
            dst = default;
            for(var i=0; i<count; i++)
            {
                ref readonly var component = ref skip(src,i);
                if(component.Id() == id)
                {
                    dst = component;
                    return true;
                }
            }
            return false;
        }

        public ReadOnlySpan<Assembly> FindComponents(params PartId[] parts)
        {
            var src = _PartComponents.View;
            var count = src.Length;
            var dst = core.list<Assembly>();
            var match = parts.ToHashSet();
            for(var i=0; i<count; i++)
            {
                ref readonly var component = ref skip(src,i);
                var id = component.Id();
                if(match.Contains(id))
                    dst.Add(component);
            }
            return dst.ViewDeposited();
        }

        public bool FindHost(ApiHostUri uri, out IApiHost host)
        {
            host = _ApiHosts.Where(h => h.HostUri == uri).FirstOrDefault();
            return host != null;
        }

        public bool FindMethod(OpUri uri, out MethodInfo method)
        {
            if(FindHost(uri.Host, out var host))
                return host.FindMethod(uri, out method);
            method = default;
            return false;
        }

        public Index<IApiPartCatalog> PartCatalogs(params PartId[] parts)
        {
            if(parts.Length == 0)
                return _Catalogs.Storage;
            else
                return from c in _Catalogs.Storage
                       where parts.Contains(c.PartId)
                       select c;
        }

        public Index<IApiHost> PartHosts(params PartId[] parts)
        {
            if(parts.Length == 0)
                return _ApiHosts;
            else
                return  from h in _ApiHosts
                        where parts.Contains(h.PartId)
                        select h;
        }

        public ReadOnlySpan<IPart> FindParts(params PartId[] parts)
        {
            var selected = core.hashset(parts);
            return _Parts.Where(p => selected.Contains(p.Id));
       }

        IPart[] IApiCatalog.Parts
            => _Parts;

        PartId[] IApiCatalog.PartIdentities
            => _PartIdentities;

        ApiPartCatalogs IApiCatalog.Catalogs
            => _Catalogs;

        IApiHost[] IApiCatalog.ApiHosts
            => _ApiHosts;
    }
}