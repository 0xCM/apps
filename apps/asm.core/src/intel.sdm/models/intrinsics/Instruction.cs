//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static XedModels;

    partial class IntelIntrinsicModels
    {
        public struct Instruction
        {
            public const string ElementName = "instruction";

            public string name;

            public string form;

            public IFormType xed;
        }
    }
}