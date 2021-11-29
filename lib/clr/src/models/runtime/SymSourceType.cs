//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct SymSourceType
    {
        readonly public Type Definition;

        readonly Index<string> _Alias;

        public string SymKind {get;}

        [MethodImpl(Inline)]
        internal SymSourceType(Type def, string kind, string[] alias)
        {
            Definition = def;
            SymKind = kind;
            _Alias = alias;
        }

        [MethodImpl(Inline)]
        internal SymSourceType(Type def, string kind)
        {
            Definition = def;
            SymKind = kind;
            _Alias = sys.empty<string>();
        }

        public string Name
        {
            [MethodImpl(Inline)]
            get => Definition.Name;
        }

        public ReadOnlySpan<string> Alias
        {
            [MethodImpl(Inline)]
            get => _Alias.View;
        }
    }
}