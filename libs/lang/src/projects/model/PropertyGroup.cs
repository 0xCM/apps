//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class MsProjects
    {
        public readonly struct PropertyGroup
        {
            public const string TagName = nameof(PropertyGroup);

            public readonly Index<Property> Properties {get;}

            [MethodImpl(Inline)]
            public PropertyGroup(Index<Property> src)
                => Properties = src;
        }
    }
}