//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [LiteralProvider]
    public readonly struct AsmRenderPatterns
    {
        public const string InstInfoPattern = "{0} | {1,-3} | {2,-32} | ({3}) = {4}";

        public const string AsmFormPattern = "({0}) = {1}";
    }
}