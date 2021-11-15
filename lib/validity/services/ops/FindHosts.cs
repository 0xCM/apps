//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Linq;

    partial class TestApp<A>
    {
        public static Type[] FindHosts()
            =>  (from t in typeof(A).Assembly.Types().Realize<IUnitTest>()
                where t.IsConcrete() && t.Untagged<IgnoreAttribute>()
                orderby t.Name
                select t).Array();

        public static Type[] FindHosts(string[] names)
            =>  (from t in typeof(A).Assembly.Types().Realize<IUnitTest>()
                where t.IsConcrete() && t.Untagged<IgnoreAttribute>() && names.Contains(t.Name)
                orderby t.Name
                select t).Array();
    }
}