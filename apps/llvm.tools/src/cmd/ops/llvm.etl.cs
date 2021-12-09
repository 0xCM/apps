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
        [CmdOp("llvm/etl")]
        Outcome RunRecordsEtl(CmdArgs args)
        {
            LlvmEtl.Run();
            return true;
        }

        static string mnemonic(N0 n, string src)
        {
            var i = text.index(src, Chars.Space);
            var dst = src;
            if(i >=0)
                dst = mnemonic(n1,text.left(src,i));
            return dst;
        }

        static string mnemonic(N1 n, string src)
        {
            var i = text.index(src, Chars.LBrace);
            var dst = src;
            if(i >=0)
                dst = text.left(src,i);
            return dst;
        }

        static string pattern(N0 n, string src)
        {
            var monic = mnemonic(n0,src);
            var i = text.index(src, Chars.Space);
            if(i == NotFound)
                return monic;
            else
            {
                var right = text.right(src,i);

                if(text.fenced(right, Fencing.Embraced))
                    right = text.unfence(right, 0, Fencing.Embraced);

                var j = text.index(right, Chars.Caret);
                if(j >= 0)
                    right = text.right(right,j);
                right = text.replace(right,"${mask}", "$mask");
                return string.Format("{0} {1}", monic, right);
            }
        }

        [CmdOp(".asm-strings")]
        Outcome ListAsmStrings(CmdArgs args)
        {
            var instructions = DataProvider.SelectEntities(e => e.IsInstruction()).Select(x => x.ToInstruction());
            var asmids = DataProvider.SelectAsmIdDefs();
            var count = instructions.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var inst = ref instructions[i];
                var name = inst.InstName;
                if(asmids.Find(name, out var id))
                {
                    if(inst.isCodeGenOnly || inst.isPseudo)
                    {
                        Write(string.Format("{0,-8} | {1,-24} | {2,-16} | {3,-54} | {4}", id.Id, name, EmptyString, EmptyString, EmptyString));
                    }
                    else
                    {
                        var raw = inst.RawAsmString;
                        var input = text.remove(raw, Chars.Quote).Replace(Chars.Tab, Chars.Space).Trim();
                        var m0 = mnemonic(n0, input);
                        var p0 = pattern(n0, input);
                        Write(string.Format("{0,-8} | {1,-24} | {2,-16} | {3,-54} | {4}", id.Id, name, m0, p0, raw));
                    }
                }
                else
                {
                    return (false, string.Format("{0} id not found", inst.InstName));
                }
            }

            return true;
        }
    }
}