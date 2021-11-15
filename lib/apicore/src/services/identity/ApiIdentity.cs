//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Collections.Generic;

    [ApiHost]
    public readonly partial struct ApiIdentity
    {
        /// <summary>
        /// Assigns identity to each value parameter (not to be confused with type parametricity) declared by a method
        /// </summary>
        /// <param name="src">The source method</param>
        static IEnumerable<string> ValueParamIdentities(MethodInfo src)
        {
            var args = src.GetParameters();
            var argtypes = src.ParameterTypes(true);
            for(var i=0; i<argtypes.Length; i++)
            {
                var argtext = parameter(args[i]);
                if(argtext.IsNotBlank())
                    yield return argtext;
            }
        }

        /// <summary>
        /// Assigns identity to each type argument supplied to close a generic method
        /// </summary>
        /// <param name="src">The constructed generic method</param>
        static IEnumerable<string> TypeArgIdentities(MethodInfo src)
            => src.GenericArguments().Select(arg => ApiIdentity.identify(arg).IdentityText);

        /// <summary>
        /// Assigns aggregate identity to the type argument sequence that closes a generic method
        /// </summary>
        /// <param name="src">The constructed generic method</param>
        static string TypeArgIdentity(MethodInfo src)
            => sequential(IDI.TypeArgsOpen, IDI.TypeArgsClose, IDI.ArgSep, TypeArgIdentities(src));

        /// <summary>
        /// Assigns aggregate identity to a method's value parameter sequence
        /// </summary>
        /// <param name="src">The source method</param>
        static string ValueParamIdentity(MethodInfo src)
            => sequential(IDI.ArgsOpen, IDI.ArgsClose, IDI.ArgSep, ValueParamIdentities(src));
    }
}