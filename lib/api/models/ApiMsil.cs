//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    [StructLayout(LayoutKind.Sequential)]
    public class ApiMsil
    {
        /// <summary>
        /// The assembly-relative method identifier
        /// </summary>
        public readonly CliToken Token;

        /// <summary>
        /// The operation identity
        /// </summary>
        public readonly Name Uri;

        /// <summary>
        /// The code's base address
        /// </summary>
        public readonly MemoryAddress BaseAddress;

        /// <summary>
        /// The Cli signature
        /// </summary>
        public readonly CliSig CliSig;

        /// <summary>
        /// The encoded cil
        /// </summary>
        public readonly BinaryCode CliCode;

        /// <summary>
        /// The method implementation attributes
        /// </summary>
        public readonly MethodImplAttributes ImplSpec;

        [MethodImpl(Inline)]
        public ApiMsil(CliToken token, MemoryAddress @base, OpUri uri, CliSig sig, BinaryCode data, MethodImplAttributes impl)
        {
            Token = token;
            BaseAddress = @base;
            Uri = uri.Format();
            CliCode = data;
            CliSig = sig;
            CliCode = data;
            ImplSpec = impl;
        }
    }
}