//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using static Root;

    [ApiHost]
    public partial class ApiQuery : AppService<ApiQuery>
    {
        const NumericKind Closure = UnsignedInts;

        Index<IApiClass> _Classes;

        Index<ApiClassifier> _Classifiers;

        Index<SymLiteralRow> _ClassLiterals;

        object locker;

        public ApiQuery()
        {
            _Classes = Index<IApiClass>.Empty;
            locker = new object();
        }

        public ReadOnlySpan<IApiClass> ApiKinds()
        {
            lock(locker)
            {
                if(_Classes.IsEmpty)
                    _Classes = kinds();
            }
            return _Classes.View;
        }

        public ReadOnlySpan<SymLiteralRow> ApiClassLiterals()
        {
            lock(locker)
            {
                if(_ClassLiterals.IsEmpty)
                    _ClassLiterals = ClassLiterals();
            }
            return _ClassLiterals.View;
        }

        public ReadOnlySpan<ApiClassifier> ApiClassifiers()
        {
            lock(locker)
            {
                if(_Classifiers.IsEmpty)
                    _Classifiers = Classifiers();
            }
            return _Classifiers.View;
        }

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