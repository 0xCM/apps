//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedDisasm;

    public class DisasmDetailDoc : TableDoc<DisasmDetailBlock>
    {
        public static DisasmDetailDoc from(DisasmFile file, DisasmDetailBlock[] data)
            => new(file,data);

        public DisasmDetailDoc(DisasmFile file, DisasmDetailBlock[] data)
            : base(file.Source.Path, data)
        {
            File = file;
        }

        public readonly DisasmFile File;
    }
}