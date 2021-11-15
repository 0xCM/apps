//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;
    [Free]
    public interface IToolCmdArg : ITextual
    {
        /// <summary>
        /// The argument's relative position
        /// </summary>
        ushort Position {get;}

        /// <summary>
        /// Defines prefix characteristics and/or operand situation
        /// </summary>
        ArgProtocol Protocol {get;}

        /// <summary>
        /// The argument name, if any
        /// </summary>
        string Name {get;}

        /// <summary>
        /// The (required) argument value
        /// </summary>
        dynamic Value {get;}

        /// <summary>
        /// Specifies the extant argument components
        /// </summary>
        ArgPartKind Classifier {get;}

        /// <summary>
        /// The argument prefix, if any; typically either '-', '--', or '/'
        /// </summary>
        ArgPrefix Prefix => Protocol.Prefix;

        /// <summary>
        /// The delimiter between an argument name/value pair, typically '=' or ':' if present
        /// </summary>
        ArgQualifier Qualifier => Protocol.Qualifier;

        /// <summary>
        /// Specifies whether the argument is a flag and thus the name is the value and conversely
        /// </summary>
        bool IsFlag => false;

        string ITextual.Format()
            => Settings.format(Name, Value);
    }

    [Free]
    public interface IToolCmdArg<T> : IToolCmdArg
    {
        new T Value {get;}

        dynamic IToolCmdArg.Value
            => Value;
    }
}