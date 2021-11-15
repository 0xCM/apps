//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmCmdService
    {
        [CmdOp(".api")]
        Outcome Api(CmdArgs args)
        {
            var path = ApiPath.Empty;
            var result = Outcome.Success;

            if(args.Count != 0)
            {
                var input = arg(args,0).Value;
                var part = PartId.None;
                var i = text.index(input, Chars.FSlash);
                if(i > 0)
                {
                    var components = input.Split(Chars.FSlash);
                    result = ApiParsers.part(text.left(input, i), out part);
                    if(result)
                        path = ApiPath.define(part, text.right(input, i));
                }
                else
                {
                    result = ApiParsers.part(input, out part);
                    if(result)
                        path = ApiPath.define(part);
                }

                if(result.Fail)
                    return result;

                State.Api(path);
            }
            else
            {
                path = State.Api();
            }

            Write(path.Format());

            return result;
        }
    }
}