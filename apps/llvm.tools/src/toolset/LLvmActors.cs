//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using N = LlvmNames.Tools;

    public static class LLvmActors
    {
        public abstract class LlvmActor<T> : FS.Actor
            where T : LlvmActor<T>, new()
        {
            protected LlvmActor(string name)
                : base(name, FS.ObjectKind.File, FS.ObjectKind.File)
            {
                Id = new ToolId(name);
            }

            public ToolId Id {get;}

            public static implicit operator ToolId(LlvmActor<T> src)
                => src.Id;

        }

        public sealed class LLc : LlvmActor<LLc>
        {
            public LLc()
                : base(N.llc)
            {

            }
        }

        public sealed class LlvmMc : LlvmActor<LlvmMc>
        {
            public LlvmMc()
                : base(N.llvm_mc)
            {

            }
        }

        public sealed class Clang : LlvmActor<Clang>
        {
            public Clang()
                : base(N.clang)
            {

            }
        }

        public sealed class LlvmObjDump : LlvmActor<LlvmObjDump>
        {
            public LlvmObjDump()
                : base(N.llvm_objdump)
            {

            }
        }

        public sealed class LlvmConfig : LlvmActor<LlvmConfig>
        {
            public LlvmConfig()
                : base(N.llvm_config)
            {

            }
        }

        public sealed class LlvmReadObj : LlvmActor<LlvmReadObj>
        {
            public LlvmReadObj()
                : base(N.llvm_readobj)
            {

            }
        }

        public sealed class LlvmTableGen : LlvmActor<LlvmTableGen>
        {
            public LlvmTableGen()
                : base(N.llvm_tblgen)
            {

            }
        }
    }
}