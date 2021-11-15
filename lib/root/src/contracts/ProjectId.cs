//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Identifies an internal or external tool
    /// </summary>
    public struct ProjectId : ITypedIdentity<ProjectId,string>
    {
        public string Id {get;}

        [MethodImpl(Inline)]
        public ProjectId(string id)
            => Id = id;

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => string.IsNullOrEmpty(Id);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !string.IsNullOrWhiteSpace(Id);
        }

        [MethodImpl(Inline)]
        public string Format()
            => Id;

        public override string ToString()
            => Id;

        [MethodImpl(Inline)]
        public bool Equals(ProjectId src)
            => Id.Equals(src.Id);

        public override int GetHashCode()
            => Id.GetHashCode();

        public override bool Equals(object src)
            => src is ProjectId x && Equals(x);

        [MethodImpl(Inline)]
        public static implicit operator ProjectId(string src)
            => new ProjectId(src);

        [MethodImpl(Inline)]
        public static implicit operator string(ProjectId src)
            => src.Id;

        [MethodImpl(Inline)]
        public static bool operator ==(ProjectId a, ProjectId b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(ProjectId a, ProjectId b)
            => !a.Equals(b);

        [MethodImpl(Inline)]
        public static implicit operator ProjectId(Type src)
            => new ProjectId(src.Name);

        public static ProjectId Empty
        {
            [MethodImpl(Inline)]
            get => new ProjectId(EmptyString);
        }
    }
}