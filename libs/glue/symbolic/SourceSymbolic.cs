//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static Delegates;
    using static CaSymbolModels;

    [ApiHost]
    public sealed class SourceSymbolic : AppCmdService<SourceSymbolic>
    {
        ApiMd ApiMd => Wf.ApiMetadata();

        Roslyn Roslyn;

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

        protected override void OnInit()
        {
            Roslyn = Wf.Roslyn();
        }

        public static MetadataReference metaref(FS.FilePath src)
        {
            var xml = src.ChangeExtension(FS.Xml);
            var doc = XmlDocProvider.create(xml);
            var props = default(MetadataReferenceProperties);
            return MetadataReference.CreateFromFile(src.Name, props, doc);
        }

        public static MetadataReference metaref(Assembly src)
        {
            var path = FS.path(src.Location);
            var xml = path.ChangeExtension(FS.Xml);
            var props = default(MetadataReferenceProperties);
            if(xml.Exists)
            {
                var doc = XmlDocProvider.create(xml);
                var reference = MetadataReference.CreateFromFile(path.Name, props, doc);
                return reference;
            }
            else
                return MetadataReference.CreateFromFile(path.Name, props);
        }

        public static Index<MetadataReference> metarefs(ReadOnlySpan<FS.FilePath> src)
        {
            var count = src.Length;
            var dst = alloc<MetadataReference>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = metaref(skip(src,i));
            return dst;
        }

        /// <summary>
        /// Computes the total number of members that can be obtained from specified source elements
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static uint MemberCount(ReadOnlySpan<TypeSymbol> src)
        {
            var count = src.Length;
            var total = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var symbol = ref skip(src,i);
                if(symbol.IsNonEmpty)
                {
                    var members = symbol.GetMembers();
                    total += (uint)members.Length;
                }
            }
            return total;
        }

        [MethodImpl(Inline), Op]
        public static SymbolKindFilter filter(SymbolKind kind)
            => new SymbolKindFilter(kind);

        [MethodImpl(Inline), Op]
        public static uint filter(ReadOnlySpan<CaSymbol> src, SymbolKind kind, Span<CaSymbol> dst)
            => gcalc.filter(src, filter(kind), dst);

        [MethodImpl(Inline), Op]
        public static MemberProducer producer()
            => new MemberProducer();

        [MethodImpl(Inline), Op]
        public static SymbolicAssembly join(Assembly src, AssemblySymbol sym)
            => (src,sym);

        [MethodImpl(Inline), Op]
        public static SymbolicMethod join(MethodInfo src, MethodSymbol sym)
            => (src,sym);

        [MethodImpl(Inline), Op]
        public static SymbolicType join(Type src, TypeSymbol sym)
            => (src,sym);

        public CaSymbolSet Symbolize(Assembly src)
        {
            var metadata = metaref(src);
            var dst = CaSymbols.set(metadata);
            var name = string.Format("{0}.compilation",src.GetSimpleName());
            var comp = Roslyn.Compilation(name, metadata);
            var asymbol = comp.GetAssemblySymbol(metadata);
            dst.Assemblies = core.array(asymbol);
            var gns = asymbol.GlobalNamespace;
            var types = gns.GetTypes();
            Wf.Status(string.Format("Traversing {0} types", types.Length));
            dst.Types = types;
            var allocation = span<CaSymbol>(MemberCount(types));
            Wf.Status(string.Format("Traversing {0} type members", allocation.Length));
            IncludeMethods(types, allocation, ref dst);
            return dst;
        }

        public CaSymbolSet Symbolize(PartId part)
        {
            if(Wf.ApiCatalog.FindComponent(part, out var assembly))
                return Symbolize(assembly);
            else
            {
                Wf.Error(string.Format("{0} not found", part.Format()));
                return CaSymbolSet.Empty;
            }
        }

        public ReadOnlySpan<MethodSymbol> SymbolizeMethods(Assembly src)
            => Symbolize(src).Methods;

        public ReadOnlySpan<MethodSymbol> SymbolizeMethods(PartId part)
        {
            if(Wf.ApiCatalog.FindComponent(part, out var assembly))
                return SymbolizeMethods(assembly);
            else
                return default;
        }

        public void SymbolizeMethods(ReadOnlySpan<Assembly> src, SpanReceiver<MethodSymbol> dst)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
                dst(SymbolizeMethods(skip(src,i)));
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

        [Op]
        void IncludeMethods(ReadOnlySpan<TypeSymbol> src, Span<CaSymbol> buffer, ref CaSymbolSet dst)
        {
            var kIn = src.Length;
            var target = buffer;
            var offset = 0u;
            for(var i=0; i<kIn; i++)
            {
                var members = skip(src,i).GetMembers();
                var count = filter(members, SymbolKind.Method, target);
                target = slice(buffer, offset, count);
                offset += count;
            }

            var collected = slice(buffer, 0, offset);
            var kNonEmpty = NonEmpty(collected, collected);
            collected = slice(buffer, 0, kNonEmpty);

            Wf.Status(string.Format("Collected {0} methods", collected.Length));
            dst.Methods = CaSymbols.convert<MethodSymbol>(collected);
        }

        [MethodImpl(Inline),Op]
        static uint NonEmpty(ReadOnlySpan<CaSymbol> src, Span<CaSymbol> dst)
        {
            var counter = 0u;
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var symbol = ref skip(src,i);
                if(symbol.IsNonEmpty)
                    seek(dst,counter++) = symbol;
            }
            return counter;
        }

        public readonly struct SymbolKindFilter : IUnaryPred<SymbolKindFilter,CaSymbol>
        {
            public SymbolKind Kind {get;}

            [MethodImpl(Inline), Op]
            public SymbolKindFilter(SymbolKind kind)
                => Kind = kind;

            [MethodImpl(Inline), Op]
            public bit Invoke(CaSymbol a)
                => a.Kind == Kind;
        }

        public readonly struct MemberProducer : IReadOnlySpanFactory<MemberProducer, TypeSymbol, CaSymbol>
        {
            [MethodImpl(Inline), Op]
            public ReadOnlySpan<CaSymbol> Invoke(in TypeSymbol src)
                => src.GetMembers();
        }
    }
}