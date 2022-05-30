//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a tool flag argument
    /// </summary>
    public readonly struct CmdArgDef
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
        public dynamic Value {get;}

        public ArgPartKind Classifier {get;}

        [MethodImpl(Inline)]
        public CmdArgDef(ushort pos, string name, ArgPrefix? prefix = null)
        {
            Position = pos;
            Name = name;
            Value = EmptyString;
            Classifier = ArgPartKind.Name | ArgPartKind.Position;
        }

        [MethodImpl(Inline)]
        public CmdArgDef(string name, ArgPrefix? prefix = null)
        {
            Position = 0;
            Name = name;
            Value = EmptyString;
            Classifier = ArgPartKind.Name;
        }

        public bool IsFlag
            => true;

        [MethodImpl(Inline)]
        public static implicit operator ToolCmdArg(CmdArgDef src)
            => new ToolCmdArg(src.Position, src.Name, src.Value, true);
    }
}