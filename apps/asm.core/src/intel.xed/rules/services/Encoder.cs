//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public class Encoder
        {
            internal static Encoder create()
                => new Encoder();


            Encoder()
            {
                Machine = machine();
            }

            Encoder(MachineRequest request)
            {
                Request = request;
                Machine = machine();

            }

            MachineRequest Request;

            RuleMachine Machine;

            ByteBlock16 Storage;

            [MethodImpl(Inline)]
            ref byte Cell(int i)
                => ref Storage[i];

            [MethodImpl(Inline)]
            ref byte Cell(uint i)
                => ref Storage[i];

            public Encoder WithRequest(MachineRequest request)
            {
                Request = request;
                return this;
            }

            public ReadOnlySpan<byte> Encode(MachineRequest request)
            {
                Request = request;
                Machine = Machine.Reset();
                Storage = ByteBlock16.Empty;
                return default;
            }
        }
    }
}