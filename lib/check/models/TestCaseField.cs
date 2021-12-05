//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public enum TestCaseField : uint
    {
        CaseName = 0 | (60 << 16),

        Passed =  1 | (14 << 16),

        Duration = 2  | (14 << 16),

        Started =  3 | (26 << 16),

        Finished =  4 | (26 << 16),

        Message = 5 | (32 << 16)
    }
}