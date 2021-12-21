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
        public Name Name {get;}

        string _Value;

        [MethodImpl(Inline)]
        public CmdVar(string name)
        {
            Name = name;
            _Value = EmptyString;
        }

        [MethodImpl(Inline)]
        public CmdVar(string name, string value)
        {
            Name = name;
            _Value = value;
        }

        public string Value
        {
            [MethodImpl(Inline)]
            get => _Value ?? EmptyString;
        }

        [MethodImpl(Inline)]
        public CmdVar Set(string value)
        {
            _Value = value ?? EmptyString;
            return this;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => text.nonempty(Value);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => text.empty(Value);
        }

        public bool Evaluated
            => IsNonEmpty && (text.index(Value,'%') < 0 && text.index(Value,'$') < 0);

        [MethodImpl(Inline)]
        public string Format()
            => Value;

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

        public static CmdVar Empty => new CmdVar(EmptyString);
    }
}