//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using N = LlvmNames.Tools;

    public abstract class ToolActor<A> : Actor<A>
        where A : ToolActor<A>,new()
    {
        protected ToolActor(string name)
            : base(name)
        {
            ToolId = name;
        }

        public ToolId ToolId {get;}

        public static implicit operator ToolId(ToolActor<A> src)
            => src.ToolId;
    }

    public static class LLvmActors
    {
        public sealed class Llc : ToolActor<Llc>
        {
            public Llc()
                : base(N.llc)
            {

            }
        }

        public sealed class LlvmMc : ToolActor<LlvmMc>
        {
            public LlvmMc()
                : base(N.llvm_mc)
            {

            }
        }

        public sealed class Clang : ToolActor<Clang>
        {
            public Clang()
                : base(N.clang)
            {

            }
        }

        public sealed class LlvmObjDump : ToolActor<LlvmObjDump>
        {
            public LlvmObjDump()
                : base(N.llvm_objdump)
            {

            }
        }

        public sealed class LlvmConfig : ToolActor<LlvmConfig>
        {
            public LlvmConfig()
                : base(N.llvm_config)
            {

            }
        }

        public sealed class LlvmReadObj : ToolActor<LlvmReadObj>
        {
            public LlvmReadObj()
                : base(N.llvm_readobj)
            {

            }
        }

        public sealed class LlvmAs : ToolActor<LlvmAs>
        {
            public LlvmAs()
                : base(N.llvm_as)
            {

            }
        }

        public sealed class LlvmTableGen : ToolActor<LlvmTableGen>
        {
            public LlvmTableGen()
                : base(N.llvm_tblgen)
            {

            }
        }
    }
}