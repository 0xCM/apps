//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines a tool flag argument
    /// </summary>
    public readonly struct CmdArgDef<T>
    {
        /// <summary>
        /// The argument's relative position
        /// </summary>
        public ushort Position {get;}

        /// <summary>
        /// The flag name
        /// </summary>
        public string Name {get;}

        /// <summary>
        /// The argument value
        /// </summary>
        public T Value {get;}

        public ArgProtocol Protocol {get;}

        public ArgPartKind Classifier {get;}

        [MethodImpl(Inline)]
        public CmdArgDef(ushort pos, string name, T value, ArgPrefix? prefix = null)
        {
            Position = pos;
            Name = name;
            Value = value;
            Protocol = prefix ?? ArgPrefix.DoubleDash;
            Classifier = ArgPartKind.Name | ArgPartKind.Position;
        }

        [MethodImpl(Inline)]
        public CmdArgDef(string name, T value, ArgPrefix? prefix = null)
        {
            Position = 0;
            Name = name;
            Value = value;
            Protocol = prefix ?? ArgPrefix.DoubleDash;
            Classifier = ArgPartKind.Name;
        }

        [MethodImpl(Inline)]
        public CmdArgDef(T value, ArgPrefix? prefix = null)
        {
            Position = 0;
            Name = value.ToString();
            Value = value;
            Protocol = prefix ?? ArgPrefix.DoubleDash;
            Classifier = ArgPartKind.Name;
        }

        public bool IsFlag => true;

        public ArgPrefix Prefix => Protocol.Prefix;

        public ArgQualifier Qualifier => Protocol.Qualifier;

        [MethodImpl(Inline)]
        public static implicit operator CmdArgDef(CmdArgDef<T> src)
            => new CmdArgDef(src.Position, src.Name, src.Prefix);

        [MethodImpl(Inline)]
        public static implicit operator ToolCmdArg(CmdArgDef<T> src)
            => new ToolCmdArg(src.Position, src.Name, src.Value, src.Prefix, true);
    }
}