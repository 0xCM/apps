//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines an indexed/labeled sequence that forms a partition over som domain
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public class ValueClassifier : IClassifier
    {
        public readonly Label Name;

        readonly Index<Label> _ClassNames;

        readonly Index<LabeledValue<ulong>> _Values;

        readonly Index<Sym> _Symbols;

        readonly Index<ValueClass> _Classes;

        [MethodImpl(Inline)]
        public ValueClassifier(Label name, Label[] names, Sym[] symbols, LabeledValue<ulong>[] values, ValueClass[] classes)
        {
            Name = name;
            _Symbols = symbols;
            _ClassNames = names;
            _Values = values;
            _Classes = classes;
        }

        [MethodImpl(Inline)]
        internal ref Label SymName(uint index)
            => ref _ClassNames[index];

        [MethodImpl(Inline)]
        internal ref LabeledValue<ulong> Value(uint index)
            => ref _Values[index];

        [MethodImpl(Inline)]
        internal ref Sym Sym(uint index)
            => ref _Symbols[index];

        [MethodImpl(Inline)]
        internal ref ValueClass Class(uint index)
            => ref _Classes[index];

        public ref readonly ValueClass this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref _Classes[i];
        }

        public ref readonly ValueClass this[int i]
        {
            [MethodImpl(Inline)]
            get => ref _Classes[i];
        }

        public uint ClassCount
        {
            [MethodImpl(Inline)]
            get => _Classes.Count;
        }

        public ReadOnlySpan<Label> ClassNames
        {
            [MethodImpl(Inline)]
            get => _ClassNames.View;
        }

        public ReadOnlySpan<Sym> Symbols
        {
            [MethodImpl(Inline)]
            get => _Symbols.View;
        }

        public ReadOnlySpan<LabeledValue<ulong>> Values
        {
            [MethodImpl(Inline)]
            get => _Values.View;
        }

        public ReadOnlySpan<ValueClass> Classes
        {
            [MethodImpl(Inline)]
            get => _Classes.View;
        }

        Label IClassifier.Name
            => Name;
    }
}