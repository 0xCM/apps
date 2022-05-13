//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class TextTemplateChecker : Checker<TextTemplateChecker>
    {
        public Outcome Check1()
        {
            const string Pattern = "{0} {1} {2} {3}({4},{5});";
            var result = Outcome.Success;
            var template = TextTemplates.template(Pattern, "public", "static", "uint", "f", "x", "y");
            return result;
        }
    }
}
