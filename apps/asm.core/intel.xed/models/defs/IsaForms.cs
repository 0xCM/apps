//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        public class IsaForms : ConcurrentDictionary<ChipCode, ChipIsa>
        {

            public IsaForms(Dictionary<ChipCode,ChipIsa> src)
                : base(src)
            {


            }

            public static implicit operator IsaForms(Dictionary<ChipCode,ChipIsa> src)
                => new IsaForms(src);
        }
    }
}