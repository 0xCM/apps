//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static Pow2x32;

    public partial class DumpBin
    {
        public enum CmdId : byte
        {
            None = 0,

            [Symbol("rawdata")]
            EmitRawData,

            [Symbol("loadconfig")]
            EmitLoadConfig,

            [Symbol("relocations")]
            EmitRelocations,

            [Symbol("exports")]
            EmitExports,

            [Symbol("disasm")]
            EmitAsm,

            [Symbol("headers")]
            EmitHeaders,
        }

        [Flags]
        public enum Flag : ulong
        {
            ARCHIVEMEMBERS = P2ᐞ00,

            CLRHEADER = P2ᐞ01,

            DEPENDENTS = P2ᐞ02,

            DIRECTIVES = P2ᐞ03,

            DISASM = P2ᐞ04,

            EXPORTS = P2ᐞ05,

            FPO = P2ᐞ06,

            HEADERS = P2ᐞ07,

            IMPORTS = P2ᐞ08,

            LINENUMBERS = P2ᐞ09,

            LINKERMEMBER = P2ᐞ10,

            LOADCONFIG = P2ᐞ11,

            RAWDATA = P2ᐞ12,

            RELOCATIONS = P2ᐞ13,

            SUMMARY = P2ᐞ14,

            SYMBOLS = P2ᐞ15,

            TLS = P2ᐞ16,

            OUT = P2ᐞ17,

            NOBYTES = P2ᐞ18,
        }

        public readonly struct Options
        {

        }
    }
}