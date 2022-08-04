//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public record struct ToolCmdArg<T> : IToolCmdArg<T>
    {
        /// <summary>
        /// The argument's relative position
        /// </summary>
        public readonly ushort Position {get;}

        /// <summary>
        /// The argument name
        /// </summary>
        public readonly string Name {get;}

        /// <summary>
        /// The (required) argument value
        /// </summary>
        public readonly T Value {get;}

        public readonly bool IsFlag {get;}

        [MethodImpl(Inline)]
        public ToolCmdArg(ushort pos, T value, bool flag = false)
        {
            Position = pos;
            Name = EmptyString;
            Value = value;
            IsFlag = flag;
        }

        [MethodImpl(Inline)]
        public ToolCmdArg(string name, T value, bool flag = false)
        {
            Position = ushort.MaxValue;
            Name = name;
            Value = value;
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
    }
}