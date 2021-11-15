//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static core;

    partial struct Cmd
    {
        public static CmdArgs args(ReadOnlySpan<string> src)
        {
            var dst = alloc<CmdArg>(src.Length);
            for(ushort i=0; i<src.Length; i++)
                seek(dst,i) = new CmdArg(skip(src,i));
            return dst;
        }

        public static CmdArgs args<T>(T cmd)
            where T : struct, IToolCmd<T>
        {
            var fields = typeof(T).DeclaredInstanceFields().Tagged<CmdArgAttribute>().ToReadOnlySpan();
            var count = fields.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var f = ref skip(fields,i);
                var a = f.Tag<CmdArgAttribute>().Require();
                var expr = a.Expression;
                if(a.IsFlag)
                {
                    var v = f.GetValue(cmd);
                    if(v is bit b0)
                    {

                    }
                    else if(v is bool b1)
                    {

                    }
                }
                else
                {

                }

            }

            return default;

        }
    }
}