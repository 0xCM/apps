//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Diagnostics.Tracing;

    using static Root;
    using static core;

    partial class App : AppService<App>
    {
        public App()
        {

        }

        protected override void OnInit()
        {

        }

        public static MsgPattern<T> DispatchingCmd<T>()
            where T : struct, ICmd<T> => "Dispatching {0}";

        public static MsgPattern<CmdId> DispatchingCmd() => "Dispatching {0}";

        public CmdResult Run(ICmd spec)
        {
            Wf.Status(DispatchingCmd().Format(spec.CmdId));
            return Wf.Router.Dispatch(spec);
        }

        public CmdResult Run<T>(T spec)
            where T : struct, ICmd<T>
        {
            Wf.Status(DispatchingCmd<T>().Format(spec));
            return Wf.Router.Dispatch(spec);
        }

        string CreateXedCase(string opcode)
        {
            var tool = Wf.XedTool();
            var dir = Db.CaseDir("asm.assembled", opcode);
            var dst = dir + FS.file(string.Format("{0}.{1}", opcode, tool.Id), FS.Cmd);
            var @case = tool.DefineCase(opcode.ToString(), dir);
            var content = tool.CreateScript(@case);
            return content;
        }

        void EmitRuntimeMembers()
        {
            var service = ApiRuntime.create(Wf);
            var members = service.EmitRuntimeIndex();
        }

        public void ProccessCultFiles()
        {
            Wf.CultProcessor().Process();
        }

        void JitApiCatalog()
        {
            Wf.ApiJit().JitCatalog();
        }

        void CaptureSelf()
        {
            Wf.CaptureRunner().Capture(Assembly.GetExecutingAssembly().Id());
        }

        void DescribeHeaps()
        {
            var components = Wf.ApiCatalog.Components.View;
            var heaps = CliHeaps.strings(components).View;
            var count = heaps.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var heap = ref skip(heaps,i);
                Wf.Row(CliHeaps.describe(heap));
            }
        }

        void ResolveApi(params PartId[] parts)
        {
            var resolver = Wf.ApiResolver();
            resolver.ResolveParts(parts);
        }

        void CheckHeap()
        {
            const string Seg0 = "This";
            const string Seg1 = "is";
            const string Seg2 = "a";
            const string Seg3 = "HeapString";
            const string segments = "This" + "is" + "a" + "HeapString";

            var s0 = (uint)Seg0.Length;
            var s1 = (uint)Seg1.Length;
            var s2 = (uint)Seg2.Length;
            var s3 = (uint)Seg3.Length;

            var offsets = array<uint>(
                0,
                s0,
                s0 + s1,
                s0 + s1 + s2
                );

            var heap = memory.heap(text.span(segments), offsets);
            for(var i=0u; i<offsets.Length; i++)
            {
                var seg = text.format(heap.Segment(i));
                Wf.Row(seg);
            }
        }

        void CorrelateApi()
        {
            var dst = Db.AppTablePath<ApiCorrelationEntry>();
            Wf.ApiCatalogs().Correlate(dst);
        }

        public void ParseDump()
        {
            using var clrmd = ClrMdSvc.create(Wf);
            clrmd.ParseDump();
        }

        // void EmitAsmAsssetCatalog()
        // {

        //     var catalogs = Wf.Assets();
        //     catalogs.EmitIndex(AsmData.Assets, Db.Root);
        // }

        void ShowMemory()
        {
            var info = WinMem.basic();
            var formatter = info.Formatter();
            Wf.Row(formatter.Format(info,RecordFormatKind.KeyValuePairs));
        }

        public SortedIndex<ApiCodeBlock> LoadApiBlocks()
        {
            return Wf.ApiHex().ReadBlocks();
        }

        void EmitDependencyGraph()
        {
            var svc = Wf.CliEmitter();
            var refs = svc.ReadAssemblyRefs();
            var dst = Db.AppLog("dependencies", FS.Dot);
            var flow = Wf.EmittingFile(dst);
            var count = refs.Length;
            var parts = Wf.ApiCatalog.ComponentNames.ToHashSet();
            using var writer = dst.Writer();
            writer.WriteLine("digraph dependencies{");
            writer.WriteLine(string.Format("label={0}", text.enquote("Assembly Dependencies")));
            for(var i=0; i<count; i++)
            {
                ref readonly var x = ref skip(refs,i);
                if(parts.Contains(x.Target.Name))
                {
                    var source = x.Source.Name.Replace(Chars.Dot, Chars.Underscore);
                    var target = x.Target.Name.Replace(Chars.Dot, Chars.Underscore);
                    var arrow = string.Format("{0}->{1}", source, target);
                    writer.WriteLine(arrow);
                }
            }
            writer.WriteLine("}");
            Wf.EmittedFile(flow, count);
        }

        void CalcRelativePaths()
        {
            var @base = Db.DbRoot();
            var files = Db.AsmCapturePaths();
            var links = Markdown.links(@base,files);
            iter(links, r=> Write(r.Format()));
        }

        void ParseDump2()
        {
            using var clrmd = ClrMdSvc.create(Wf);
            clrmd.ParseDump();
        }

        void GenSlnScript()
        {
            const string Pattern = "dotnet sln add {0}";
            var src = FS.dir(@"C:\Dev\z0");
            var dst = Db.AppLog("create-sln", FS.Cmd);
            var projects = src.Files(FS.CsProj, true);
            var flow = Wf.EmittingFile(dst);
            using var writer = dst.Writer();
            iter(projects,project => writer.WriteLine(string.Format(Pattern, project.Format(PathSeparator.BS))));
            Wf.EmittedFile(flow,projects.Length);
        }

        void ProcessInstructions()
        {
            var blocks = LoadApiBlocks().View;
            var clock = Time.counter(true);
            var traverser = Wf.ApiCodeBlockTraverser();
            var receiver  = new AsmReceiverModel(Wf,750000);
            traverser.Traverse(blocks, receiver);
            var duration = clock.Elapsed().Ms;
        }

        public void ParseDisassembly()
        {
            var src = FS.path(@"C:\Data\zdb\tools\dumpbin\output\xxhsum.exe.disasm.asm");
            var dir = Db.AppLogRoot();
            var processor = Wf.DumpBin().AsmProcessor();
            var dst = dir + FS.file("xxhsum", FS.Asm);
            processor.ParseDisassembly(src,dst);
        }

        void Dispatch(string cmd, CmdArgs args)
        {
            var commands = Wf.GlobalCommands();
            var result = commands.Dispatcher.Dispatch(cmd,args);
            if(result.Fail)
                Wf.Error(result.Message);
        }

        void Dispatch()
        {
            var input = Wf.Args;
            if(input.Length == 0)
            {
                Error("Command unspecified");
                return;
            }

            var cmd = input[0];
            if(input.Length == 1)
                Dispatch(cmd, CmdArgs.Empty);
            else
            {
                var values = slice(span(input),1);
                var count = values.Length;
                var args = alloc<CmdArg>(count);
                for(ushort i=0; i<count; i++)
                    seek(args,i) = Cmd.arg(i,skip(values,i));
                Dispatch(cmd, args);
            }
        }

        static void render(EventWrittenEventArgs src, ITextBuffer dst)
        {
            dst.AppendLine(src.EventName);
            dst.AppendLine(RP.PageBreak80);
            var count = src.Payload.Count;
            for (int i = 0; i<count; i++)
            {
                var name = string.Format("{0,-32}:",src.PayloadNames[i]);
                var payload = string.Format("{0}",src.Payload[i]);
                var message = string.Concat(name,payload);
                dst.AppendLine(message);
            }
        }

        static async void emit(EventWrittenEventArgs src, StreamWriter dst)
        {
            var buffer = text.buffer();
            render(src,buffer);
            await dst.WriteLineAsync(buffer.Emit());
        }

        void Capture()
        {
            using var dst = Db.AppLog("clr-events", FS.Log).Writer();
            void receive(in EventWrittenEventArgs src)
            {
                emit(src,dst);
            }

            using var listener = ClrEventListener.create(receive);
            var settings = ApiExtractSettings.init(Db.CapturePackRoot(), now());
            Wf.ApiExtractWorkflow().Run(settings);
        }

        public void Run()
        {
            Dispatch();
        }

        public static void Main(params string[] args)
        {
            try
            {
                var parts = ApiRuntimeLoader.parts(controller(), array<string>());
                using var wf = WfAppLoader.load(parts, args);
                var app = App.create(wf.WithSource(Rng.@default()));
                app.Run();

            }
            catch(Exception e)
            {
                term.error(e);
            }
        }
    }


    public static partial class XTend
    {

    }
}