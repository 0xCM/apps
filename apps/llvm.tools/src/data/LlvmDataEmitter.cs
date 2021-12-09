//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.IO;

    public partial class LlvmDataEmitter : AppService<LlvmDataEmitter>
    {
        LlvmPaths LlvmPaths;

        LlvmDataProvider DataProvider;

        protected override void Initialized()
        {
            LlvmPaths = Wf.LlvmPaths();
            DataProvider = Wf.LlvmDataProvider();
        }

        public uint EmitClassInfo(StreamWriter dst)
        {
            var map = DataProvider.SelectX86ClassMap();
            var count = map.IntervalCount;
            for(var i=0; i<count; i++)
                dst.WriteLine(map[i].Format());
            return count;
        }

        public uint EmitDefInfo(StreamWriter dst)
        {
            var map = DataProvider.SelectX86DefMap();
            var count = map.IntervalCount;
            for(var i=0; i<count; i++)
                dst.WriteLine(map[i].Format());
            return count;
        }
    }
}