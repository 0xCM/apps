//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static Relations;

    //using api = OpCodes;

    [ApiHost]
    public readonly struct OcExpr
    {
        const NumericKind Closure = UnsignedInts;

        const byte DomainWidth = 16;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static OpCode<K> encode<K>(Domain domain, text31 name, Hex32 code)
            where K : unmanaged
        {
            return new OpCode<K>(domain, name, @as<ulong,K>((ulong)code));
        }

        [MethodImpl(Inline), Op]
        public static OpCode encode(text31 name, Domain domain, Hex32 code)
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

        public readonly struct OpCode<K>
            where K : unmanaged
        {
            public Domain Domain {get;}

            public text31 Name {get;}

            internal readonly K Data;

            [MethodImpl(Inline)]
            public OpCode(Domain domain, text31 name, K data)
            {
                Domain = domain;
                Name = name;
                Data = data;
            }

            public Hex32 Code
            {
                [MethodImpl(Inline)]
                get => code(this);
            }

            public string Format()
                => format(this);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator OpCode(OpCode<K> src)
                => untype(src);
        }

        public readonly struct OpCode
        {
            public Domain Domain {get;}

            public text31 Name {get;}

            internal readonly ulong Data;

            [MethodImpl(Inline)]
            public OpCode(Domain domain, text31 name, ulong data)
            {
                Domain = domain;
                Data = data;
                Name = name;
            }

            public Hex32 Code
            {
                [MethodImpl(Inline)]
                get => code(this);
            }

            public string Format()
                => format(this);

            public override string ToString()
                => Format();
        }
    }
}