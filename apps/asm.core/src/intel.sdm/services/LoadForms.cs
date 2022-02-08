//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class IntelSdm
    {
        public SdmFormLookup LoadFormLookup()
        {
            return Data(nameof(LoadFormLookup), Load);

            SdmFormLookup Load()
            {
                var forms = LoadForms();
                var count = forms.Count;
                var lookup = dict<Identifier,List<AsmFormRecord>>();
                for(var i=0; i<count; i++)
                {
                    ref readonly var form = ref forms[i];
                    if(lookup.TryGetValue(form.Kind, out var records))
                    {
                        records.Add(form);
                    }
                    else
                    {
                        lookup[form.Kind] = new();
                        lookup[form.Kind].Add(form);
                    }
                }
                return new(lookup);
            }
        }

        public Index<AsmFormRecord> LoadForms()
        {
            const byte FieldCount = AsmFormRecord.FieldCount;

            return Data(nameof(LoadForms), Load);

            Index<AsmFormRecord> Load()
            {
                var path = ProjectDb.TablePath<AsmFormRecord>("sdm");
                var lines = path.ReadNumberedLines(true);
                var count = lines.Count;
                var buffer = alloc<AsmFormRecord>(count - 1);
                var result = Outcome.Success;
                for(uint i=1, k=0; i<count; i++,k++)
                {
                    ref readonly var line = ref lines[i];
                    var cells = text.split(line.Content,Chars.Pipe);
                    var kCells = cells.Length;
                    if(kCells != FieldCount)
                    {
                        result = (false,AppMsg.FieldCountMismatch.Format(kCells,FieldCount));
                        break;
                    }

                    var j=0;
                    ref var dst = ref seek(buffer,k);
                    result = DataParser.parse(skip(cells,j++), out dst.Seq);

                    result = DataParser.parse(skip(cells,j++), out dst.Token);
                    if(result.Fail)
                        break;

                    dst.Mnemonic = AsmMnemonic.parse(skip(cells,j++), out _);

                    result = DataParser.parse(skip(cells,j++), out dst.Kind);
                    if(result.Fail)
                        break;

                    result = AsmOcParser.parse(skip(cells,j++), out dst.OpCode);
                    if(result.Fail)
                        break;

                    result = AsmSigParser.expression(skip(cells,j++), out dst.Sig);
                    if(result.Fail)
                        break;

                    result = AsmSigParser.expression(skip(cells,j++), out dst.Source);
                    if(result.Fail)
                        break;

                }

                if(result.Fail)
                {
                    Error(result.Message);
                    return sys.empty<AsmFormRecord>();
                }

                return buffer;
            }
        }
    }
}