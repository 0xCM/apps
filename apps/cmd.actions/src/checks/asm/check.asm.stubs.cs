//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    partial class CheckCmdProvider
    {
        [Free]
        public interface ICalc64
        {
            ulong Add(ulong a, ulong b);

            ulong Sub(ulong a, ulong b);

            ulong Mul(ulong a, ulong b);

            ulong Mod(ulong a, ulong b);
        }

        public readonly struct Calc64 : ICalc64
        {
            [Op]
            public ulong Add(ulong a, ulong b)
                => math.add(a,b);

            [Op]
            public ulong Mod(ulong a, ulong b)
                => math.mod(a,b);

            [Op]
            public ulong Mul(ulong a, ulong b)
                => math.mul(a,b);

            [Op]
            public ulong Sub(ulong a, ulong b)
                => math.sub(a,b);
        }

        ApiHexCollector ApiHexCollector => Service(Wf.ApiHexCollector);

        [CmdOp("check/capture")]
        Outcome CheckLiveStubs(CmdArgs args)
        {
            using var symbols = SymbolDispenser.alloc();
            var encoded = ApiHexCollector.CollectLive(symbols);
            return true;
        }

        [CmdOp("check/captured")]
        Outcome CheckCaptured(CmdArgs args)
        {
            using var symbols = SymbolDispenser.alloc();
            var src = ApiHexCollector.CollectCaptured(symbols, ApiHostUri.from(typeof(cpu)));
            var count = src.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var member = ref src[i];
                Rip rip = (member.EntryAddress, 5);
                Disp32 disp1 = (Disp32)((long)member.TargetAddress - (long)rip);
                var target = AsmRel32.target(rip, disp1);
                Require.equal(target, member.TargetAddress);

                var disp2 = AsmHexSpecs.disp32(member.Code);
                var disp3 = AsmRel32.disp(rip, member.TargetAddress);

                var relTarget = (int)disp1 + (int)JmpRel32.InstSize;
                @string statement = string.Format("jmp near ptr {0:x}h", relTarget);


                var dispFormat = EmptyString;
                if(disp1 < 0)
                {
                    dispFormat = string.Format("-0x{0:x}", ~disp1 + 1);
                }
                else
                    dispFormat = string.Format("0x{0:x}", disp1);

                Write(string.Format("{0} | {1,-12} | {2,-16} | {3,-24} | {4} | {5}", member.EntryAddress, disp2, target,  statement, member.Code, member.Uri), FlairKind.StatusData);
            }

            return true;
        }

        [CmdOp("check/stubs/dispatch")]
        Outcome CheckStubDispatch(CmdArgs args)
        {
            var stubs = JmpStubs.create(Wf);
            if(stubs.Create<ulong>(0))
            {
                var encoded = stubs.EncodeDispatch(0);
                Write(encoded.FormatHexData());
            }

            return true;

        }

        [CmdOp("check/stubs/captured")]
        Outcome FindJumpStubs(CmdArgs args)
        {
            void Api()
            {
                using var symbols = SymbolDispenser.alloc();
                var stubs = ApiHexCollector.CollectCaptured(symbols, ApiHostUri.from(typeof(cpu)));
                foreach(var stub in stubs)
                {

                }
            }

            void Search()
            {
                using var symbols = SymbolDispenser.alloc();
                var host = typeof(Calc64);
                var contract = typeof(ICalc64);
                var stubs = ApiHexCollector.CollectLive(symbols,host);
                //Write(stubs.View, LiveMemberCode.RenderWidths);
                var imap = Clr.imap(host,contract);
                Write(imap.Format());
            }

            Api();

            return true;
        }
    }
}