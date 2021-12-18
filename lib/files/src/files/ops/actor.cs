//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct FS
    {
        [MethodImpl(Inline), Op]
        public static Actor actor(Name name, ObjectKind source = ObjectKind.File, ObjectKind target = ObjectKind.File)
            => new Actor(name, source, target);

        [MethodImpl(Inline), Op]
        public static Actor<K> actor<K>(Name name, K modifier, ObjectKind source = ObjectKind.File, ObjectKind target = ObjectKind.File)
            where K : unmanaged
            => new Actor<K>(name, modifier, source, target);
    }
}