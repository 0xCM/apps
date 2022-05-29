//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CliSvc : AppService<CliSvc>
    {
        public ReadOnlySpan<string> ReadUserStrings(PartId part)
        {
            var dst =  ReadOnlySpan<string>.Empty;
            if(Reader(part, out var reader))
                dst = reader.ReadStrings(CliStringKind.User);
            return dst;
        }

        public bool Reader(PartId part, out CliReader dst)
        {
            if(ApiRuntimeCatalog.FindComponent(part, out var component))
            {
                dst = CliReader.read(component);
                return true;
            }
            else
            {
                dst = default;
                return false;
            }
        }
    }
}