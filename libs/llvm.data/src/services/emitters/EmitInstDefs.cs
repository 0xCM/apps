//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataEmitter
    {
        public void EmitInstDefs()
            => Emit(DataProvider.InstDefs());
    }
}