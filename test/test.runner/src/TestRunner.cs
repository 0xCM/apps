//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
using System.Reflection;

namespace Z0
{
    public class TestRunner : TestApp<TestRunner>
    {
        // static void Main(params string[] args)
        //     => Run(core.array(PartId.Lib,PartId.TestUnits), args);

        protected override Assembly TargetComponent
            => Parts.TestUnits.Assembly;
    }
}