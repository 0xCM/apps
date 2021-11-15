//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public struct CmdVar
    {
        public string Name {get;}

        string _Value;

        [MethodImpl(Inline)]
        public CmdVar(string name)
        {
            Name = name;
            _Value = EmptyString;
        }

        [MethodImpl(Inline)]
        public CmdVar(string id, string value)
        {
            Name = id;
            _Value = value;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => text.nonempty(Name);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => text.empty(Name);
        }

        public string Value
        {
            [MethodImpl(Inline)]
            get => _Value;
        }

        [MethodImpl(Inline)]
        public CmdVar Set(string value)
        {
            _Value = value;
            return this;
        }

        public bool Evaluated
            => IsNonEmpty && (text.index(_Value,'%') < 0 && text.index(_Value,'$') < 0);

        [MethodImpl(Inline)]
        public string Format()
            => _Value;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator CmdVar(string id)
            => new CmdVar(id);

        [MethodImpl(Inline)]
        public static implicit operator CmdVar((string id, string value) src)
            => new CmdVar(src.id, src.value);

        [MethodImpl(Inline)]
        public static implicit operator CmdVar(Pair<string> src)
            => new CmdVar(src.Left, src.Right);
    }
}