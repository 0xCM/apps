//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Svc = Z0;

    public static partial class XSvc
    {
        public static ApiExtractor ApiExtractor(this IWfRuntime wf)
            => Z0.ApiExtractor.create(wf);

        public static SegmentTraverser SegmentTraverser(this IWfRuntime wf)
            => Svc.SegmentTraverser.create(wf);

        public static ApiSegmentLocator ApiSegmentLocator(this IWfRuntime wf)
            => Svc.ApiSegmentLocator.create(wf);

        public static AsmAnalyzer AsmAnalyzer(this IWfRuntime wf)
            => Svc.AsmAnalyzer.create(wf);

        public static ApiExtractWorkflow ApiExtractWorkflow(this IWfRuntime wf)
            => Svc.ApiExtractWorkflow.create(wf);
    }
}