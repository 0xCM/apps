//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Collections.Concurrent;
    using System.Runtime.CompilerServices;

    using static core;
    using static Root;

    public sealed partial class LlvmDataProvider : GlobalService<LlvmDataProvider,LlvmDataProvider.DataProviderState>
    {
        public struct DataProviderState
        {
            public LlvmPaths LlvmPaths;

            public ConcurrentDictionary<string,object> DataSets;

            public LlvmToolset Toolset;

            public LlvmTableLoader DataLoader;

            public LlvmDataCalcs DataCalcs;
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

        LlvmToolset Toolset
        {
            [MethodImpl(Inline)]
            get => State.Toolset;
        }

        protected override LlvmDataProvider Init(out DataProviderState state)
        {
            state.LlvmPaths = Wf.LlvmPaths();
            state.DataSets = new();
            state.Toolset = Wf.LLvmToolset();
            state.DataLoader = Wf.LlvmTableLoader();
            state.DataCalcs = Wf.LlvmDataCalcs();
            return this;
        }
    }
}