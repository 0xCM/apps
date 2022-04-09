//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedDisasm
    {
        public class DisasmProps : Dictionary<string,string>
        {
            public DisasmProps(Index<Facet<string>> src)
                : base(src.Select(x => (x.Key,x.Value)).ToDictionary())
            {

            }

            public static implicit operator DisasmProps(Index<Facet<string>> src)
                => new DisasmProps(src);

            public static DisasmProps Empty => new DisasmProps(sys.empty<Facet<string>>());
        }
    }
}