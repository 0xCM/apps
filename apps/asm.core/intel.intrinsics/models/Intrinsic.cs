//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class IntelIntrinsics
    {
        public struct Intrinsic : IComparable<Intrinsic>
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

            public int CompareTo(Intrinsic src)
            {
                var result = CPUID.Format().CompareTo(src.CPUID.Format());
                if(result == 0)
                    result = name.CompareTo(src.name);
                return result;
            }

        }
    }
}