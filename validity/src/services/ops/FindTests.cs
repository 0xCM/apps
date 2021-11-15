//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;

    partial class TestApp<A>
    {
        public static MethodInfo[] FindTests(Type host)
            => host.NonSpecialMethods().Public().NonGeneric().WithArity(0);
    }
}