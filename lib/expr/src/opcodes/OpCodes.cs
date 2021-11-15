//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Expr
{
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    using Types;

    [ApiHost]
    public readonly struct OpCodes
    {
        const NumericKind Closure = UnsignedInts;

        const byte DomainWidth = 16;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static OpCode<K> encode<K>(Label name, Domain d, Hex32 code)
            where K : unmanaged
        {
            var encoded = (ulong)d | (ulong)code << DomainWidth;
            return new OpCode<K>(name, @as<ulong,K>(encoded));
        }

        [MethodImpl(Inline), Op]
        public static OpCode encode(Label name, Domain d, Hex32 code)
        {
            var encoded = (ulong)d | (ulong)code << DomainWidth;
            return new OpCode(name, encoded);
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Hex32 code<K>(OpCode<K> src)
            where K : unmanaged
                => (uint)(bw64(src.Data) >> DomainWidth);

        [MethodImpl(Inline), Op]
        public static Hex32 code(OpCode src)
            => (uint)(src.Data >> DomainWidth);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Domain domain<K>(OpCode<K> src)
            where K : unmanaged
                => bw16(src.Data);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static OpCode untype<K>(OpCode<K> src)
            where K : unmanaged
                => new OpCode(src.Name, bw64(src.Data));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Domain domain(OpCode src)
            => u16(src.Data);

        public static string format(OpCode src)
        {
            var val = code(src).Format();
            var tbl = src.Domain;
            var name = src.Name;
            return string.Format("{0} {1} {2}:{3}",name, (char)LogicSym.Def, tbl, val);
        }
    }
}