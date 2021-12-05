//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.InteropServices;

    partial struct Tables
    {
        [Op]
        public static ReflectedTable reflected(Type type)
        {
            var layout = type.Tag<StructLayoutAttribute>();
            var id = TableId.identify(type);
            LayoutKind? kind = null;
            CharSet? charset = null;
            byte? pack = null;
            uint? size = null;
            layout.OnSome(a =>{
                kind = a.Value;
                charset = a.CharSet;
                pack = (byte)a.Pack;
                size = (uint)a.Size;
            });

            return new ReflectedTable(type, id, fields(type), kind, charset, pack,size);
        }
    }
}