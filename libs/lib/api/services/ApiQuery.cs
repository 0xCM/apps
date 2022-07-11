//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public partial class ApiQuery : AppService<ApiQuery>
    {
        const NumericKind Closure = UnsignedInts;

        Index<IApiClass> _Classes;

        object locker;

        public ApiQuery()
        {
            _Classes = Index<IApiClass>.Empty;
            locker = new object();
        }

        public Index<IApiClass> ApiKinds()
        {
            lock(locker)
            {
                if(_Classes.IsEmpty)
                    _Classes = kinds();
            }
            return _Classes;
        }

        [Op]
        public static MethodInfo[] complete(Type src, HashSet<string> exclusions)
            => src.DeclaredMethods().Unignored().NonGeneric().Exclude(exclusions);

        [Op]
        public static MethodInfo[] methods(in ApiCompleteType src, HashSet<string> exclusions)
            => src.HostType.DeclaredMethods().Unignored().NonGeneric().Exclude(exclusions);

        [Op]
        static Dictionary<string,MethodInfo> index(Index<MethodInfo> methods)
        {
            var index = new Dictionary<string, MethodInfo>();
            core.iter(methods, m => index.TryAdd(ApiIdentity.identify(m).IdentityText, m));
            return index;
        }
    }
}