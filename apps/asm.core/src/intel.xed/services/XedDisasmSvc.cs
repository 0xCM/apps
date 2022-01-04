//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Asm;

    using static Root;
    using static core;
    using static XedModels;
    using static XedDisasm;


    public partial class XedDisasmSvc : AppService<XedDisasmSvc>
    {
        Symbols<IFormType> Forms;

        Symbols<IClass> Classes;

        Symbols<OperandWidthType> WidthTypes;

        XedRules Rules => Service(Wf.XedRules);

        ConstLookup<OperandWidthType,OperandWidth> OperandWidths;

        public XedDisasmSvc()
        {
            Forms = Symbols.index<IFormType>();
            Classes = Symbols.index<IClass>();
            WidthTypes = Symbols.index<OperandWidthType>();
        }

        protected override void OnInit()
        {
            var dst = dict<OperandWidthType, OperandWidth>();
            iter(Rules.LoadOperandWidths(), w => dst.TryAdd(w.Code, w));
            OperandWidths = dst;
        }

        OperandWidth OperandWidth(OperandWidthType type)
            => OperandWidths[type];

        public FS.Files DisasmFiles(IProjectWs ws)
            => ws.OutFiles(FS.ext("xed.txt"));

        public FS.FilePath DisasmTable(IProjectWs project)
            => ProjectDb.ProjectData() + FS.file(string.Format("xed.disasm.{0}", project.Project), FS.Csv);

        public Outcome ParseInstructions(ReadOnlySpan<Block> src, out Index<Instruction> dst)
        {
            var count = src.Length;
            var result = Outcome.Success;
            dst = alloc<Instruction>(count);
            for(var i=0; i<count; i++)
            {
                result = ParseInstruction(skip(src,i), out dst[i]);
                if(result.Fail)
                    break;
            }
            return result;
        }

        public Index<AsmStatementEncoding> Collect(IProjectWs project)
        {
            var result = Outcome.Success;
            var paths = DisasmFiles(project);
            var records = ParseEncodings(paths);
            var count = paths.Length;
            TableEmit(records.View, AsmStatementEncoding.RenderWidths, DisasmTable(project));
            return records;
        }

        public Index<AsmStatementEncoding> ParseEncodings(ReadOnlySpan<FS.FilePath> src)
        {
            var dst = list<AsmStatementEncoding>();
            var counter = 0u;
            var count = src.Length;

            for(var i=0; i<count; i++)
            {
                var result = XedDisasmOps.ParseEncodings(skip(src,i), dst);
                if(result.Fail)
                {
                    Error(result.Message);
                    return sys.empty<AsmStatementEncoding>();
                }
            }

            var encodings = dst.ToArray();
            for(var i=0u; i<encodings.Length; i++)
                seek(encodings,i).Seq = i;

            return encodings;
        }

        public ConstLookup<FS.FilePath,StatementEncodings> ParseEncodings(IProjectWs project)
        {
            var src = project.OutFiles(FS.ext("xed.txt"));
            var count = src.Count;
            var dst = dict<FS.FilePath,StatementEncodings>();
            for(var i=0; i<count; i++)
            {
                var result = XedDisasmOps.ParseEncodings(src[i], out var encodings);
                if(result)
                    dst[src[i]] = encodings;
                else
                {
                    Error(result.Message);
                    return dict<FS.FilePath,StatementEncodings>();
                }
            }
            return dst;
        }

        /// <summary>
        /// Transforms the source document into a sequence of blocks, each of which describe a single decoded instruction
        /// </summary>
        /// <param name="src">And xed-emitted disassemly file</param>
        public Index<Block> ParseBlocks(FS.FilePath src)
            => XedDisasmOps.LoadBlocks(src);

        Outcome ParseInstruction(in Block block, out Instruction inst)
        {
            var result = Outcome.Success;
            inst = default(Instruction);
            ref readonly var content = ref block.Instruction.Content;
            if(text.nonempty(content))
            {
                var j = text.index(content, Chars.Space);
                if(j > 0)
                {
                    var expr = text.left(content,j);
                    if(Classes.Lookup(expr, out var @class))
                        inst.Class = @class;
                    else
                    {
                        result = (false,string.Format("IClass not found in '{0}'", content));
                        return result;
                    }

                    var k = text.index(content, j+1, Chars.Space);
                    if(k > 0)
                    {
                        expr = text.inside(content, j, k);
                        if(Forms.Lookup(expr, out var form))
                            inst.Form = form;
                        else
                        {
                            result = (false,string.Format("IFormType not found in '{0}'", expr));
                            return result;
                        }
                    }

                    var props = text.words(text.right(content,k), Chars.Comma);
                    var kP = props.Count;
                    inst.Props = alloc<Facet<string>>(kP);
                    for(var m=0; m<kP; m++)
                    {
                        ref readonly var p = ref props[m];
                        if(p.Contains(Chars.Colon))
                        {
                            var kv = text.split(p, Chars.Colon);
                            if(kv.Length == 2)
                                inst.Props[m] = (skip(kv,0).Trim(), skip(kv,1).Trim());
                        }
                        else
                        {
                            inst.Props[m] = (p.Trim(), EmptyString);
                        }
                    }
                }
            }
            return result;
        }
    }
}