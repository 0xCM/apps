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
        public readonly struct ProjectProperty : IProjectProperty<ProjectProperty>
        {
            readonly IProjectProperty Definition;

            [MethodImpl(Inline)]
            public ProjectProperty(IProjectProperty src)
                => Definition = src;

            public Identifier Name
            {
                [MethodImpl(Inline)]
                get => Definition.Name;
            }

            public string Format()
                => Definition.Format();

            string IProjectProperty.Value
                => Definition.Value;
        }
    }
}