//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    [ApiHost, RecordGroup]
    public readonly partial struct CliRows
    {
        [MethodImpl(Inline)]
        public static T create<T>()
            where T : unmanaged, ICliRecord<T>
                => new T();

        [MethodImpl(Inline)]
        public static ref T create<T>(out T dst)
            where T : unmanaged, ICliRecord<T>
        {
            dst = create<T>();
            return ref dst;
        }

        public static CliTableKind kind<T>(T t = default)
            where T : unmanaged, ICliRecord<T>
                => typeof(T).Tag<CliRecordAttribute>().MapValueOrDefault(x => x.TableKind, CliTableKind.Invalid);

        public static Type[] types()
            => typeof(CliRows).GetNestedTypes();
    }
}