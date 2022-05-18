//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public static class XSvc
    {
        public static PolyBits PolyBits(this IWfRuntime wf)
            => Z0.PolyBits.create(wf);

        [Op]
        public static PbCmd PbCmd(this IWfRuntime wf)
            => Z0.PbCmd.create(wf);

        [Op]
        public static BitfieldServices Bitfields(this IWfRuntime wf)
            => Z0.BitfieldServices.create(wf);

        [Op]
        public static BitMaskServices ApiBitMasks(this IWfRuntime wf)
            => Z0.BitMaskServices.create(wf);

        [Op]
        public static HexCsvReader HexCsvReader(this IWfRuntime wf)
            => Z0.HexCsvReader.create(wf);

        [Op]
        public static HexCsvWriter HexCsvWriter(this IWfRuntime wf)
            => Z0.HexCsvWriter.create(wf);

        [Op]
        public static HexDataReader HexDataReader(this IWfRuntime context)
            => Z0.HexDataReader.create(context);

        [Op]
        public static HexEmitter HexEmitter(this IWfRuntime wf)
            => Z0.HexEmitter.create(wf);

        [Op]
        public static Symbolism Symbolism(this IWfRuntime wf)
            => Z0.Symbolism.create(wf);
    }
}