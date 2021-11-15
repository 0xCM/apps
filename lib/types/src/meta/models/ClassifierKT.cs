//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines an indexed/labeled sequence that forms a partition over some domain
    /// </summary>
    public class Classifier<K,T> : IClassifier
        where K : unmanaged
    {
        public Label Name {get;}

        internal Index<Label> _ClassNames;

        internal Index<LabeledValue<T>> _Values;

        internal Index<Class<K,T>> _Classes;

        Index<K> _Kinds;

        Index<Sym<K>> _Symbols;

        [MethodImpl(Inline)]
        public Classifier(Label name, K[] kinds, Label[] names, Sym<K>[] symbols, LabeledValue<T>[] values, Class<K,T>[] classes)
        {
            Name = name;
            _Symbols = symbols;
            _ClassNames = names;
            _Values = values;
            _Kinds = kinds;
            _Classes = classes;
        }

        public uint ClassCount
        {
            [MethodImpl(Inline)]
            get => _Classes.Count;
        }

        public ReadOnlySpan<K> Kinds
        {
            [MethodImpl(Inline)]
            get => _Kinds.View;
        }

        public ReadOnlySpan<Label> ClassNames
        {
            [MethodImpl(Inline)]
            get => _ClassNames.View;
        }

        public ReadOnlySpan<Sym<K>> Symbols
        {
            [MethodImpl(Inline)]
            get => _Symbols.View;
        }

        public ReadOnlySpan<LabeledValue<T>> Values
        {
            [MethodImpl(Inline)]
            get => _Values.View;
        }

        public ReadOnlySpan<Class<K,T>> Classes
        {
            [MethodImpl(Inline)]
            get => _Classes.View;
        }
    }
}