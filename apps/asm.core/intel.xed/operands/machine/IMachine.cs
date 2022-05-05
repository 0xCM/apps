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
            uint Id {get;}

            void Load(InstPattern src);

            void Reset();
        }
    }
}