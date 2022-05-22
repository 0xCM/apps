//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.IO;

    partial class LlvmDataEmitter
    {
        public uint EmitClassMap(StreamWriter dst)
        {
            var map = DataProvider.X86ClassMap();
            var count = map.IntervalCount;
            for(var i=0; i<count; i++)
                dst.WriteLine(map[i].Format());
            return count;
        }
    }
}