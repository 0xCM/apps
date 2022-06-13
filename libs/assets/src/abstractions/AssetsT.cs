//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class Assets<T> : IAssets
        where T : Assets<T>, new()
    {
        public static T create()
            => new T();

        public Assembly DataSource
            => typeof(T).Assembly;

        readonly ComponentAssets Components;

        protected Assets()
        {
            Components = Assets.assets(DataSource);
        }

        public ref readonly Asset Asset(ResourceName id)
        {
            var matches = Components.Filter(id);
            if(matches.Count == 0)
                Errors.Throw(string.Format("The assembly {0}, loaded from {1}, does not contain a resource with identifier {2}", DataSource.GetSimpleName(), DataSource.Location, id));

            return ref matches[0];
        }

        public ReadOnlySpan<Asset> Data
        {
            [MethodImpl(Inline)]
            get => Components.View;
        }
    }
}