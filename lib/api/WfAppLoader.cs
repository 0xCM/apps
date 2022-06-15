// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     public readonly struct WfAppLoader
//     {
//         internal static IWfRuntime create(IApiParts parts, string[] args, string logname = EmptyString)
//             => ApiRuntime.create(parts,args,logname);

//         static MsgPattern<Timestamp> InitializingRuntime => "Initializing runtime at {0}";

//         static MsgPattern<Timestamp,Duration> InitializedRuntime => "Initialized runtime at {0} in {1}";
//     }
// }