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
    public sealed class SourceSymbolic : AppService<SourceSymbolic>
    {
        Roslyn Roslyn;

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