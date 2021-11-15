//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using static core;
    using static IntelIntrinsicModels;

    public class InstrinsicHostBuilder : AppService<InstrinsicHostBuilder>
    {
        public void EmitCsHosts(ReadOnlySpan<Intrinsic> src, FS.FolderPath dir)
        {
            var dst = dir + FS.file("intrinsics.cs", FS.Cs);
            var flow = Wf.EmittingFile(dst);
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                var spec = DefineFunction(skip(src,i));
            }
        }

        public FunctionSpec DefineFunction(in Intrinsic src)
        {
            var name = src.name;
            var operands = src.parameters;
            var count = operands.Count;
            for(var i=0; i<count; i++)
            {

            }

            return default;
        }

    }
}