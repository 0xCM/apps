//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;

    using static Root;

    [ApiHost]
    public readonly struct ClrArtifacts
    {
        /// <summary>
        /// Defines a reference to an artifact of parametric type
        /// </summary>
        /// <param name="src">The source artifact</param>
        /// <typeparam name="A">The artifact type</typeparam>
        [MethodImpl(Inline), Op]
        public static ClrArtifactRef reference(CliToken id, ClrArtifactKind kind, Name name)
            => new ClrArtifactRef(id,kind,name);

        /// <summary>
        /// Defines a reference to an artifact of parametric type
        /// </summary>
        /// <param name="src">The source artifact</param>
        /// <typeparam name="A">The artifact type</typeparam>
        [MethodImpl(Inline)]
        public static ClrArtifactRef reference<M>(M src)
            where M : MemberInfo
                => reference(src.MetadataToken, ClrArtifactKind.Field, src.Name);
    }
}