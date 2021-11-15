//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Expr
{
    using System.Runtime.CompilerServices;
    using System;

    using static core;

    using Lang;

    partial struct Dfa
    {
        [Op]
        public static Index<DfaState<uint>> states(W32 w, uint count)
        {
            var dst = alloc<DfaState<uint>>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = state(i, lang.atom((uint)(i + 1), (uint)i));
            return dst;
        }

        public static Index<DfaState<K>> states<K>()
            where K : unmanaged, Enum
        {
            var syms = Symbols.index<K>();
            var view = syms.View;
            var count = syms.Count;
            var dst = alloc<DfaState<K>>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var s = ref skip(view,i);
                seek(dst,i) = state(i, lang.atom(s.Key, s.Kind));
            }
            return dst;
        }

        /// <summary>
        /// Creates a sequence of states predicated on a sequence of characters
        /// </summary>
        /// <param name="src"></param>
        public static Index<DfaState<char>> states(ReadOnlySpan<char> src)
        {
            var count = src.Length;
            var dst = alloc<DfaState<char>>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var c = ref skip(src,i);
                seek(dst,i) = state(i, lang.atom((uint)c, c));
            }
            return dst;
        }
    }
}