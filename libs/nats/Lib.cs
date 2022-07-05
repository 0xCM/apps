global using System;
global using System.Collections.Generic;
global using System.Collections.Concurrent;
global using System.Collections;

global using System.Reflection;
global using System.Reflection.Metadata;
global using System.Runtime.Intrinsics;
global using System.Runtime.CompilerServices;
global using System.Runtime.InteropServices;

global using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;
global using CallerName = System.Runtime.CompilerServices.CallerMemberNameAttribute;
global using CallerFile = System.Runtime.CompilerServices.CallerFilePathAttribute;
global using CallerLine = System.Runtime.CompilerServices.CallerLineNumberAttribute;

global using static Root;
using NK = Z0.NumericKind;
using Z0;

[assembly: PartId(PartId.Nats)]

class Root
{

    public const string EmptyString = "";


        public static NotSupportedException no<T>()
            => new NotSupportedException($"The type {typeof(T).Name} is not supported");

        /// <summary>
        /// Specifies unsigned integral types of widths <see cref='NumericWidths'/>
        /// </summary>
        public const NK UnsignedInts = NK.UnsignedInts;

        /// <summary>
        /// Specifies signed integral types of widths <see cref='NumericWidths'/>
        /// </summary>
        public const NK SignedInts = NK.SignedInts;

        /// <summary>
        /// Specifies signed and unsigned integral types of widths <see cref='NumericWidths'/>
        /// </summary>
        public const NK Integers = NK.Integers;

        /// <summary>
        /// Specifies floating-point primitive kinds
        /// </summary>
        public const NK Floats = NK.Floats;

        /// <summary>
        /// Specifies all numeric primitive kinds
        /// </summary>
        public const NK AllNumeric = NK.All;

        public const MethodImplOptions Inline = MethodImplOptions.AggressiveInlining;

}

namespace Z0
{
    public static partial class XTend
    {


    }
}