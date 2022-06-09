//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class MsProjects
    {
        public readonly struct Project
        {
            public Sdk Sdk {get;}

            public Identifier Name {get;}

            public Index<PropertyGroup> PropertyGroups {get;}

            public Index<ItemGroup> itemGroups {get;}

            [MethodImpl(Inline)]
            public Project(Identifier name, Sdk sdk, Index<PropertyGroup> properties, Index<ItemGroup> items)
            {
                Name = name;
                Sdk = sdk;
                PropertyGroups = properties;
                itemGroups = items;
            }

            public string Format()
                => EmptyString;
        }
    }
}