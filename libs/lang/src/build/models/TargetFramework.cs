//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class MsBuild
    {
        public readonly struct TargetFramework : IBuildProperty
        {
            public const string TagName = nameof(TargetFramework);

            public dynamic Value {get;}

            public Identifier Name
                => TagName;

            [MethodImpl(Inline)]
            public TargetFramework(dynamic value)
                => Value = value;

            [MethodImpl(Inline)]
            public TargetFramework(dynamic value, Version ver)
                => Value = value.ToString() + ver.Format();


        }
    }
}