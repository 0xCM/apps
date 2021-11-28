//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial struct Cmd
    {
        public static CmdIndex<K> index<K>(uint? count = null)
            where K : unmanaged, Enum
        {
            var fields = @readonly(typeof(K).Fields().Tagged<CmdSpecAttribute>());
            var fCount = (uint)fields.Length;
            var _count = count ?? fCount;
            var dst = new CmdIndex<K>(alloc<CmdInfo<K>>(fCount));
            ref var buffer = ref dst.First;
            for(var i=0; i<fCount; i++)
            {
                ref readonly var field = ref skip(fields,i);
                var tag = field.Tag<CmdSpecAttribute>().Require();
                seek(buffer,i) = new CmdInfo<K>((K)field.GetRawConstantValue(), tag.Name, tag.Description);
            }
            return dst;
        }
    }
}