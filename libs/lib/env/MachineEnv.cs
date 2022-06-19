//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Environs
    {
        public class MachineEnv : EnvProvider<MachineEnv,EnvVar>
        {
            public MachineEnv(EnvVar[] src)
                : base(src)
            {

            }
        }
    }
}