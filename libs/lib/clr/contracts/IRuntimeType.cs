//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    /// <summary>
    /// Characterizes a model of a CLR type during runtime
    /// </summary>
    [Free]
    public interface IRuntimeType : IRuntimeObject<Type>
    {
        /// <summary>
        /// Models of the types nested within the subject, if any
        /// </summary>
        IEnumerable<IRuntimeType> NestedTypes
            => core.stream<IRuntimeType>();

        CliToken IClrArtifact.Token
            => Definition.MetadataToken;
    }

    [Free]
    public interface IRuntimeType<T> : IRuntimeType
    {
        new IEnumerable<T> NestedTypes
            => core.stream<T>();

        IEnumerable<IRuntimeType> IRuntimeType.NestedTypes
            => NestedTypes.Cast<IRuntimeType>();
    }
}