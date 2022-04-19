//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.InteropServices;
    using System.Reflection;
    using System.Collections.Generic;

    using static core;

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

        [Op]
        public static ReadOnlySpan<ReflectedTable> reflected(ReadOnlySpan<Assembly> src)
        {
            var count = src.Length;
            var dst = list<ReflectedTable>();
            for(var i=0; i<count; i++)
                discover(skip(src,i), dst);
            return dst.ViewDeposited();
        }

        [Op]
        public static ReadOnlySpan<ReflectedTable> reflected(Assembly src)
        {
            var types = @readonly(src.Types().Tagged<RecordAttribute>());
            var count = types.Length;
            var dst = list<ReflectedTable>();
            discover(src, dst);
            return dst.ViewDeposited();
        }

        [Op]
        static uint discover(Assembly src, List<ReflectedTable> dst)
        {
            var types = @readonly(src.Types().Tagged<RecordAttribute>());
            var count = types.Length;
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                dst.Add(reflected(skip(types,i)));
                counter++;
            }

            return counter;
        }
    }
}