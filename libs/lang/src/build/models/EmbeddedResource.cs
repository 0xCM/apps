//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using E = Microsoft.Build.Evaluation;

    partial class MsBuild
    {
        public class EmbeddedResourceSpec : ProjectItem
        {
            [MethodImpl(Inline)]
            public EmbeddedResourceSpec(string include)
                :base(EmptyString)
            {

            }
        }
    }
}