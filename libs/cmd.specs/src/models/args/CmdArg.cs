//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct CmdArg
    {
        public uint Index {get;}

        public NameOld Name {get;}

        public string Value {get;}

        [MethodImpl(Inline)]
        public CmdArg(string name)
        {
            Index = 0;
            Name = name;
            Value = name;
        }

        [MethodImpl(Inline)]
        public CmdArg(string name, string value)
        {
            Index = 0;
            Name = name;
            Value = value;
        }

        [MethodImpl(Inline)]
        public CmdArg(uint index, string name, string value)
        {
            Index = index;
            Name = name;
            Value = value;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsNonEmpty;
        }

        public override string ToString()
            => text.empty(Value) ? Name.Format() : string.Format("{0}={1}", Name, Value);

        [MethodImpl(Inline)]
        public static implicit operator string(CmdArg arg)
            => arg.Value;

        [MethodImpl(Inline)]
        public static implicit operator CmdArg(string name)
            => new CmdArg(name);

        public static CmdArg Empty
            => new CmdArg(EmptyString);
    }
}