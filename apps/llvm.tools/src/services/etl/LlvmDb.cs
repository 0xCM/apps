// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0.llvm
// {
//     using System;
//     using System.Runtime.CompilerServices;
//     using System.IO;

//     using static Root;
//     using static core;

//     public sealed class LlvmDb : AppService<LlvmDb>
//     {
//         new LlvmPaths Paths;

//         LineMap<Identifier> ClassMap;

//         LineMap<Identifier> DefMap;

//         IdentityMap<Interval<uint>> DefLookup;

//         IdentityMap<Interval<uint>> ClassLookup;

//         IdentityMap<Interval<uint>> FieldDefMap;

//         LlvmDataProvider DataProvider;

//         public LlvmDb()
//         {
//             ClassMap = LineMap<Identifier>.Empty;
//             DefMap = LineMap<Identifier>.Empty;
//             DefLookup = new();
//             FieldDefMap = new();
//             ClassLookup = new();
//         }

//         protected override void Initialized()
//         {
//             Paths = Wf.LlvmPaths();
//             DataProvider = Wf.LlvmDataProvider();
//             LoadData();
//         }

//         protected override void Disposing()
//         {

//         }

//         void LoadDefs()
//         {
//             DefMap = DataProvider.SelectX86DefMap();
//             iteri(DefMap.Intervals, (i,entry) => DefLookup.Map(entry.Id, (entry.MinLine,entry.MaxLine)));
//         }

//         void LoadClasses()
//         {
//             ClassMap = DataProvider.SelectX86ClassMap();
//             iteri(ClassMap.Intervals, (i,entry) => ClassLookup.Map(entry.Id, (entry.MinLine,entry.MaxLine)));
//         }

//         void LoadData()
//         {
//             var flow = Running("Loading data");
//             LoadClasses();
//             LoadDefs();
//             Ran(flow);
//         }

//     }
// }