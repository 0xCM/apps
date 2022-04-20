//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedDisasm
    {
        public class Document : IPaired<Summary,Detail>
        {
            public readonly Summary Summary;

            public readonly Detail Detail;

            [MethodImpl(Inline)]
            public Document(Summary summary, Detail detail)
            {
                Summary = summary;
                Detail = detail;
            }

            Summary IPaired<Summary, Detail>.Left
                => Summary;

            Detail IPaired<Summary, Detail>.Right
                => Detail;

            [MethodImpl(Inline)]
            public void Deconstruct(out Summary s, out Detail d)
            {
                s = Summary;
                d = Detail;
            }

            [MethodImpl(Inline)]
            public static implicit operator Document((Summary s, Detail d) src)
                => new Document(src.s,src.d);
        }
    }
}