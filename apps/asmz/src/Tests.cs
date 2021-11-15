//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Reflection;
    using System.Linq;
    using System.IO;
    using Z0.Tools;

    using static Root;
    using static core;

    public class Tests : AppService<Tests>
    {
        public void ProcessMsDocs()
        {
            var src = FS.dir(@"J:\docs\msdocs-sdk-api\sdk-api-src\content\dbghelp");
            var dst = Db.AppLog("dbghelp", FS.ext("yml"));
            var tool = Wf.MsDocs();
            tool.Process(src,dst);
        }

        void CheckMetadata(PartId part)
        {
            var tool = Wf.Roslyn();
            if(Wf.ApiCatalog.FindComponent(part, out var assembly))
            {
                var name = string.Format("z0.{0}.compilation", part.Format());
                var metadata = SourceSymbolic.metaref(assembly);
                var comp = tool.Compilation(name, metadata);
                var symbol = comp.GetAssemblySymbol(metadata);
                var gns = symbol.GlobalNamespace;
                var types = gns.GetTypes();
                iter(types, show);
            }

            void show(CodeSymbolModels.TypeSymbol src)
            {
                Wf.Row(src);
                iter(src.GetMembers(), m => Wf.Row(m));
            }
        }

        const byte FieldCount = 2;

        public static ReadOnlySpan<byte> SlotWidths
            => new byte[FieldCount]{8,32};

        public static string pattern()
        {
            var sbuffer = span<char>(1024);
            return text.format(slice(sbuffer, 0, text.slot(SlotWidths, Chars.Pipe, sbuffer)));
        }

        void CollectMemStats()
        {
            var dst = Db.ProcessContextRoot();
            var pipe = Wf.ProcessContextPipe();
            var ts = core.timestamp();
            var flags = ProcessContextFlag.Detail | ProcessContextFlag.Summary | ProcessContextFlag.Hashes;
            var prejit = pipe.Emit(dst, ts, "prejit", flags);
            var members = Wf.ApiJit().JitCatalog();
            var postjit = pipe.Emit(dst, ts, "postjit", flags);
        }

        static ReadOnlySpan<byte> x7ffaa76f0ae0
            => new byte[32]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0xd1,0x48,0xb9,0x50,0x0f,0x24,0xa5,0xfa,0x7f,0x00,0x00,0x48,0xb8,0x30,0xdd,0x99,0xa6,0xfa,0x7f,0x00,0x00,0x48,0xff,0xe0,0};

        void CheckV()
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
            Wf.Row(indices.FormatList());
        }

        public void DeriveMsil()
        {
            var pipe = Wf.MsilPipe();
            var files = pipe.MetadataFiles().View;
            var count = files.Length;
            for(var i=0; i<count; i++)
            {
                var src = skip(files,i);
                var dst = Db.AppLogRoot() + src.FileName.ChangeExtension(FS.Il);
                var records = pipe.LoadMetadata(src);
                pipe.EmitCode(records, dst);
            }
        }

        void CreateSymbolHeap()
        {
            var symbolic = Wf.Symbolism();
            var literals = symbolic.DiscoverLiterals();
            Wf.Status($"Creating heap for {literals.Length} literals");
            var heap = SymHeaps.specify(literals);
            var count = heap.SymbolCount;
            var dst = Db.AppLog("heap", FS.Csv);
            var emitting = Wf.EmittingFile(dst);
            using var writer = dst.Writer();
            for(ushort i=0; i<count; i++)
            {
                var expr = heap.Expression(i);
                var id = heap.Identifier(i);
                writer.WriteLine(string.Format("{0:D6} | {1,-32} | {2}", i, id, expr));
            }
            Wf.EmittedFile(emitting,count);
        }

        public void CollectEntryPoints()
        {
            var catalog = Wf.ApiCatalog;
            var jit = Wf.ApiJit();
            var members = jit.JitCatalog(catalog);
            var flow = Wf.Running("Creating method table");
            var table = MethodEntryPoints.create(core.controller().Id(), members);
            Wf.Ran(flow, $"Created method table with {table.View.Length} entries");
        }

        void CheckMullo(IBoundSource Source)
        {
            var @class = ApiClassKind.MulLo;
            var count = 12;
            var left = Source.Array<uint>(count,100,200);
            var right = Source.Array<uint>(count,100,200);
            var buffer = alloc<uint>(count);
            ref readonly var x = ref first(left);
            ref readonly var y = ref first(right);
            ref var dst = ref first(buffer);
            var results = alloc<TextBlock>(count);
            var output = alloc<uint>(count);
            ref var expected = ref first(output);
            ref var calls = ref first(results);
            for(var i=0; i<count; i++)
            {
                ref readonly var a = ref skip(x,i);
                ref readonly var b = ref skip(y,i);
                ref var actual = ref seek(dst,i);
                ref var expect = ref seek(expected,i);
                actual = cpu.mullo(a,b);
                expect = math.mul(a,b);
                //seek(calls, i) = ApiCalls.result(@class,a,b,actual);
            }

            for(var i=0; i<count; i++)
            {
                ref readonly var call = ref skip(calls,i);
                ref readonly var expect = ref skip(expected,i);
                Wf.Row(call.Format() + " ?=? " + expect.ToString());
            }
        }

        public void CheckClrKeys()
        {
            var types = Wf.ApiCatalog.Components.Storage.Types();
            var unique = hashset<Type>();
            var count = unique.Include(types).Where(x => x).Count();
            Wf.Row($"{types.Length} ?=? {count}");
            var fields = Wf.ApiCatalog.Components.Storage.DeclaredStaticFields();
            iter(fields, f => Wf.Row(f.Name + ": " + f.FieldType.Name));
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
            var hosts = NestedHosts(typeof(Prototypes));
            var count = producer.Produce(FS.FolderPath.Empty, Toolspace.nasm, hosts);
        }

        void ShowCases2()
        {
            const string LogName = "CoreCLR_Windows_NT__x64__Debug.log";
            var descriptors = Resources.descriptors(Wf.Controller, LogName);
            if(descriptors.ResourceCount == 1)
            {
                var data = descriptors[0].Utf8();
                using var reader = new StringReader(data.ToString());
                var line = reader.ReadLine();
                while(line != null)
                {
                    term.print(line);
                    line = reader.ReadLine();
                }
            }
        }

        void ShowDependencies()
        {
            ShowDependencies(Wf.Controller);
        }

        void ShowDependencies(Assembly src)
        {
            var deps = JsonDepsLoader.from(src);
            var libs = deps.Libs();
            var rtlibs = deps.RuntimeLibs();
            var options = deps.Options();
            var target = deps.Target();
            var graph = deps.Graph;
            Wf.Row(string.Format("Target: {0} {1} {2}", target.Framework, target.Runtime, target.RuntimeSignature));
            iter(libs, lib => Wf.Row(lib.Name));
            var buffer = text.buffer();
            iter(rtlibs, lib => lib.Render(buffer));
            Wf.Row(buffer.Emit());
        }

        void CalcAddress()
        {
            // ; BaseAddress = 7ffc56862280h
            // 0025h call 7ffc52e94420h                      ; CALL rel32                       | E8 cd                            | 5   | e8 76 21 63 fc
            // Expected: 7ffc56862310h
            const ulong FunctionBase = 0x7ffc56862280;
            const ushort InstructionOffset = 0x25;
            const byte InstructionSize = 0x5;
            const ulong Displacement = 0xfc632176;
            var instruction = array<byte>(0xe8, 0x76, 0x21, 0x63, 0xfc);
            MemoryAddress Encoded =  0x7ffc52e94420;
            MemoryAddress nextIp = asm.nextip(FunctionBase, InstructionOffset, InstructionSize);
            MemoryAddress target = nextIp + Displacement;
        }

        void CheckFlags()
        {
            var flags = Clr.@enum<MinidumpRecords.MinidumpType>();
            var summary = flags.Describe();
            var count = summary.FieldCount;
            var details = summary.LiteralDetails;

            if(count == 0)
                Wf.Error("No flags");

            for(var i=0; i<count; i++)
            {
                ref readonly var detail = ref skip(details,i);
                var description = string.Format("{0,-12} | {1,-48} | {2}", detail.Position, detail.Name, detail.ScalarValue.FormatHex());
                Wf.Row(description);
            }
        }

        public void ShowCommands()
        {
            var models = Cmd.cmdtypes(Wf.Components).View;
            var count = models.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var model = ref skip(models,i);
                Wf.Row(string.Format("{0,-3} {1}", i, model.SourceType.Name));
            }
        }

        static string FormatAttributes(IXmlElement src)
            => src.Attributes.Select(x => string.Format("{0}={1}",x.Name, x.Value)).Delimit(Chars.Comma).Format();

        void ConvertPdbXml()
        {
            var dir = Db.ToolOutDir(Toolspace.pdb2xml);
            var file = PartId.Math.Component(FS.Pdb, FS.Xml);
            var srcPath = dir + file;
            var buffer = text.buffer();

            var dstPath = Db.AppDataFile(file.WithExtension(FS.Log));
            using var writer = dstPath.Writer();

            const string Pattern = "{0}/{1}:{2}";

            void HandleFiles(IXmlElement src)
                => writer.WriteLine(string.Format(Pattern, src.Ancestor, src.Name, FormatAttributes(src)));

            void HandleMethods(IXmlElement src)
                => writer.WriteLine(string.Format(Pattern, src.Ancestor, src.Name, FormatAttributes(src)));

            void HandleSequencePointEntry(IXmlElement src)
                => writer.WriteLine(string.Format(Pattern, src.Ancestor, src.Name, FormatAttributes(src)));


            var handlers = new ElementHandlers();
            handlers.AddHandler("file", HandleFiles);
            handlers.AddHandler("method", HandleMethods);
            handlers.AddHandler("entry", HandleMethods);

            var flow = Wf.EmittingFile(dstPath);
            using var xml = XmlSource.create(srcPath);
            xml.Read(handlers);
            Wf.EmittedFile(flow,1);
        }

        public void RunPipes()
        {
            using var flow = Wf.Running();
            var data = Wf.Polysource.Span<ushort>(2400);

            // var input = Pipes.pipe<ushort>();
            // var incount = Pipes.flow(data, input);
            // var output = Pipes.pipe<ushort>();
            // var outcount = Pipes.flow(input,output);

            //Wf.Ran(flow, $"Ran {incount} -> {outcount} values through pipe");
        }

        MemoryAddress GetKernel32Proc(string name = "CreateDirectoryA")
        {
            var flow = Wf.Running();
            using var kernel = NativeModules.kernel32();
            Wf.Row(kernel);

            var f = NativeModules.func<OS.Delegates.GetProcAddress>(kernel, nameof(OS.Delegates.GetProcAddress));
            Wf.Row(f);

            var address = (MemoryAddress)f.Invoke(kernel, name);
            Wf.Row(address);

            Wf.Ran(flow);

            return address;
        }

        public static ReadOnlySpan<byte> TestCase01
            => new byte[44]{0x0f,0x1f,0x44,0x00,0x00,0x49,0xb8,0x68,0xd5,0x9e,0x18,0x36,0x02,0x00,0x00,0x4d,0x8b,0x00,0x48,0xba,0x28,0xd5,0x9e,0x18,0x36,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0xb8,0x90,0x2c,0x8b,0x64,0xfe,0x7f,0x00,0x00,0x48,0xff,0xe0};

        public static bool TestJmpRax(ReadOnlySpan<byte> src, int offset, out byte delta)
        {
            delta = 0;
            if(offset >= 3)
            {
                ref readonly var s2 = ref skip(src,offset - 2);
                ref readonly var s1 = ref skip(src,offset - 1);
                ref readonly var s0 = ref skip(src,offset - 0);
                if(s2 == 0x48 && s1 == 0xff && s0 == 0xe0)
                {
                    delta = 2;
                    return true;
                }
            }
            return false;
        }

        public int TestJmpRax()
        {
            var tc = TestCase01;
            var count = tc.Length;
            var address = MemoryAddress.Zero;
            for(var i=0; i<count; i++)
            {
                var result = TestJmpRax(tc, i, out var delta);
                if(result)
                {
                    var location = address - delta;
                    Wf.Status($"Jmp RAX found at {location.Format()}");
                    break;
                }
                address++;
            }
            return 0;
        }

        void CheckApiSigs()
        {
            var t0 = ApiSigs.type("uint");
            var t1 = ApiSigs.type("uint");
            var t2 = ApiSigs.type("bool");
            var op0 = ApiSigs.operand("a", t0);
            var op1 = ApiSigs.operand("b", t1);
            var r = ApiSigs.@return(t2);
            Wf.Row(ApiSigs.operation("equals", r, op0, op1));
        }


        void ListDescriptors()
        {
            var descriptors = ApiCode.descriptors(Wf);
            Wf.Row($"Loaded {descriptors.Count} descriptors");
        }

        void FilterApiBlocks()
        {
            var blocks = Wf.ApiCatalogs().Correlate();
            var f1 = ApiCodeBlocks.filter(blocks,ApiClassKind.And);
            iter(f1,f => Wf.Row(f.Uri));
        }
    }
}