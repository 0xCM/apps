//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;
    using Microsoft.CodeAnalysis;

    using static Root;
    using static core;
    using static Delegates;
    using static CodeSymbolModels;

    [ApiHost]
    public sealed class SourceSymbolic : AppService<SourceSymbolic>
    {
        public static MetadataReference metaref(FS.FilePath src)
        {
            var xml = src.ChangeExtension(FS.Xml);
            var doc = XmlDocProvider.create(xml);
            var props = default(MetadataReferenceProperties);
            return MetadataReference.CreateFromFile(src.Name, props, doc);
        }

        // public static MetadataReference metaref(Assembly src)
        // {
        //     var path = FS.path(src.Location);
        //     var xml = path.ChangeExtension(FS.Xml);
        //     var props = default(MetadataReferenceProperties);
        //     if(xml.Exists)
        //     {
        //         var doc = XmlDocProvider.create(xml);
        //         var reference = MetadataReference.CreateFromFile(path.Name, props, doc);
        //         return reference;
        //     }
        //     else
        //         return MetadataReference.CreateFromFile(path.Name, props);
        // }

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
        public static uint filter(ReadOnlySpan<CodeSymbol> src, SymbolKind kind, Span<CodeSymbol> dst)
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

        public CodeSymbolSet Symbolize(Assembly src)
        {
            var metadata = metaref(src);
            var dst = CodeSymbols.set(metadata);
            var name = string.Format("{0}.compilation",src.GetSimpleName());
            var comp = Roslyn.Compilation(name, metadata);
            var asymbol = comp.GetAssemblySymbol(metadata);
            dst.Replace(core.array(asymbol));
            var gns = asymbol.GlobalNamespace;
            var types = gns.GetTypes();
            Wf.Status(string.Format("Traversing {0} types", types.Length));
            dst.Replace(types);
            var allocation = span<CodeSymbol>(MemberCount(types));
            Wf.Status(string.Format("Traversing {0} type members", allocation.Length));
            IncludeMethods(types, allocation, ref dst);
            return dst;
        }

        public CodeSymbolSet Symbolize(PartId part)
        {
            if(Wf.ApiCatalog.FindComponent(part, out var assembly))
            {
                return Symbolize(assembly);
            }
            else
            {
                Wf.Error(string.Format("{0} not found", part.Format()));
                return CodeSymbolSet.Empty;
            }
        }

        public ReadOnlySpan<MethodSymbol> SymbolizeMethods(Assembly src)
        {
            var symbols = Symbolize(src);
            return symbols.Methods;
        }

        public ReadOnlySpan<MethodSymbol> SymbolizeMethods(PartId part)
        {
            if(Wf.ApiCatalog.FindComponent(part, out var assembly))
            {
                return SymbolizeMethods(assembly);
            }
            else
                return default;
        }

        public void SymbolizeMethods(ReadOnlySpan<Assembly> src, SpanReceiver<MethodSymbol> dst)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var a = ref skip(src,i);
                dst(SymbolizeMethods(a));
            }
        }

        Roslyn Roslyn;

        protected override void OnInit()
        {
            Roslyn = Wf.Roslyn();
        }

        [Op]
        void IncludeMethods(ReadOnlySpan<TypeSymbol> src, Span<CodeSymbol> buffer, ref CodeSymbolSet dst)
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
            dst.Replace(CodeSymbols.convert<MethodSymbol>(collected));
        }

        [MethodImpl(Inline),Op]
        static uint NonEmpty(ReadOnlySpan<CodeSymbol> src, Span<CodeSymbol> dst)
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

        public readonly struct SymbolKindFilter : IUnaryPred<SymbolKindFilter,CodeSymbol>
        {
            public SymbolKind Kind {get;}

            [MethodImpl(Inline), Op]
            public SymbolKindFilter(SymbolKind kind)
                => Kind = kind;

            [MethodImpl(Inline), Op]
            public bit Invoke(CodeSymbol a)
                => a.Kind == Kind;
        }

        public readonly struct MemberProducer : IReadOnlySpanFactory<MemberProducer, TypeSymbol, CodeSymbol>
        {
            [MethodImpl(Inline), Op]
            public ReadOnlySpan<CodeSymbol> Invoke(in TypeSymbol src)
                => src.GetMembers();
        }
    }
}