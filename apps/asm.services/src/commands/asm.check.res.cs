//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    partial class AsmCmdProvider
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

        [CmdOp("asm/check/res")]
        Outcome CaptureResources(CmdArgs args)
        {
            using var symbols = Alloc.symbols();
            var captures = CodeCollector.CaptureAccessors(symbols);
            var count = captures.Count;
            const sbyte Pad = -12;

            for(var i=0; i<count; i++)
            {
                ref readonly var captured = ref captures[i];
                Write(RP.attrib(Pad, "MemberUri", captured.Member.Uri));
                Write(RP.attrib(Pad, "MemberSig", captured.Member.Sig));
                Write(RP.attrib(Pad, "Code", captured.MemberCode));
                Write(RP.attrib(Pad, "Location", captured.DataSegment.BaseAddress));
                Write(RP.attrib(Pad, "Size", captured.DataSegment.Size));
                var data = captured.DataSegment.View;
                var partial = slice(data, 0, min(captured.DataSegment.Size, 12));
                Write(partial.FormatHex());
            }

            return true;
        }

        [CmdOp("check/stubs/dispatch")]
        Outcome CheckStubDispatch(CmdArgs args)
        {
            var stubs = X86Dispatcher.create(Wf);
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
                using var symbols = Alloc.symbols();
                //var stubs = CodeCollector.LoadCaptured(symbols, ApiHostUri.from(typeof(cpu)));
                // foreach(var stub in stubs)
                // {

                // }
            }

            void Search()
            {
                using var symbols = Alloc.symbols();
                var host = typeof(Calc64);
                var contract = typeof(ICalc64);
                //var stubs = CodeCollector.CollectLive(symbols,host);
                //Write(stubs.View, LiveMemberCode.RenderWidths);
                var imap = Clr.imap(host,contract);
                Write(imap.Format());
            }

            Api();

            return true;
        }
    }
}