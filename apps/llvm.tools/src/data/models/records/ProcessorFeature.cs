//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    [Record(TableId)]
    public struct ProcessorFeature
    {
        public const string TableId= "llvm.processor.feature";

        public uint Seq;

        public string Processor;

        public string FeatureName;
    }
}
