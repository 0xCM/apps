//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    /// <summary>
    /// Characterizes a model of a CLR type during runtime
    /// </summary>
    [Free]
    public interface IClrRuntimeType : IClrRuntimeObject<Type>
    {
        /// <summary>
        /// Models of the types nested within the subject, if any
        /// </summary>
        IEnumerable<IClrRuntimeType> NestedTypes
            => core.stream<IClrRuntimeType>();

        CliToken IClrArtifact.Token
            => Definition.MetadataToken;
    }

    [Free]
    public interface IClrRuntimeType<T> : IClrRuntimeType
    {
        new IEnumerable<T> NestedTypes
            => core.stream<T>();

        IEnumerable<IClrRuntimeType> IClrRuntimeType.NestedTypes
            => NestedTypes.Cast<IClrRuntimeType>();
    }
}