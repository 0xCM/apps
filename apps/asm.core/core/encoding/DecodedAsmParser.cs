//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    public class DecodedAsmParser
    {
        public static DecodedAsmParser create(AsmDispenser dispenser)
            => new DecodedAsmParser(dispenser);

        DecodedAsmBlocks Target;

        Hex16 BlockOffset;

        AsmAddressLabel BlockBase;

        AsmDispenser Dispenser;

        DecodedAsmParser(AsmDispenser dispenser)
        {
            Dispenser = dispenser;
        }

        public DecodedAsmBlocks Parsed()
            => Target;

        Outcome ParseStatement(string content, out DecodedAsm decoded)
        {
            decoded = DecodedAsm.Empty;
            var result = Outcome.Success;
            var i = text.index(content,Chars.Hash);
            if(i == NotFound)
                return (false, string.Format("Comment data not found in '{0}'", content));

            var comments = text.trim(text.split(text.right(content,Chars.Hash),Chars.Pipe));
            if(comments.Length < 4)
                return (false, string.Format("Unsupported comment style:{0}", content));

            var cell = EmptyString;
            cell = skip(comments,0);
            result = HexParser.parse16u(cell, out var offset);
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

            decoded = CreateStatement(text.trim(text.left(content,i)), offset, encoding);
            return result;
        }

        DecodedAsm CreateStatement(string asm, Hex16 offset, BinaryCode code)
        {
            var size = code.Size;
            var identifier = string.Format("_@{0}_{1}", BlockBase.Address, BlockOffset);
            var hexDst = Dispenser.Encoding(size);
            var buffer = hexDst.Edit;
            var hexSrc = code.View;
            for(var j=0; j<size; j++)
                seek(buffer,j) = skip(hexSrc,j);
            BlockOffset += size;
            return new DecodedAsm(offset, hexDst, Dispenser.Source(identifier, asm));
        }

        public Outcome ParseBlocks(string src)
        {
            Target = DecodedAsmBlocks.Empty;
            BlockOffset = 0;
            BlockBase = AsmAddressLabel.Empty;
            var blocks = list<DecodedAsmBlock>();
            var result = Outcome.Success;
            var block = LocatedSymbol.Empty;
            var statemements = list<DecodedAsm>();
            var lines = Lines.read(src);
            var count = lines.Length;
            for(var m=0; m<count; m++)
            {
                ref readonly var line = ref skip(lines,m);
                ref readonly var content = ref line.Content;
                if(text.begins(content, Chars.Hash))
                    continue;

                if(AsmAddressLabel.parse(content, out var @base))
                {
                    if(statemements.Count != 0 && block.IsNonEmpty)
                        blocks.Add(new (block, statemements.ToArray()));

                    block = Dispenser.Symbol(@base.Address, @base.Format());
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
                Target = new DecodedAsmBlocks(blocks.ToArray());

            return result;
        }
    }
}