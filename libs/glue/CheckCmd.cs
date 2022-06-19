//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using static ApiGranules;

    public class ApiCmd : AppCmdService<ApiCmd>
    {
        ApiMd ApiMd => Wf.ApiMetadata();

        CliEmitter CliEmitter => Wf.CliEmitter();

        Heaps Heaps => Wf.Heaps();

        PdbIndexBuilder PdbIndexBuilder => Wf.PdbIndexBuilder();

        PdbSvc PdbSvc => Wf.PdbSvc();

        [CmdOp("api/etl")]
        void ApiEmit()
        {
            ApiMd.EmitDatasets();
        }

        [CmdOp("api/emit/pdb/info")]
        void EmitApiPdbInfo()
            => PdbSvc.EmitPdbDocInfo(PartId.AsmOperands);

        [CmdOp("api/emit/cli")]
        void EmitMetadataCli()
        {
            CliEmitter.Emit(CliEmitOptions.@default());
            ApiMd.EmitMsil();
        }

        [CmdOp("api/emit/pdb/index")]
        void IndexApiPdbFiles()
        {
            var dst = new PdbIndex();
            PdbIndexBuilder.IndexComponents(ApiMd.Components, dst);
        }

        [CmdOp("api/emit/heaps")]
        void ApiEmitHeaps()
            => Heaps.Emit(Heaps.symbols(ApiMd.SymLits));

        [CmdOp("api/emit/msil-host")]
        void EmitHostMsil(CmdArgs args)
            => ApiMd.EmitHostMsil(arg(args,0));

        [CmdOp("api/emit/msil")]
        void EmitMsil()
        {
            var targets = AppDb.ApiTargets(msil);
            targets.Delete();
            ApiMd.EmitMsil(ApiMd.ApiHosts, targets.Targets(il));
            TableEmit(Cil.opcodes(), AppDb.DbOut("clr").Path("cil.opcodes", FileKind.Csv));
        }

        [CmdOp("api/emit/index")]
        void EmitRuntimeMembers()
            => ApiMd.EmitIndex(ApiMd.CalcRuntimeMembers());

        [CmdOp("api/parts")]
        void Parts()
            => iter(ApiMd.Parts, part => Write(part.Name));

        [CmdOp("api/components")]
        void Components()
            => iter(ApiMd.Components, part => Write(part.GetSimpleName()));

        [CmdOp("api/emit/comments")]
        void ApiEmitComments()
            => ApiMd.EmitComments();


        [CmdOp("api/emit/pdb/methods/symbols")]
        void CollectComponentSymbols()
        {
            var components = ApiRuntimeCatalog.Components;
            var flow = Running(string.Format("Collecting method symbols for {0} assemblies", components.Length));
            var symbolic = Wf.SourceSymbolic();
            var collector = new MethodSymbolCollector();
            symbolic.SymbolizeMethods(components, collector.Deposit);
            var items = collector.Collected;
            var count = items.Length;
            Ran(flow, string.Format("Collected {0} method symbols", count));
            var dst = AppDb.ApiTargets().Path("api","methods", FileKind.Md);
            var emitting = EmittingFile(dst);
            using var writer = dst.Writer();
            for(var i=0; i<count; i++)
            {
                ref readonly var item = ref skip(items,i);
                var doc = item.Docs;
                var summary = doc != null ? doc.SummaryText.Trim() : EmptyString;
                if(nonempty(summary))
                    writer.WriteLine(string.Format("// {0}",summary));
                writer.WriteLine(item.Format());
            }
            EmittedFile(emitting, count);
        }

        [CmdOp("api/emit/pdb/types/symbols")]
        void CollectTypeSymbols()
        {
            var components = ApiMd.Components;
            var symbolic = Wf.SourceSymbolic();
            var dst = AppDb.ApiTargets().Path("api", "types", FileKind.Md);
            var emitting = EmittingFile(dst);
            var counter =0u;
            using var writer = dst.Writer();
            foreach(var component in components)
            {
                var symbols = symbolic.Symbolize(component);
                var items = symbols.Types;
                var count = items.Length;
                for(var i=0; i<count; i++)
                {
                    ref readonly var item =ref skip(items,i);
                    var doc = item.Docs;
                    var summary = doc != null ? doc.SummaryText.Trim() : EmptyString;
                    if(nonempty(summary))
                        writer.WriteLine(string.Format("// {0}",summary));
                    writer.WriteLine(item.Format());
                }
            }
        }

        [CmdOp("native/check")]
        Outcome CheckNativeTypes(CmdArgs args)
        {
            try
            {
                RunNativeChecks();
                return true;
            }
            catch(Exception e)
            {
                return e;
            }
        }

        void RunNativeChecks()
        {
            var t0 = NativeTypes.seg(NativeSegKind.Seg128x16i);
            Write(t0.Format());

            var t1 = NativeTypes.seg(NativeSegKind.Seg16u);
            Write(t1.Format());

            CheckNativeAlloc();
        }

        void CheckNativeAlloc()
        {
            var n = n16;
            var count = Numbers.count(n);
            byte length = (byte)n;
            var result = Outcome.Success;
            using var native = NativeCells.alloc<string>(count, out var id);
            var bits = PolyBits.bitstrings(n);
            for(var i=0u; i<count; i++)
            {
                var offset = i*n;
                native.Content(i) = new string(slice(bits, offset, n));
            }
        }

        [CmdOp("check/api/metadata")]
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

    }
}