//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Models
{

    public readonly record struct ProjectType
    {
        public readonly ProjectKind Kind;

        public ProjectType(ProjectKind kind)
        {
            Kind = kind;
        }

        public static implicit operator ProjectType(ProjectKind kind)
            => new ProjectType(kind);

        public static implicit operator ProjectKind(ProjectType type)
            => type.Kind;

        public static ProjectType Empty => default;
    }

    public enum ProjectKind
    {
        None,
    }

    public class ProjectTypes
    {

    }
}