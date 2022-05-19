//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct Classifiers
    {
        public static ClassChecks Checks(IWfRuntime wf) => ClassChecks.create(wf);

        public class ClassChecks : Checker<ClassChecks>
        {
            public Outcome CheckSymNames()
            {
                var result = Outcome.Success;
                var classifier = Classifiers.classifier<AsciLetterLoSym,byte>();
                var symbols = Symbols.index<AsciLetterLoSym>();
                var classes = classifier.Classes;
                var count = classes.Length;
                for(var i=0u; i<count; i++)
                {
                    ref readonly var c = ref skip(classes,i);
                    ref readonly var s = ref symbols[i];
                    Z0.Require.equal(c.Ordinal, i);
                    Z0.Require.equal(s.Key.Value, c.Ordinal);
                    Z0.Require.equal(s.Expr.Format(), c.Symbol.Format());
                    Z0.Require.equal(s.Name, c.Identifier.Format());
                }

                return result;
            }
        }

        const NumericKind Closure = UnsignedInts;

        public static ValueClassifier classifier(Type src)
            => (ValueClassifier)Lookup.GetOrAdd(src, _ => create(src));

        public static ValueClassifier<K,T> classifier<K,T>()
            where K : unmanaged, Enum
            where T : unmanaged
                => (ValueClassifier<K,T>)Lookup.GetOrAdd(typeof(K), _ => create<K,T>());

        [MethodImpl(Inline)]
        public static ValueClass<K,T> @class<K,T>(in ValueClassifier<K,T> @class, uint ordinal)
            where K : unmanaged
        {
            ref readonly var kv = ref skip(@class.Kinds, ordinal);
            ref readonly var lv = ref skip(@class.Values, ordinal);
            ref readonly var name = ref skip(@class.ClassNames, ordinal);
            ref readonly var s = ref skip(@class.Symbols,ordinal);
            return new ValueClass<K,T>(ordinal, @class.Name, name, s.Expr.Text, kv, lv.Value);
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ValueClass<T> @class<T>(in ValueClassifier<T> @class, uint ordinal)
        {
            ref readonly var lv = ref skip(@class.Values, ordinal);
            ref readonly var name = ref skip(@class.ClassNames, ordinal);
            ref readonly var s = ref skip(@class.Symbols,ordinal);
            return new ValueClass<T>(ordinal, @class.Name, name, s.Expr.Text, lv.Value);
        }

        [MethodImpl(Inline)]
        public static ValueClass @class(in ValueClassifier @class, uint ordinal)
        {
            ref readonly var lv = ref skip(@class.Values, ordinal);
            ref readonly var name = ref skip(@class.ClassNames, ordinal);
            ref readonly var s = ref skip(@class.Symbols,ordinal);
            return new ValueClass(ordinal, @class.Name, name, s.Expr.Text, lv.Value);
        }

        [Op, Closures(Closure)]
        public static ValueClassifier untype<T>(in ValueClassifier<T> src)
            where T : unmanaged
        {
            return new ValueClassifier(src.Name,
                src._Partitions,
                src._Symbols,
                src.Values.MapArray(x => new LabeledValue<ulong>(x.Label, core.bw64(x.Value.Content))),
                src.Classes.MapArray(c => untype(c)));
        }

        [MethodImpl(Inline)]
        public static ValueClass untype<T>(in ValueClass<T> src)
            where T : unmanaged
                => new ValueClass(src.Ordinal, src.ClassName, src.Identifier, src.Symbol, bw64(src.Value));

        public static ValueClassifier<T> unkind<K,T>(in ValueClassifier<K,T> src)
            where K : unmanaged
            where T : unmanaged
                => new ValueClassifier<T>(
                    src.Name,
                    src._ClassNames,
                    src.Symbols.MapArray(unkind),
                    src._Values,
                    src.Classes.MapArray(c => unkind(c))
                    );

        [MethodImpl(Inline)]
        public static ValueClass<T> unkind<K,T>(in ValueClass<K,T> src)
            where K : unmanaged
                => new ValueClass<T>(src.Ordinal, src.ClassName, src.Identifier, src.Symbol, src.Value);

        [MethodImpl(Inline)]
        static Sym unkind<K>(Sym<K> src)
            where K : unmanaged
                => src;

        static ConcurrentDictionary<Type,IClassifier> Lookup;

        static Classifiers()
        {
            Lookup = new();
        }

        static ValueClassifier create(Type src)
        {
            var symbols = Symbols.untyped(src);
            var count = symbols.Count;
            var names = alloc<Label>(count);
            var values = alloc<LabeledValue<ulong>>(count);
            var classes = alloc<ValueClass>(count);
            var dst = new ValueClassifier(src.Name, names, symbols, values, classes);
            for(var i=0u; i<symbols.Count; i++)
            {
                ref readonly var sym = ref symbols[i];
                dst.Sym(i) = sym;
                dst.SymName(i) = sym.Name;
                dst.Value(i) = (sym.Name,sym.Value);
                dst.Class(i) = new ValueClass(sym.Key, sym.Class.Name, sym.Name, sym.Expr.Text, sym.Value);
            }
            return dst;
        }
         static ValueClassifier<K,T> create<K,T>()
            where K : unmanaged, Enum
            where T : unmanaged
        {
            Label name = typeof(K).Name;
            var index = Symbols.index<K>();
            var names = Symbols.names<K>();
            var kinds = index.Kinds.ToArray();
            var symbols = index.View.ToArray();
            var values = Symbols.values<K,T>();
            var count = index.Count;
            var classes = alloc<ValueClass<K,T>>(count);
            for(var i=0u; i<count; i++)
                seek(classes,i) = new ValueClass<K,T>(i, name, names[i], skip(symbols,i).Expr.Text, skip(kinds,i), values[i].Value);
            return new ValueClassifier<K,T>(name, kinds, names, symbols, values, classes);
        }
    }
}