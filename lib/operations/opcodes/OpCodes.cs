//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops
{
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    [ApiHost]
    public readonly struct OpCodes
    {
        const NumericKind Closure = UnsignedInts;

        const byte DomainWidth = 16;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static OpCode<K> encode<K>(Domain domain, Label name, Hex32 code)
            where K : unmanaged
        {
            return new OpCode<K>(domain, name, @as<ulong,K>((ulong)code));
        }

        [MethodImpl(Inline), Op]
        public static OpCode encode(Label name, Domain domain, Hex32 code)
        {
            return new OpCode(domain, name, code);
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Hex32 code<K>(OpCode<K> src)
            where K : unmanaged
                => (uint)(bw64(src.Data) >> DomainWidth);

        [MethodImpl(Inline), Op]
        public static Hex32 code(OpCode src)
            => (uint)(src.Data >> DomainWidth);


        [MethodImpl(Inline), Op, Closures(Closure)]
        public static OpCode untype<K>(OpCode<K> src)
            where K : unmanaged
                => new OpCode(src.Domain, src.Name, bw64(src.Data));

        public static string format(OpCode src)
        {
            var val = code(src).Format();
            var tbl = src.Domain;
            var name = src.Name;
            return string.Format("{0} {1} {2}:{3}",name, (char)LogicSym.Def, tbl, val);
        }
    }
}