//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedOperands
    {
        public interface IMachine
        {
            void LoadPattern(InstPattern src);

            void Reset();
        }
    }
}