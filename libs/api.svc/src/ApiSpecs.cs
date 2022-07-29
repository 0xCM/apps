//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ApiTypes;

    sealed class ApiSpecsCmd : AppCmdService<ApiSpecsCmd>, IApiSpecs
    {
        ApiMd ApiMd => Wf.ApiMd();

        public ReadOnlySeq<ApiDataType> DataTypes()
            => data("DataTypes", () => types(ApiMd.Assemblies));

        public ReadOnlySeq<ApiTypeInfo> DataTypeInfo()
            => data("DataTypeInfo", () => describe(DataTypes()));

        [CmdOp("api/emit/types")]
        void EmitDataTypes()
        {
            TableEmit(DataTypeInfo(), AppDb.ApiTargets().Table<ApiTypeInfo>());
        }
    }
}