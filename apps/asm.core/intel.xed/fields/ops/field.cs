//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedPatterns;

    partial class XedRules
    {
        [MethodImpl(Inline), Op]
        public static Field field(FieldKind kind, bit value)
            => Field.init(kind,value);

        [MethodImpl(Inline), Op]
        public static Field field(FieldKind kind, byte value)
            => Field.init(kind,value);

        [MethodImpl(Inline), Op]
        public static Field field(FieldKind kind, ushort value)
            => Field.init(kind,value);

        [MethodImpl(Inline), Op]
        public static Field field(FieldKind kind, Register value)
            => Field.init(kind,value);

        [MethodImpl(Inline), Op]
        public static Field field(FieldKind kind, BCastKind value)
            => Field.init(kind,value);

        [MethodImpl(Inline), Op]
        public static Field field(FieldKind kind, ChipCode value)
            => Field.init(kind,value);

        [MethodImpl(Inline), Op]
        public static Field field(FieldKind kind, InstClass value)
            => Field.init(kind,value);
    }
}