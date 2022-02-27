//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static core;
    using static Root;

    using P = XedModels.RulePart;

    partial class XedRules
    {
        Index<InstDef> ParseInstDefs(FS.FilePath src)
        {
            var buffer = list<InstDef>();
            using var reader = src.Utf8LineReader();
            var def = default(InstDef);
            var result = Outcome.Success;
            while(reader.Next(out var line))
            {
                if(line.IsEmpty || line.StartsWith(Chars.Hash) || line.EndsWith("::"))
                    continue;

                if(line.StartsWith(Chars.LBrace))
                {
                    var dst = default(InstDef);
                    var pattern = EmptyString;
                    var operands = list<PatternOperands>();
                    while(!line.StartsWith(Chars.RBrace) && reader.Next(out line))
                    {
                        if(line.IsEmpty)
                            continue;

                        var i = text.index(line.Content, Chars.Colon);
                        if(i > 0)
                        {
                            var name = text.trim(text.left(line.Content,i));
                            var value = text.trim(text.right(line.Content,i));
                            if(empty(value))
                                continue;

                            if(ClassifyPart(name, out var p))
                            {
                                switch(p)
                                {
                                    case P.IForm:
                                        ParseIForm(value, out dst.Form);
                                    break;
                                    case P.Attributes:
                                        ParseAttribKinds(value, out dst.Attributes);
                                    break;
                                    case P.Category:
                                        ParseCategory(value, out dst.Category);
                                    break;
                                    case P.Extension:
                                        ParseExtension(value, out dst.Extension);
                                    break;
                                    case P.Flags:
                                        dst.Flags = ParseFlagActions(value);
                                    break;
                                    case P.IClass:
                                        ParseIClass(value, out dst.Class);
                                    break;
                                    case P.Operands:
                                        result = ParseOperands(value, out var ops);
                                        if(result)
                                        {
                                            operands.Add(new PatternOperands(pattern, ops));
                                            pattern=EmptyString;
                                        }
                                        else
                                        {
                                            Error(result.Message);
                                            return sys.empty<InstDef>();
                                        }
                                    break;
                                    case P.Pattern:
                                        pattern = value;
                                    break;
                                    case P.Isa:
                                        ParseIsaKind(value, out dst.Isa);
                                    break;
                                }
                            }
                        }
                    }

                    dst.PatternOps = operands.Array();
                    buffer.Add(dst);
                }
            }

            return buffer.ToArray().Sort();
        }

        bool ClassifyPart(string src, out RulePart part)
        {
            var count = PartNames.Count;
            var result = false;
            part = default;
            for(var i=0; i<count; i++)
            {
                var p = (RulePart)i;
                ref readonly var n = ref PartNames[p];
                if(n == src)
                {
                    part = p;
                    result = true;
                    break;
                }
            }
            return result;
        }
    }
}