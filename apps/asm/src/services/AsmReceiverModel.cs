//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    public struct AsmReceiverProduction
    {
        public AsmMnemonic Mnemonic;
    }

    [ApiHost]
    public class AsmReceiverModel : IReceiver<ApiCodeBlock,AsmInstructionBlock>
    {
        readonly uint Capacity;

        readonly IWfRuntime Wf;

        uint Receipts;

        uint Targets;

        readonly Index<IceInstruction> Received;

        readonly Index<AsmReceiverProduction> Produced;

        public AsmReceiverModel(IWfRuntime wf, uint capacity)
        {
            Wf = wf;
            Capacity = capacity;
            Received = sys.alloc<IceInstruction>(Capacity);
            Produced = sys.alloc<AsmReceiverProduction>(Capacity);
            Receipts = 0;
            Targets = 0;
        }

        public ReadOnlySpan<AsmReceiverProduction> Productions
        {
            [MethodImpl(Inline)]
            get => slice(Produced.View, 0, Targets);
        }

        [Op]
        public void Deposit(in ApiCodeBlock encoded, in AsmInstructionBlock decoded)
        {
            var instructions = decoded.Instructions;
            var count = instructions.Length;
            for(var i=0; i<count; i++)
            {
                if(Receipts < Capacity - 1)
                {
                    ref readonly var instruction = ref skip(instructions,i);
                    Deposit(encoded, instruction);
                    Produce(encoded, instruction);
                }
            }
        }

        [MethodImpl(Inline), Op]
        void Deposit(in ApiCodeBlock block, in IceInstruction src)
        {
            Received[Receipts++] = src;
        }

        [Op]
        void Produce(in ApiCodeBlock block, in IceInstruction src)
        {
            if(src.Mnemonic == IceMnemonic.INVALID)
                return;

            var target = new AsmReceiverProduction();
            target.Mnemonic = src.AsmMnemonic;

            Produced[Targets++] = target;
        }
    }
}