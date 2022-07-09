//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct ToolCmdArg<T>
    {
        /// <summary>
        /// The argument's relative position
        /// </summary>
        public readonly int Position {get;}

        /// <summary>
        /// The argument name
        /// </summary>
        public readonly string Name {get;}

        /// <summary>
        /// The (required) argument value
        /// </summary>
        public readonly T Value {get;}

        public readonly ArgProtocol Protocol {get;}

        public readonly bool IsFlag {get;}

        [MethodImpl(Inline)]
        public ToolCmdArg Untype()
            => new ToolCmdArg(Name, Value);

        [MethodImpl(Inline)]
        public ToolCmdArg(int pos, T value, bool flag = false)
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
            Position = -1;
            Name = name;
            Value = value;
            Protocol = (ArgPrefix.Space, ArgQualifier.Space);
            IsFlag = flag;
        }

        [MethodImpl(Inline)]
        public string Format()
            => string.Format(RpOps.Assign, Name, Value);

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