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
    using System.Reflection.Metadata.Ecma335;

    using static Root;

    partial struct Clr
    {
        [MethodImpl(Inline), Op]
        public static CliToken token(Handle handle)
            => MetadataTokens.GetToken(handle);

        [MethodImpl(Inline), Op]
        public static CliToken token(EntityHandle handle)
            => MetadataTokens.GetToken(handle);

        [MethodImpl(Inline), Op]
        public static CliToken token(TableIndex table, uint row)
            => new CliToken(((uint)table << 24) | (0xFFFFFF &  row));

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static CliToken token<T>()
            => new CliToken(typeof(T));

        [MethodImpl(Inline), Op]
        public static CliToken token(Type src)
            => new CliToken(src);

        [MethodImpl(Inline), Op]
        public static CliToken token(FieldInfo src)
            => new CliToken(src);

        [MethodImpl(Inline), Op]
        public static CliToken token(PropertyInfo src)
            => new CliToken(src);

        [MethodImpl(Inline), Op]
        public static CliToken token(MethodInfo src)
            => new CliToken(src);

        [MethodImpl(Inline), Op]
        public static CliToken token(ParameterInfo src)
            => new CliToken(src);

        [MethodImpl(Inline), Op]
        public static CliToken token(Assembly src)
            => new CliToken(src);
    }
}