//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
global using System;
global using System.Collections.Generic;
global using System.Collections.Concurrent;
global using System.Collections;
global using System.IO;
global using System.Diagnostics;

global using System.Reflection;
global using System.Reflection.Metadata;
global using System.Runtime.Intrinsics;
global using System.Runtime.CompilerServices;
global using System.Runtime.InteropServices;

global using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;
global using CallerName = System.Runtime.CompilerServices.CallerMemberNameAttribute;
global using CallerFile = System.Runtime.CompilerServices.CallerFilePathAttribute;
global using CallerLine = System.Runtime.CompilerServices.CallerLineNumberAttribute;

global using static Z0.LiteralGroups;
global using static Z0.NumericBaseKind;
global using static Root;

global using NBK = Z0.NumericBaseKind;

global using CC = System.Runtime.InteropServices.CallingConvention;

[assembly: PartId(PartId.Interop)]

class Root
{
    public const string EmptyString = "";

    /// <summary>
    /// Specifies the <see cref='CC.StdCall'/> calling convention where the
    /// callee is responsible for stack management
    /// </summary>
    /// <remarks>
    /// This is the default PInvoke convention
    /// </remarks>
    public const CC StdCall = CC.StdCall;

    /// <summary>
    /// Specifies the <see cref='CC.Cdecl'/> calling convention where the caller
    /// is responsible for stack management
    /// </summary>
    /// <remarks>
    /// According to the runtime documentation, "This enables calling functions with varargs, which
    /// makes it appropriate to use for methods that accept a variable number of parameters,
    /// such as Printf".
    /// </remarks>
    public const CC Cdecl = CC.Cdecl;

    /// <summary>
    /// Specifies the <see cref='CC.ThisCall'/> calling convention where first argument is <see cref='this'/> and is placed in ECX/RCX
    /// </summary>
    public const CC ThisCall = CC.ThisCall;

    public const string windows = nameof(windows);

    public const string coff = nameof(coff);

    public const string images = nameof(images);
}