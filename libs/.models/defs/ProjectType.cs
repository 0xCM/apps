//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Models
    {
        public readonly record struct ProjectType
        {
            public readonly ProjectKind Kind;

            [MethodImpl(Inline)]
            public ProjectType(ProjectKind kind)
            {
                Kind = kind;
            }

            public string Format()
                => $"{Kind}";

            [MethodImpl(Inline)]
            public static implicit operator ProjectType(ProjectKind kind)
                => new ProjectType(kind);

            [MethodImpl(Inline)]
            public static implicit operator ProjectKind(ProjectType type)
                => type.Kind;

            public static ProjectType Empty => default;
        }

        public enum ProjectKind
        {
            None,
        }
    }
}