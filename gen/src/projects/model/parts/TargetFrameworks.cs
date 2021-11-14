//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct ProjectModel
    {
        public readonly struct TargetFrameworks
        {
            public const string netcoreapp = nameof(netcoreapp);

            public static TargetFramework netcoreapp3_0
            {
                [MethodImpl(Inline)]
                get => new TargetFramework(netcoreapp, FrameworkVersions.v3_0);
            }

            public static TargetFramework netcoreapp3_1
            {
                [MethodImpl(Inline)]
                get => new TargetFramework(netcoreapp, FrameworkVersions.v3_1);
            }
        }
    }
}