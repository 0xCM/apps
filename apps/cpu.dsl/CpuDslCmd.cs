//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static core;


    using Vdsl;

    public sealed partial class CpuDslCmd : AppCmdService<CpuDslCmd,CmdShellState>
    {
        Intrinsics.Checks IntrinsicChecks => Service(() => Intrinsics.Checks.create(Wf));

        [CmdOp("check")]
        Outcome RunChecks(CmdArgs args)
        {
            IntrinsicChecks.Run();
            return true;
        }


        [CmdOp("casemaps/check")]
        Outcome CheckCaseMaps(CmdArgs args)
        {
            var map = CaseMaps.@enum("map",
                paired(Hex3Seq.x02, u8(2)),
                paired(Hex3Seq.x03, u8(3)),
                paired(Hex3Seq.x04, u8(4))
                );

            var dst = text.buffer();
            CaseMaps.code(map,0u,dst);
            Write(dst.Emit());

            return true;
        }

        [CmdOp("bitfields/check")]
        Outcome CheckBitFields(CmdArgs args)
        {
            var storage = ByteBlock32.Empty;
            var buffer = storage.Bytes;
            ReadOnlySpan<uint> indices = new uint[]{3,33,59,61,101,203,222,224,225,226};
            gbits.enable(buffer, indices);
            var count = buffer.Length;
            for(var i=0u; i<count; i++)
            {
                ref readonly var cell = ref skip(buffer,i);
                if(cell != 0)
                {
                    Write(Bitfields.segment(cell, i*8, 8));
                }
            }

            return true;

        }
    }

    public interface ICaseMap<S,T>
    {
        Identifier Name {get;}

        ConstLookup<S,T> Cases {get;}
    }

    public class CaseMap<S,T> : ICaseMap<S,T>
    {
        public Identifier Name {get;}

        public ConstLookup<S,T> Cases {get;}

        public CaseMap(Identifier name, ConstLookup<S,T> cases)
        {
            Name = name;
            Cases = cases;
        }
    }

    public class EnumCaseMap<E,T> : CaseMap<E,T>
        where E : unmanaged, Enum
    {
        public EnumCaseMap(Identifier name, ConstLookup<E,T> cases)
            : base(name,cases)
        {

        }
    }

    public readonly struct CaseMaps
    {

        public static EnumCaseMap<E,T> @enum<E,T>(Identifier name, params Paired<E,T>[] src)
            where E : unmanaged, Enum
                => new EnumCaseMap<E,T>(name,src.ToDictionary());

        public static void code<E,T>(EnumCaseMap<E,T> src, uint offset, ITextBuffer dst)
            where E : unmanaged, Enum
        {
            var target = typeof(T).Name;
            var source = typeof(E).Name;
            dst.IndentLineFormat(offset, "public static {0} {1}({2} src)", target, src.Name, source);
            offset +=4;
            dst.IndentLine(offset, "=> src switch {");
            var cases = src.Cases.Entries;
            var count = cases.Length;
            var symbols = Symbols.index<E>();
            offset += 4;
            for(var i=0u; i<count; i++)
            {
                ref readonly var @case = ref skip(cases,i);
                var match = @case.Key;
                var symbol = symbols[match];
                var name = symbol.Name;
                var value = @case.Value;
                dst.IndentLineFormat(offset, "{0}.{1} => {2},", source, name, value);
            }
            dst.IndentLineFormat(offset, "_ => default({0})", target);
            offset -=4;
            dst.IndentLine(offset, "};");
        }

    }
}