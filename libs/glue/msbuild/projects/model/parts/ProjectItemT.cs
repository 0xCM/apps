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
        public readonly struct ProjectItem<T> : IProjectItem<ProjectItem<T>>
            where T : IProjectItem
        {
            readonly T Definition;

            [MethodImpl(Inline)]
            public ProjectItem(T value)
                => Definition = value;

            public Identifier Name
            {
                [MethodImpl(Inline)]
                get => Definition.Name;
            }

            public string Format()
                => Name;

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator ProjectItem(ProjectItem<T> src)
                => new ProjectItem(src);

            [MethodImpl(Inline)]
            public static implicit operator ProjectItem<T>(T src)
                => new ProjectItem<T>(src);

            [MethodImpl(Inline)]
            public static implicit operator T(ProjectItem<T> src)
                => src.Definition;
        }
    }
}