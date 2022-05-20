//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class IntrinsicsDoc
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