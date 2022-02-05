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

        ApiCodeCollector CodeCollector => Service(Wf.ApiCodeCollector);

        [CmdOp("check/capture/res")]
        Outcome CaptureResources(CmdArgs args)
        {
            using var symbols = SymbolDispenser.alloc();
            // var components = ApiRuntimeCatalog.Components;
            // var accessors = SpanRes.accessors(components);
            // var count = accessors.Count;
            // for(var i=0; i<count; i++)
            // {
            //     ref readonly var accessor = ref accessors[i];
            //     var address = accessor.Member.Location;
            //     var data = ByteReader.read16(address.Ref<byte>());

            //     Write(string.Format("{0} {1} {2}", accessor.Member.Location, data.Bytes.FormatHex(), accessor.Member.Sig.Format()));
            // }

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
                //Write(captured.AccessedData);
            }

            return true;
        }

        [CmdOp("check/capture")]
        Outcome CheckLiveStubs(CmdArgs args)
        {
            using var symbols = SymbolDispenser.alloc();
            if(args.Count != 0)
            {
                var input = text.trim(arg(args,0).Value.Format());
                var components = text.split(input,Chars.FSlash);
                if(components.Length == 2)
                {
                    var part = ApiParsers.part(skip(components,0));
                    var uri = ApiHostUri.define(part, skip(components,1));
                    var path = ProjectDb.Logs() + Tables.filename<EncodedMemberInfo>(uri.HostName);
                    var encoded = CodeCollector.Collect(symbols, uri, path);
                }
            }
            else
            {
                var encoded = CodeCollector.Collect(symbols);

            }
            return true;
        }

        [CmdOp("check/captured")]
        Outcome CheckCaptured(CmdArgs args)
        {
            var result = CodeCollector.LoadCollected(out var index, out var members);
            if(result.Fail)
                return result;


            return result;
        }

        // [CmdOp("check/captured")]
        // Outcome CheckCaptured(CmdArgs args)
        // {
        //     using var symbols = SymbolDispenser.alloc();
        //     var src = CodeCollector.CollectCaptured(symbols, ApiHostUri.from(typeof(cpu)));
        //     var count = src.Count;
        //     for(var i=0; i<count; i++)
        //     {
        //         ref readonly var member = ref src[i];
        //         Rip rip = (member.EntryAddress, 5);
        //         Disp32 disp = (Disp32)((long)member.TargetAddress - (long)rip);
        //         var target = AsmRel32.target(rip, disp);
        //         Require.equal(target, member.TargetAddress);

        //         var disp2 = AsmRel32.disp(member.Code);
        //         Require.equal(disp2,disp);

        //         var disp3 = AsmRel32.disp(rip, member.TargetAddress);
        //         Require.equal(disp3,disp);

        //         @string statement = string.Format("jmp near ptr {0:x}h", (int)AsmRel32.reltarget(disp));
        //         var dispFormat = EmptyString;
        //         if(disp < 0)
        //         {
        //             dispFormat = string.Format("-0x{0:x}", ~disp + 1);
        //         }
        //         else
        //             dispFormat = string.Format("0x{0:x}", disp);

        //         Write(string.Format("{0} | {1,-12} | {2,-16} | {3,-24} | {4} | {5}", member.EntryAddress, disp2, target,  statement, member.Code, member.Uri), FlairKind.StatusData);
        //     }

        //     return true;
        // }

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
                using var symbols = SymbolDispenser.alloc();
                var stubs = CodeCollector.CollectCaptured(symbols, ApiHostUri.from(typeof(cpu)));
                foreach(var stub in stubs)
                {

                }
            }

            void Search()
            {
                using var symbols = SymbolDispenser.alloc();
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