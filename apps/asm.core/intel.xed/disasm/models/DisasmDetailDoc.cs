//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedDisasm;

    public class DisasmDetailDoc : TableDoc<DetailBlock>
    {
        public static DisasmDetailDoc from(DisasmFile file, DetailBlock[] data)
            => new(file,data);

        public DisasmDetailDoc(DisasmFile file, DetailBlock[] data)
            : base(file.Source.Path, data)
        {
            File = file;
        }

        public readonly DisasmFile File;

        public static DisasmDetailDoc Empty => new DisasmDetailDoc(DisasmFile.Empty, sys.empty<DetailBlock>());
    }
}