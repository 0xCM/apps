//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class CliEmitter
    {
        public void EmitConstants(IApiPack dst)
        {
            var target = dst.Table<ConstantFieldInfo>();
            var flow = Wf.EmittingTable<ConstantFieldInfo>(target);
            var formatter = Tables.formatter<ConstantFieldInfo>(16);
            var counter = 0u;
            using var writer = target.Writer();
            writer.WriteLine(formatter.FormatHeader());
            var parts = ApiRuntimeCatalog.Parts;

            foreach(var part in parts)
            {
                try
                {
                    using var reader = PeTableReader.open(part.PartPath());
                    var constants = reader.Constants(ref counter);
                    var count = constants.Length;
                    for(var i=0; i<count; i++)
                        writer.WriteLine(formatter.Format(skip(constants,i)));
                }
                catch(Exception e)
                {
                    Error(e);
                }
            }

            EmittedTable(flow, counter);
        }
    }
}