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
    public class Classifier<T> : IClassifier
    {
        public Label Name {get;}

        internal Index<Label> _Partitions;

        internal Index<LabeledValue<T>> _Values;

        internal Index<Sym> _Symbols;

        internal Index<Class<T>> _Classes;

        [MethodImpl(Inline)]
        public Classifier(Label name, Label[] names, Sym[] symbols, LabeledValue<T>[] values, Class<T>[] classes)
        {
            Name = name;
            _Symbols = symbols;
            _Partitions = names;
            _Values = values;
            _Classes = classes;
        }

        public uint ClassCount
        {
            [MethodImpl(Inline)]
            get => _Classes.Count;
        }

        public ReadOnlySpan<Label> ClassNames
        {
            [MethodImpl(Inline)]
            get => _Partitions.View;
        }

        public ReadOnlySpan<Sym> Symbols
        {
            [MethodImpl(Inline)]
            get => _Symbols.View;
        }

        public ReadOnlySpan<LabeledValue<T>> Values
        {
            [MethodImpl(Inline)]
            get => _Values.View;
        }

        public ReadOnlySpan<Class<T>> Classes
        {
            [MethodImpl(Inline)]
            get => _Classes.View;
        }
    }
}