//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;

    using static Root;

    public abstract class Assets<T> : IAssets
        where T : Assets<T>, new()
    {
        public static T create()
            => new T();

        public Assembly DataSource
            => typeof(T).Assembly;

        ComponentAssets _Descriptors;

        protected Assets()
        {
            _Descriptors = ComponentAssets.from(DataSource);
        }

        public ref readonly Asset Asset(ResourceName id)
        {
            var matches = _Descriptors.Filter(id);
            if(matches.ResourceCount == 0)
            {
                var msg = string.Format("The assembly {0}, loaded from {1}, does not contain a resource with identifier {2}", DataSource.GetSimpleName(), DataSource.Location, id);
                core.@throw(msg);
            }

            return ref matches[0];
        }

        public ReadOnlySpan<Asset> Descriptors
        {
            [MethodImpl(Inline)]
            get => _Descriptors.View;
        }
    }
}