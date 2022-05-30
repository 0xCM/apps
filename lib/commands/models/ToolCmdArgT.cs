//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct ToolCmdArg<T> : IToolCmdArg<T>
    {
        /// <summary>
        /// The argument's relative position
        /// </summary>
        public ushort Position {get;}

        /// <summary>
        /// The argument name
        /// </summary>
        public string Name {get;}

        /// <summary>
        /// The (required) argument value
        /// </summary>
        public T Value {get;}

        public ArgProtocol Protocol {get;}

        public bool IsFlag {get;}

        [MethodImpl(Inline)]
        public ToolCmdArg Untype()
            => new ToolCmdArg(Name, Value);

        [MethodImpl(Inline)]
        public ToolCmdArg(ushort pos, T value, bool flag = false)
        {
            Position = pos;
            Name = EmptyString;
            Value = value;
            Protocol = (ArgPrefix.Space, ArgQualifier.Space);
            IsFlag = flag;
        }

        [MethodImpl(Inline)]
        public ToolCmdArg(string name, T value, bool flag = false)
        {
            Position = 0;
            Name = name;
            Value = value;
            Protocol = (ArgPrefix.Space, ArgQualifier.Space);
            IsFlag = flag;
        }

        [MethodImpl(Inline)]
        public string Format()
            => string.Format(RP.Assign, Name, Value);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ToolCmdArg<T>((string name, T value) src)
            => new ToolCmdArg<T>(src.name, src.value);

        [MethodImpl(Inline)]
        public static implicit operator ToolCmdArg(ToolCmdArg<T> src)
            => new ToolCmdArg(src.Name, src.Value);
    }
}