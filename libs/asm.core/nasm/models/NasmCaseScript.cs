//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct NasmCaseScript
    {
        public NasmCase Case {get;}

        public FS.FilePath Path {get;}

        [MethodImpl(Inline)]
        public NasmCaseScript(NasmCase @case, FS.FilePath path)
        {
            Case = @case;
            Path = path;
        }
    }
}