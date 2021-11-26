//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using C = Windows.Image.IMAGE_SECTION_CHARACTERISTICS;

    partial class LlvmCmd
    {

        [CmdOp(".flags")]
        Outcome FlagTest(CmdArgs args)
        {
            var result = Outcome.Success;
            //var flags = Flags.create<C>(w32,default);
            var flags = default(C);
            //var formatter = Flags.formatter<C>(w32);

            flags |= C.IMAGE_SCN_ALIGN_16BYTES;
            flags |= C.IMAGE_SCN_CNT_CODE;
            flags |= C.IMAGE_SCN_MEM_EXECUTE;
            flags |= C.IMAGE_SCN_MEM_READ;

            Write(flags.ToString());

            Write(((uint)flags).FormatHex());

            return result;
        }

        [CmdOp(".objinfo")]
        Outcome ObjInfo(CmdArgs args)
        {
            var result = Outcome.Success;
            var files = ReadObj.ObjInfoFiles(State.Project().OutDir());
            var parser = LlvmObiParser.create(Wf);
            foreach(var file in files)
            {
                result = parser.Parse(file, out var obi);
                Write(string.Format("{0} Lines", obi.DataLines.Length));
            }

            return result;
        }
    }
}