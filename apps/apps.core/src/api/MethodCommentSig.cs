//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct MethodCommentSig
    {
        public static MethodCommentSig from(in ApiComment src)
            => new MethodCommentSig(src);

        public readonly string Data;

        public readonly string Type;

        public readonly string Method;

        public readonly Index<string> Operands;

        public MethodCommentSig(in ApiComment src)
        {
            Data = EmptyString;
            Type = EmptyString;
            Method = EmptyString;
            Operands = sys.empty<string>();
            var data = text.remove(src.Identifer,"Z0.");
            var i = text.index(data, Chars.Dot);
            if(i>0)
            {
                Type = text.left(data, i);
                var remainder = text.right(data,i);
                i = text.index(remainder,Chars.LParen);
                if(i > 0)
                    Method = text.left(remainder,i);

                var j =text.index(remainder,Chars.RParen);
                if(i > 0 && j > i)
                    Operands = text.trim(text.split(text.inside(remainder, i, j), Chars.Comma));
            }


            Data = data;
        }

        public string Format()
        {
            var dst = text.buffer();
            dst.Append(Method);
            dst.Append(Chars.Colon);
            var count = Operands.Count;
            if(count == 0)
                dst.Append("void");

            for(var i=0; i<count; i++)
            {
                var optype = ApiComments.TypeDisplayName(Operands[i]);
                dst.Append(optype);
                dst.Append(" -> ");
            }
            dst.Append("| todo");

            return dst.Emit();
        }

        public override string ToString()
            => Format();

    }
}