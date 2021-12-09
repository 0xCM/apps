//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;

    readonly struct FunctionTypeFormatter : IFormatter<FunctionType>
    {
        public static FunctionTypeFormatter Service => default;

        public string Format(FunctionType src)
        {
            var dst = text.buffer();
            dst.Append(src.Name);
            dst.AppendFormat("[{0}]", src.KindName);
            dst.Append(":");
            var operands = src.Operands;
            var count = operands.Count;
            for(var i=0; i<count; i++)
            {
                dst.Append(operands[i].Format());
                if(i != count - 1)
                    dst.Append(" -> ");
            }
            return dst.Emit();
        }
    }
}