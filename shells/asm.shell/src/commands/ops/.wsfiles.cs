//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;
    using System.Linq;

    partial class AsmCmdService
    {
        [CmdOp(".wsfiles")]
        Outcome WsFiles(CmdArgs args)
        {
            var result = Outcome.Success;
            var root = State.Workspace().Root;
            if(args.Length == 0)
            {
                Files(root.Files(true));
            }
            else
            {
                var filter = arg(args,0).Value;
                Files(root.Files(filter, true));
            }

            return result;
        }


        public void ProcessMsDocs()
        {
            var src = FS.dir(@"J:\docs\msdocs-sdk-api\sdk-api-src\content\dbghelp");
            var dst = Db.AppLog("dbghelp", FS.ext("yml"));
            var tool = Wf.MsDocs();
            tool.Process(src,dst);
        }

        void CollectMemStats()
        {
            var dst = Db.ProcessContextRoot();
            var pipe = Wf.Runtime();
            var ts = core.timestamp();
            var flags = ProcessContextFlag.Detail | ProcessContextFlag.Summary | ProcessContextFlag.Hashes;
            var prejit = pipe.Emit(dst, ts, "prejit", flags);
            var members = Wf.ApiJit().JitCatalog();
            var postjit = pipe.Emit(dst, ts, "postjit", flags);
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


        void ShowCases2()
        {
            const string LogName = "CoreCLR_Windows_NT__x64__Debug.log";

            // var descriptors = Resources.descriptors(Wf.Controller, LogName);
            // if(descriptors.ResourceCount == 1)
            // {
            //     var data = descriptors[0].Utf8();
            //     using var reader = new StringReader(data.ToString());
            //     var line = reader.ReadLine();
            //     while(line != null)
            //     {
            //         term.print(line);
            //         line = reader.ReadLine();
            //     }
            // }
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


        void CheckFlags()
        {
            var flags = Clr.@enum<MinidumpType>();
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

        static string FormatAttributes(IXmlElement src)
            => src.Attributes.Select(x => string.Format("{0}={1}",x.Name, x.Value)).Delimit(Chars.Comma).Format();

        void ConvertPdbXml()
        {
            var dir = Db.ToolOutDir("pdb2xml");
            var file = PartId.AsmCore.Component(FS.Pdb, FS.Xml);
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
            using var flow = Wf.Running(nameof(RunPipes));
            var data = Wf.Polysource.Span<ushort>(2400);

            // var input = Pipes.pipe<ushort>();
            // var incount = Pipes.flow(data, input);
            // var output = Pipes.pipe<ushort>();
            // var outcount = Pipes.flow(input,output);

            //Wf.Ran(flow, $"Ran {incount} -> {outcount} values through pipe");
        }

        MemoryAddress GetKernel32Proc(string name = "CreateDirectoryA")
        {
            var flow = Running();
            using var kernel = NativeModules.kernel32();
            Write(kernel);

            var f = NativeModules.func<OS.Delegates.GetProcAddress>(kernel, nameof(OS.Delegates.GetProcAddress));
            Write(f);

            var address = (MemoryAddress)f.Invoke(kernel, name);
            Write(address);

            Ran(flow);

            return address;
        }

        static ReadOnlySpan<byte> JmpRaxCode
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
            var tc = JmpRaxCode;
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

        void FilterApiBlocks()
        {
            var blocks = Wf.ApiCatalogs().Correlate();
            var f1 = ApiCodeBlocks.filter(blocks,ApiClassKind.And);
            iter(f1,f => Wf.Row(f.Uri));
        }
    }
}
