//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct SymClass
    {
        public string Name {get;}

        [MethodImpl(Inline)]
        public SymClass(string name)
        {
            Name = name;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => core.empty(Name);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => core.nonempty(Name);
        }

        public string Group
            => Symbols.symgroup(this);

        public string Kind
            => Symbols.symkind(this);

        public string Format()
            => Name ?? EmptyString;

        public override string ToString()
            => Format();

        public static SymClass Empty
        {
            [MethodImpl(Inline)]
            get => new SymClass(EmptyString);
        }
    }
}