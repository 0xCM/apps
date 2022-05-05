//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;
    using static XedRules;

    partial class XedDisasm
    {
        public static InstFieldValues props(in DisasmBlock src)
        {
            parse(src, out InstFieldValues dst);
            return dst;
        }

        public static Index<InstFieldValues> props(ReadOnlySpan<DisasmBlock> src)
        {
            var count = src.Length;
            var dst = alloc<InstFieldValues>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = props(skip(src,i));
            return dst;
        }

        public static InstFieldValues props(InstClass @class, InstForm form, Index<Facet<string>> src)
        {
            var dst = dict<string,string>();
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var kvp = ref src[i];
                dst.Add(kvp.Key, kvp.Value);
            }
            return new InstFieldValues(@class,form,dst);
        }
    }
}