//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    public class DecodedAsmParser
    {
        public static DecodedAsmParser create(CompositeDispenser dispenser)
            => new DecodedAsmParser(dispenser);

        List<DecodedAsmBlock> Target;

        Hex16 BlockOffset;

        AsmAddressLabel BlockBase;

        CompositeDispenser Dispenser;

        DecodedAsmParser(CompositeDispenser dispenser)
        {
            Dispenser = dispenser;
        }

        public ReadOnlySpan<DecodedAsmBlock> Parsed()
            => Target.ViewDeposited();


        Outcome ParseStatement(string src, out DecodedAsmStatement dst)
        {
            dst = DecodedAsmStatement.Empty;
            var result = Outcome.Success;
            var i = text.index(src,Chars.Hash);
            if(i == NotFound)
                return (false, string.Format("Comment data not found in '{0}'", src));

            var comments = text.trim(text.split(text.right(src,Chars.Hash),Chars.Pipe));
            if(comments.Length < 4)
                return (false, string.Format("Unsupported comment style:{0}", src));

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

            dst.Encoded = encoding;
            dst.Decoded = text.trim(text.left(src,i));
            dst.IP = offset;
            dst.EncodingId = EncodingId.from(dst.IP, dst.Encoded);
            return result;
        }

        public Outcome ParseBlocks(string src)
        {
            Target = list<DecodedAsmBlock>();
            BlockOffset = 0;
            BlockBase = AsmAddressLabel.Empty;
            var result = Outcome.Success;
            var block = LocatedSymbol.Empty;
            var statemements = list<DecodedAsmStatement>();
            var lines = Lines.read(src);
            var count = lines.Length;
            var label = AsmBlockLabel.Empty;
            for(var m=0; m<count; m++)
            {
                ref readonly var line = ref skip(lines,m);
                ref readonly var content = ref line.Content;
                if(text.begins(content, Chars.Hash))
                    continue;

                if(AsmBlockLabel.parse(content, out label))
                {
                    if(statemements.Count != 0)
                        Target.Add(new DecodedAsmBlock(label, statemements.ToArray()));

                    BlockOffset = 0;
                    statemements.Clear();
                }
                else
                {
                    result = ParseStatement(content, out DecodedAsmStatement statement);
                    if(result.Fail)
                        break;

                    statemements.Add(statement);
                }
            }

            if(statemements.Count != 0)
                Target.Add(new DecodedAsmBlock(label, statemements.ToArray()));


            return result;
        }
    }
}