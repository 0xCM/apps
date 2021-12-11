//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct CmdArg : ICmdArg
    {
        public uint Index {get;}

        public string Name {get;}

        public string Value {get;}

        [MethodImpl(Inline)]
        public CmdArg(string value)
        {
            Index = 0;
            Value = value;
            Name = EmptyString;
        }

        [MethodImpl(Inline)]
        public CmdArg(string name, string value)
        {
            Index = 0;
            Value = value;
            Name = name;
        }

        [MethodImpl(Inline)]
        public CmdArg(uint index, string value)
        {
            Index = index;
            Value = value;
            Name = EmptyString;
        }

        [MethodImpl(Inline)]
        public CmdArg(uint index, string name, string value)
        {
            Index = index;
            Value = value;
            Name = name;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => core.empty(Value);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => core.nonempty(Value);
        }

        public override string ToString()
            => Value ?? EmptyString;

        [MethodImpl(Inline)]
        public static implicit operator string(CmdArg arg)
            => arg.Value;

        [MethodImpl(Inline)]
        public static implicit operator CmdArg(string value)
            => new CmdArg(value);

        public static CmdArg Empty
            => new CmdArg(EmptyString);
    }
}