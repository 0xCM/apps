//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedModels;

    partial class XedMachine
    {
        public class CaptureState
        {
            public ConcurrentDictionary<InstForm,HashSet<InstPattern>> FormPatterns = new();
        }
    }
}