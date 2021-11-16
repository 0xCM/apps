//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public readonly struct Classifiers
    {
        const NumericKind Closure = UnsignedInts;

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
                => new ValueClass(src.Ordinal, src.ClassName, src.KindName, src.Symbol, bw64(src.Value));

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
                => new ValueClass<T>(src.Ordinal, src.ClassName, src.KindName, src.Symbol, src.Value);

        public static ValueClassifier<K,T> classifier<K,T>()
            where K : unmanaged, Enum
            where T : unmanaged
                => ClassCache.classifier<K,T>();

        [MethodImpl(Inline)]
        static Sym unkind<K>(Sym<K> src)
            where K : unmanaged
                => src;
    }

}