//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class IntelIntrinsicModels
    {
        public struct Intrinsic
        {
            public const string ElementName = "intrinsic";

            public string tech;

            public string name;

            public string content;

            public InstructionTypes types;

            public CpuIdMembership CPUID;

            public Category category;

            public Return @return;

            public Parameters parameters;

            public Description description;

            public Operation operation;

            public Instructions instructions;

            public Header header;
        }
    }
}