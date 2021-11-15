//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ProjectId<T>
        where T : IProject
    {
        public ProjectId Id {get;}

        [MethodImpl(Inline)]
        public ProjectId(string name)
            => Id = name;

        [MethodImpl(Inline)]
        public ProjectId(ProjectId id)
            => Id = id;

        [MethodImpl(Inline)]
        public static implicit operator ProjectId<T>(string id)
            => new ProjectId<T>(id);

        [MethodImpl(Inline)]
        public static implicit operator ProjectId<T>(ProjectId id)
            => new ProjectId<T>(id);
    }
}