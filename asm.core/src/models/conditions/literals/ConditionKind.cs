//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct ConditionCodes
    {
        public enum ConditionKind : byte
        {
            None,

            Code,

            CodeAlt,

            Jcc8,

            Jcc8Alt,

            Jcc32,

            Jcc32Alt,
        }
    }
}