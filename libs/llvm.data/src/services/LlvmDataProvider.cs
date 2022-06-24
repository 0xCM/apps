//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    public sealed partial class LlvmDataProvider : AppService<LlvmDataProvider>
    {
        public struct SvcState
        {
            public LlvmPaths LlvmPaths;

            public ConcurrentDictionary<string,object> DataSets;

            public Toolset Toolset;

            public LlvmTableLoader DataLoader;

            public LlvmDataCalcs DataCalcs;
        }

        SvcState State;

        public LlvmDataProvider()
        {
            State = new();
        }

        protected override void Initialized()
        {
            State.LlvmPaths = Wf.LlvmPaths();
            State.DataSets = new();
            State.Toolset = Wf.Toolset("llvm");
            State.DataLoader = Wf.LlvmTableLoader();
            State.DataCalcs = Wf.LlvmDataCalcs();
        }

        LlvmPaths LlvmPaths
        {
            [MethodImpl(Inline)]
            get => State.LlvmPaths;
        }

        LlvmTableLoader DataLoader
        {
            [MethodImpl(Inline)]
            get => State.DataLoader;
        }

        LlvmDataCalcs DataCalcs
        {
            [MethodImpl(Inline)]
            get => State.DataCalcs;
        }

        ConcurrentDictionary<string,object> DataSets
        {
            [MethodImpl(Inline)]
            get => State.DataSets;
        }

        Toolset Toolset
        {
            [MethodImpl(Inline)]
            get => State.Toolset;
        }
    }
}