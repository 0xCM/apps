//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class CheckCmdProvider
    {
        [CmdOp("check/captured2")]
        Outcome CheckCaptured2(CmdArgs args)
        {
            var result = Outcome.Success;
            var spec = EmptyString;
            if(args.Count != 0)
                spec = text.trim(arg(args,0).Value.Format());

            using var bank = CodeBanks.Encoding(spec);
            CheckSize(bank);

            return result;
        }

        void CheckSize(EncodingBank bank)
        {
            var count = bank.MemberCount;
            var rebase = MemoryAddress.Zero;
            var size = 0u;
            for(var i=0; i<count; i++)
            {
                var seg = bank.Segment(i);
                rebase = rebase + seg.Size;
                size += seg.Size;
            }

            Require.equal((ByteSize)size, bank.CodeSize);
        }

        CodeBanks CodeBanks => Service(Wf.ApiCodeBanks);

        [CmdOp("check/captured")]
        Outcome CheckCaptured(CmdArgs args)
        {
            var result = Outcome.Success;
            var spec = EmptyString;
            if(args.Count != 0)
                spec = text.trim(arg(args,0).Value.Format());

            const string RenderPattern = "{0,-8} | {1, -8} | {2,-8} | {3,-5} | {4,-8} | {5,-8} | {6,-32} | {7}";
            using var bank = CodeBanks.Encoding(spec);
            var count = bank.MemberCount;
            var target = MemoryAddress.Zero;
            var size = 0;
            var delta = 0;
            var blocksz = 0;
            var blockct = 0;
            var blockmem = 0u;
            for(var i=0; i<count; i++)
            {
                var code = bank.Code(i);
                ref readonly var desc = ref bank.Description(i);
                ref readonly var token = ref bank.Token(i);
                delta = (int)(token.TargetAddress - (target + size));
                blocksz += (int)(token.TargetAddress - target);
                target = token.TargetAddress;
                size = code.Length;
                var flair = delta >= PageBlock.PageSize ? FlairKind.StatusData : FlairKind.Data;
                if(delta >= PageBlock.PageSize)
                {
                    flair = FlairKind.StatusData;
                    blocksz = 0;
                    blockmem = 0;
                    blockct++;
                }
                else
                {
                    blockmem++;

                    flair = FlairKind.Data;
                }


                Write(string.Format(RenderPattern, i, blockmem, target, size, delta, blocksz, token.Host, token.Sig), flair);
            }

            return result;
        }
    }
}