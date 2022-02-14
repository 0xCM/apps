//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static Root;
    using static core;

    partial class LlvmCmdProvider
    {
        [CmdOp("llvm/defs/procs/features")]
        Outcome Processors(CmdArgs args)
        {
            var src = DataProvider.SelectEntities(e => e.IsProcessor()).Select(e => e.ToProcessor());
            var count = src.Count;
            var dst = list<ProcessorFeature>();
            var counter = 0u;
            for(var i=0u; i<count; i++)
            {
                ref readonly var p = ref src[i];

                var features = p.Features;
                var fcount = features.Count;
                for(var j=0; j<fcount; j++)
                {
                    var feature = new ProcessorFeature();
                    feature.Seq = counter++;
                    feature.Processor = p.Name;
                    feature.FeatureName = features[j];
                    dst.Add(feature);
                }
            }

            DataEmitter.EmitQueryTable("llvm/defs/procs/features", EmptyString,dst.ViewDeposited());

            return true;
        }
    }
}
