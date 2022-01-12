//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using CC = System.Runtime.InteropServices.CallingConvention;

    partial struct Root
    {
        /// <summary>
        /// Canonical return value for search operation that returns a nonnegative value upon success
        /// </summary>
        public const int NotFound = -1;

        [MethodImpl(Inline)]
        public static bool found(int i)
            => i != NotFound;

        [MethodImpl(Inline)]
        public static int foundnot(int i, int alt)
            => found(i) ? i : alt;

        /// <summary>
        /// Indicates that emitted content should overwrite whatever file content may exist
        /// </summary>
        public const FileWriteMode Overwrite = FileWriteMode.Overwrite;

        /// <summary>
        /// The number of bytes in a page of memory
        /// </summary>
        public const ushort PageSize = 0x1000;

        public const MethodImplOptions Inline = MethodImplOptions.AggressiveInlining;

        public const MethodImplOptions NotInline = MethodImplOptions.NoInlining;

        public const char ListDelimiter = Chars.Comma;

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
        /// Specifies the <see cref='CC.ThisCall'/> calling convention where first argument is <see cref='this'/>
        /// and is placed in ECX/RCX
        /// </summary>
        public const CC ThisCall = CC.ThisCall;

        const string TestSuffix = ".test";

        const string SvcSuffix = ".svc";

        const string BaseSuffix = "";

        public const string EmptyString = "";
    }
}