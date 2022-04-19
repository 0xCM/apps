//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;
    using System.Reflection.Metadata;

    using static Root;
    using static core;

    partial struct Clr
    {
        [MethodImpl(Inline), Op]
        public static Handle handle(CliHandleData src)
            => @as<CliHandleData,Handle>(src);

        [MethodImpl(Inline), Op]
        public Handle handle(CliToken src)
            => handle(new CliHandleData(src.Table, src.Row));

        [MethodImpl(Inline), Op]
        public static EntityHandle handle(uint src)
            => @as<uint,EntityHandle>(src);

        [MethodImpl(Inline), Op]
        public static ClrHandle<RuntimeMethodHandle> MethodHandle(Module src, CliToken token)
            => new ClrHandle<RuntimeMethodHandle>(ClrArtifactKind.Method, token, src.ModuleHandle.GetRuntimeMethodHandleFromMetadataToken((int)token));

        [MethodImpl(Inline), Op]
        public static ClrHandle<RuntimeFieldHandle> FieldHandle(Module src, CliToken token)
            => new ClrHandle<RuntimeFieldHandle>(ClrArtifactKind.Field, token, src.ModuleHandle.GetRuntimeFieldHandleFromMetadataToken((int)token));

        [MethodImpl(Inline), Op]
        public static ClrHandle<RuntimeTypeHandle> TypeHandle(Module src, CliToken token)
            => new ClrHandle<RuntimeTypeHandle>(ClrArtifactKind.Type, token, src.ModuleHandle.GetRuntimeTypeHandleFromMetadataToken((int)token));
    }
}
