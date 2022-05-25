//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Z0.Asm;

    partial class ApiExtractor
    {
        Index<AsmRoutine> EmitRoutines(ApiHostCode code)
        {
            var decoded = DecodeMembers(code);
            EmitAsmSource(code.Resolved.Host, decoded);
            return decoded;
        }
    }
}