//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;
    using static Root;

    partial class LlvmCmd
    {
        [CmdOp("llvm/llc/help")]
        void LlcHelp()
        {
            var result = Outcome.Success;
            result = Toolset.Help(ToolNames.llc, out var doc);
            if(result.Fail)
            {
                Error(result.Message);
                return;
            }

            doc = doc.Load();
            var choices = list<string>();
            var lines = Lines.read(doc.Content.Text);
            var count = lines.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var line = ref skip(lines,i);
                var content = line.Content.Trim();
                var k = text.whitespace(content);
                var name = EmptyString;
                if(k > 0)
                    name = text.left(content,k);

                if(text.empty(name))
                    continue;
                var _name = name.Trim();
                if(text.index(_name,Chars.Eq) == 0)
                {
                    var choice = text.substring(_name,1);
                    choices.Add(choice);
                }
                else
                {
                    if(choices.Count != 0)
                    {
                        Write(string.Format("  choices: {0}", choices.Delimit()));
                        choices.Clear();
                    }

                    Write(name.Trim());
                }
            }
        }
    }
}