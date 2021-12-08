//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    using static Root;
    using static core;

    partial class AsmCmdService
    {
        [CmdOp(".jump-stubs")]
        Outcome FindJumpStubs(CmdArgs args)
        {
            var host = typeof(AsmPrototypes.Calc64);
            var contract = typeof(AsmPrototypes.ICalc64);
            var stubs = JmpStubs.search(host);
            Write(stubs, JmpStub.RenderWidths);

            var imap = Clr.imap(host,contract);
            Write(imap.Format());

            return true;
        }

        [CmdOp("api/asm/jump-stubs")]
        Outcome ApiJumpStubs(CmdArgs args)
        {
            var stubs = JmpStubs.create(Wf);
            var blocks = stubs.SearchApi();
            foreach(var block in blocks)
            {

            }
            iter(blocks, block => Write(block.Format()));
            return true;
        }

        static Index<ApiHostUri> NestedHosts(Type src)
        {
            var dst = list<ApiHostUri>();
            var nested = @readonly(src.GetNestedTypes());
            var count = nested.Length;
            for(var i=0; i<count; i++)
            {
                var candidate = skip(nested,i);
                var uri = candidate.ApiHostUri();
                if(uri.IsNonEmpty)
                    dst.Add(uri);
            }
            return dst.ToArray();
        }

        void Produce()
        {
            var producer = Wf.AsmStatementProducer();
            var hosts = NestedHosts(typeof(AsmPrototypes));
            var count = producer.Produce(FS.FolderPath.Empty, Toolspace.nasm, hosts);
        }

        static ReadOnlySpan<byte> x7ffaa76f0ae0
            => new byte[32]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0xd1,0x48,0xb9,0x50,0x0f,0x24,0xa5,0xfa,0x7f,0x00,0x00,0x48,0xb8,0x30,0xdd,0x99,0xa6,0xfa,0x7f,0x00,0x00,0x48,0xff,0xe0,0};

        [CmdOp("checks/vector-encoding")]
        Outcome CheckV(CmdArgs args)
        {
            const byte count = 32;
            var mask = cpu.vindices(cpu.vload(w256,x7ffaa76f0ae0), 0x48);
            var bits = recover<bit>(Cells.alloc(w256).Bytes);
            var buffer = Cells.alloc(w256).Bytes;
            BitPack.unpack1x32(mask, bits);
            var j=z8;
            for(byte i=0; i<count; i++)
            {
                if(skip(bits,i))
                    seek(buffer,j++) = i;
            }

            var indices = slice(buffer,0,j);
            Write(indices.FormatList());
            return true;
        }

        [CmdOp("checks/metadata")]
        Outcome CheckMetadata(CmdArgs args)
        {
            CheckMetadata(PartId.Lib);
            return true;
        }

        void CheckMetadata(PartId part)
        {
            var tool = Wf.Roslyn();

            if(ApiRuntimeCatalog.FindComponent(part, out var assembly))
            {
                var name = string.Format("z0.{0}.compilation", part.Format());
                var metadata = SourceSymbolic.metaref(assembly);
                var comp = tool.Compilation(name, metadata);
                var symbol = comp.GetAssemblySymbol(metadata);
                var gns = symbol.GlobalNamespace;
                var types = gns.GetTypes();
                iter(types, show);
            }

            void show(CaSymbolModels.TypeSymbol src)
            {
                Write(src);
                var members = src.GetMembers();
                var count = members.Length;
                for(var i=0; i<count; i++)
                {
                    ref readonly var member = ref skip(members,i);
                    var desc = string.Format("{0}", member.Format());
                    var locations = member.Locations;
                    if(locations.Length != 0)
                    {
                        ref readonly var loc = ref first(locations);
                        if(loc != null)
                        {
                            desc += string.Format("{0} {1}", desc, loc.ToString());
                        }
                    }
                    Write(desc);

                }
            }
        }

        [CmdOp(".jump-stub-encode")]
        Outcome Poc(CmdArgs args)
        {
            var result = Outcome.Success;
            var stubs = JmpStubs.create(Wf);
            if(stubs.Create<ulong>(0))
            {
                var encoded = stubs.EncodeDispatch(0);
                Write(encoded.FormatHexData());
            }

            return result;
        }
    }
}