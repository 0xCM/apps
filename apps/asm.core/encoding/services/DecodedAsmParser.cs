//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    public class DecodedAsmParser
    {
        public static DecodedAsmParser create(AsmCodeDispenser dispenser)
            => new DecodedAsmParser(dispenser);

        AsmCodeBlocks Target;

        Hex16 BlockOffset;

        AsmAddressLabel BlockBase;

        AsmCodeDispenser Dispenser;

        DecodedAsmParser(AsmCodeDispenser dispenser)
        {
            Dispenser = dispenser;
        }

        public AsmCodeBlocks Parsed()
            => Target;

        Outcome ParseStatement(string content, out AsmCode decoded)
        {
            decoded = AsmCode.Empty;
            var result = Outcome.Success;
            var i = text.index(content,Chars.Hash);
            if(i == NotFound)
                return (false, string.Format("Comment data not found in '{0}'", content));

            var comments = text.trim(text.split(text.right(content,Chars.Hash),Chars.Pipe));
            if(comments.Length < 4)
                return (false, string.Format("Unsupported comment style:{0}", content));

            var cell = EmptyString;
            cell = skip(comments,0);
            result = HexParser.parse64u(cell, out var offset);
            if(result.Fail)
                return (false, string.Format("Unable to parse {0} from '{1}'", "offset", cell));

            if(offset != BlockOffset)
                return (false, string.Format("Offset mismatch: {0} != {1}", offset, BlockOffset));

            cell = skip(comments,1);
            result = DataParser.parse(cell, out byte size);
            if(result.Fail)
                return (false, string.Format("Unable to parse {0} from '{1}'", "size", cell));

            cell = skip(comments,2);
            result = DataParser.parse(cell, out BinaryCode encoding);
            if(result.Fail)
                return (false, string.Format("Unable to parse {0} from '{1}'", "encoding", cell));

            if(size != encoding.Size)
                return (false, "Encoding size mismatch");

            decoded = CreateAsmCode(text.trim(text.left(content,i)), offset, encoding);
            return result;
        }

        AsmCode CreateAsmCode(string asm, MemoryAddress ip, BinaryCode code)
        {
            var size = code.Size;
            var identifier = string.Format("_@{0}_{1}", BlockBase.Address, BlockOffset);
            var hexDst = Dispenser.AsmEncoding(size);
            var buffer = hexDst.Edit;
            var hexSrc = code.View;
            for(var j=0; j<size; j++)
                seek(buffer,j) = skip(hexSrc,j);
            BlockOffset += size;
            return new AsmCode(AsmBytes.encid(ip, code), 0,  Dispenser.DispenseSource(asm), ip, hexDst);
        }

        public Outcome ParseBlocks(string src)
        {
            Target = AsmCodeBlocks.Empty;
            BlockOffset = 0;
            BlockBase = AsmAddressLabel.Empty;
            var blocks = list<AsmCodeBlock>();
            var result = Outcome.Success;
            var block = LocatedSymbol.Empty;
            var statemements = list<AsmCode>();
            var lines = Lines.read(src);
            var count = lines.Length;
            for(var m=0; m<count; m++)
            {
                ref readonly var line = ref skip(lines,m);
                ref readonly var content = ref line.Content;
                if(text.begins(content, Chars.Hash))
                    continue;

                if(AsmParser.label(content, out AsmAddressLabel @base))
                {
                    if(statemements.Count != 0 && block.IsNonEmpty)
                        blocks.Add(new (block, statemements.ToArray()));

                    block = Dispenser.DispenseSymbol(@base.Address, @base.Format());
                    BlockBase = @base;
                    BlockOffset = 0;
                    statemements.Clear();
                }
                else
                {
                    result = ParseStatement(content, out var statement);
                    if(result.Fail)
                        break;

                    statemements.Add(statement);
                }
            }

            if(statemements.Count != 0)
                blocks.Add(new (block, statemements.ToArray()));

            if(result)
                Target = new AsmCodeBlocks(blocks.ToArray());

            return result;
        }
    }
}