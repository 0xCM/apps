//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class IntelSdm
    {
        public Index<AsmSigSymbolic> LoadSymbolicSigs()
        {
            const byte FieldCount = AsmSigSymbolic.FieldCount;
            var result = Outcome.Success;
            var src = ProjectDb.TablePath<AsmSigSymbolic>("sdm");
            var buffer = list<AsmSigSymbolic>();
            using var reader = src.Utf8LineReader();
            reader.Next(out _);
            while(reader.Next(out var line))
            {
                if(line.IsEmpty)
                    continue;

                var parts = line.Split(Chars.Pipe);
                var count = parts.Length;
                if(count != FieldCount)
                {
                    result = (false,AppMsg.FieldCountMismatch.Format(count, FieldCount));
                    break;
                }

                var dst = new AsmSigSymbolic();
                var i=0;

                result = DataParser.parse(skip(parts,i++), out dst.Seq);
                if(result.Fail)
                    break;

                result = DataParser.parse(skip(parts,i++), out dst.Name);
                if(result.Fail)
                    break;

                dst.Source = AsmSigs.expression(skip(parts,i++));
                if(result.Fail)
                    break;

                result = Parse(skip(parts,i++), out dst.Target);
                if(result.Fail)
                    break;

                buffer.Add(dst);
            }

            if(result.Fail)
                Error(result.Message);

            return buffer.ToArray();
        }
    }
}