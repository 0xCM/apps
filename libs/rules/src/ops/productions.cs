//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Rules
    {
        public static Productions productions(FS.FilePath src)
        {
            var dst = dict<string,IProduction>();
            using var reader = src.Utf8LineReader();
            var result = Outcome.Success;
            while(reader.Next(out var line))
            {
                if(line.Trim().IsEmpty)
                    continue;

                result = RuleParser.production(line.Content, out IProduction prod);
                if(result)
                    dst.TryAdd(prod.Source.Format(), prod);
                else
                    break;
            }

            if(result.Fail)
                Errors.Throw(result.Message);
            return dst;
        }
    }
}