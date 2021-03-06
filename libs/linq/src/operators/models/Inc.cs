//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Linq.Expressions;

    using static Root;
    using static core;
    using static LinqXPress;

    partial struct ModelsDynamic
    {
        public readonly struct Inc<T>
        {
            static readonly Option<Func<T,T>> _OPSafe
                = TryConstruct();

            static Func<T,T> _OP
                => _OPSafe.Require();

            static Option<Func<T,T>> TryConstruct()
                => core.@try(() =>
                {
                    switch (sys.typecode<T>())
                    {
                        case TypeCode.Byte:
                            return cast<Func<T,T>>(Ops8u.Inc.Compile());
                        case TypeCode.SByte:
                            return cast<Func<T,T>>(Ops8i.Inc.Compile());
                        case TypeCode.UInt16:
                            return cast<Func<T,T>>(Ops16u.Inc.Compile());
                        case TypeCode.Int16:
                            return cast<Func<T,T>>(Ops16i.Inc.Compile());

                        default:
                            return lambda<T,T>(Expression.Increment).Compile();
                    }
                });

            public static T Apply(T x)
                => _OP(x);

            /// <summary>
            /// Specifies whether the operator exists for <typeparamref name="T"/>
            /// </summary>
            public static bool Exists
                => _OPSafe.IsSome();
        }
    }
}