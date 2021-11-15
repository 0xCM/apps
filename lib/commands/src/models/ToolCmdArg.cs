//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public struct ToolCmdArg : IToolCmdArg
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

        public ArgProtocol Protocol {get;}

        /// <summary>
        /// The argument classifier
        /// </summary>
        public ArgPartKind Classifier {get;}

        public bool IsFlag {get;}

        [MethodImpl(Inline)]
        public ToolCmdArg(ushort pos, string name, dynamic value, ArgPrefix prefix, bool flag = false)
        {
            Position = pos;
            Name = name;
            Value = value;
            Protocol = prefix;
            Classifier = ArgPartKind.Position | ArgPartKind.Prefix | ArgPartKind.Name | ArgPartKind.Value;
            IsFlag = flag;
        }

        [MethodImpl(Inline)]
        public ToolCmdArg(ushort pos, string name, dynamic value, ArgProtocol protocol, bool flag = false)
        {
            Position = pos;
            Name = name;
            Value = value;
            Protocol = protocol;
            Classifier = ArgPartKind.Position | ArgPartKind.Prefix | ArgPartKind.Name | ArgPartKind.Qualifier | ArgPartKind.Value;
            IsFlag = flag;
        }

        [MethodImpl(Inline)]
        public ToolCmdArg(string name, dynamic value, bool flag = false)
        {
            Position = 0;
            Name = name;
            Value = value;
            Protocol = (ArgPrefix.Space, ArgQualifier.Space);
            Classifier = ArgPartKind.Name | ArgPartKind.Value;
            IsFlag = flag;
        }


        [MethodImpl(Inline)]
        public ToolCmdArg(ushort pos, string name, dynamic value, bool flag = false)
        {
            Position = pos;
            Name = name;
            Value = value;
            Protocol = (ArgPrefix.Space, ArgQualifier.Space);
            Classifier = ArgPartKind.Position | ArgPartKind.Name | ArgPartKind.Value;
            IsFlag = flag;
        }


        [MethodImpl(Inline)]
        public ToolCmdArg(ushort pos, dynamic value, bool flag = false)
        {
            Position = pos;
            Name = EmptyString;
            Value = value;
            Protocol = (ArgPrefix.Space, ArgQualifier.Space);
            Classifier = ArgPartKind.Position | ArgPartKind.Value;
            IsFlag = flag;
        }

        public ArgPrefix Prefix => Protocol.Prefix;

        public ArgQualifier Qualifier => Protocol.Qualifier;

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
            => Cmd.format(this);

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