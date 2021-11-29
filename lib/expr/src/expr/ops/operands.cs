//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using Expr;

    using static Root;
    using static core;

    partial struct expr
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Operand<T> operand<T>(Label name, T value)
            => new Operand<T>(name, value);

        [Op, Closures(Closure)]
         public static Index<Operand> operands<T>(T src)
            where T : struct
        {
            var props = @readonly(typeof(T).DeclaredInstanceProperties());
            var fields = @readonly(typeof(T).DeclaredInstanceFields());

            var _ref = __makeref(src);
            var propcount = props.Length;
            var fieldcount = fields.Length;
            var count = propcount + fieldcount;
            var buffer = alloc<Operand>(count);
            ref var dst = ref first(buffer);
            var j=0u;
            for(var i=0; i<propcount; i++)
            {
                ref readonly var prop = ref skip(props,i);
                seek(dst,j++) = new Operand(prop.Name, prop.GetValue(src));
            }
            for(var i=0; i<fieldcount; i++)
            {
                ref readonly var field = ref skip(fields,i);
                seek(dst,j++) = new Operand(field.Name, field.GetValue(src));
            }

            return buffer;
        }
    }
}