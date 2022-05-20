// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     using System;

//     using static Root;
//     using static core;

//     class App : AppService<App>
//     {
//         public App()
//         {

//         }

//         void Dispatch(string cmd, CmdArgs args)
//         {
//             var commands = Wf.GlobalCommands();
//             var dispatcher = commands.Dispatcher;
//             var result = dispatcher.Dispatch(cmd, args);
//             if(result.Fail)
//                 Wf.Error(result.Message);
//         }

//         void Dispatch()
//         {
//             var input = Wf.Args;
//             if(input.Length == 0)
//             {
//                 Error("Command unspecified");
//                 return;
//             }

//             var cmd = input[0];
//             if(input.Length == 1)
//                 Dispatch(cmd, CmdArgs.Empty);
//             else
//             {
//                 var values = slice(span(input),1);
//                 var count = values.Length;
//                 var args = alloc<CmdArg>(count);
//                 for(ushort i=0; i<count; i++)
//                     seek(args,i) = Cmd.arg(i,skip(values,i));
//                 Dispatch(cmd, args);
//             }
//         }

//         public void Run()
//         {
//             Dispatch();
//         }

//         public static void Main(params string[] args)
//         {
//             try
//             {
//                 var parts = ApiRuntimeLoader.parts(controller(), array<string>(), true);
//                 using var wf = WfAppLoader.load(parts, args);
//                 var app = App.create(wf.WithSource(Rng.@default()));
//                 app.Run();

//             }
//             catch(Exception e)
//             {
//                 term.error(e);
//             }
//         }
//     }
// }
