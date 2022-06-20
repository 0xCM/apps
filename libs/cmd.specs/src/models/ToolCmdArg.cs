//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ToolCmdArg : IToolCmdArg
    {
        /// <summary>
        /// The argument's relative position
        /// </summary>
        public ushort Position {get;}

        /// <summary>
        /// The argument name, if any
        /// </summary>
        public string Name {get;}

        /// <summary>
        /// The argument value
        /// </summary>
        public dynamic Value {get;}

        public bool IsFlag {get;}

        [MethodImpl(Inline)]
        public ToolCmdArg(ushort pos, string name, dynamic value, bool flag = false)
        {
            Position = pos;
            Name = name;
            Value = value;
            IsFlag = flag;
        }

        [MethodImpl(Inline)]
        public ToolCmdArg(string name, dynamic value, bool flag = false)
        {
            Position = 0;
            Name = name;
            Value = value;
            IsFlag = flag;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => core.empty(Value);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !core.empty(Value);
        }

        [MethodImpl(Inline)]
        public string Format()
            => string.Format(RP.Assign, Name, Value);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ToolCmdArg(Pair<string> src)
            => new ToolCmdArg(src.Left, src.Right);

        [MethodImpl(Inline)]
        public static implicit operator ToolCmdArg((string name, string value) src)
            => new ToolCmdArg(src.name, src.value);

        public static ToolCmdArg Empty
        {
            [MethodImpl(Inline)]
            get => new ToolCmdArg(EmptyString, EmptyString);
        }
    }
}