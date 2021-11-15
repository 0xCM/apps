//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public struct AsmReceiverProduction
    {
        public AsmMnemonicCode Mnemonic;
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
            AssignMnemonicCode(src, ref target);

            Produced[Targets++] = target;
        }

        [Op]
        void AssignMnemonicCode(in IceInstruction src, ref AsmReceiverProduction dst)
        {
            var name = src.AsmMnemonic.Format();
            if(Enums.parse<AsmMnemonicCode>(name, out var code))
            {
                dst.Mnemonic = code;
            }
            else
            {
                Wf.Warn(UnrecognizedMnemonic.Format(name));
            }
        }

        static MsgPattern<string> UnrecognizedMnemonic => "The mnemonic {0} was not recognized";
    }
}