@echo off
call %~dp0config.cmd

dotnet sln %ZSln% add %ZApps%\api\z0.api.csproj
dotnet sln %ZSln% add %ZApps%\asm\z0.asm.csproj
dotnet sln %ZSln% add %ZApps%\asm.cases\z0.asm.cases.csproj
dotnet sln %ZSln% add %ZApps%\asm.core\z0.asm.core.csproj
dotnet sln %ZSln% add %ZApps%\asm.data\z0.asm.data.csproj
dotnet sln %ZSln% add %ZApps%\asm.lang\z0.asm.lang.csproj
dotnet sln %ZSln% add %ZApps%\asm.lang.g\z0.asm.lang.g.csproj
dotnet sln %ZSln% add %ZApps%\asm.run\z0.asm.run.csproj
dotnet sln %ZSln% add %ZApps%\asm.shell\z0.asm.shell.csproj
dotnet sln %ZSln% add %ZApps%\asmz\z0.asmz.csproj
dotnet sln %ZSln% add %ZApps%\bits.test\z0.bits.test.csproj
dotnet sln %ZSln% add %ZApps%\calc.shell\z0.calc.shell.csproj
dotnet sln %ZSln% add %ZApps%\canonical\z0.canonical.csproj
dotnet sln %ZSln% add %ZApps%\capture\z0.capture.csproj
dotnet sln %ZSln% add %ZApps%\control\z0.control.csproj
dotnet sln %ZSln% add %ZApps%\cpu.dsl\z0.cpu.dsl.csproj
dotnet sln %ZSln% add %ZApps%\cpu.test\z0.cpu.test.csproj
dotnet sln %ZSln% add %ZApps%\evaluate\z0.evaluate.csproj
dotnet sln %ZSln% add %ZApps%\extract\z0.extract.csproj
dotnet sln %ZSln% add %ZApps%\gen\z0.gen.csproj
dotnet sln %ZSln% add %ZApps%\gen.shell\z0.gen.shell.csproj
dotnet sln %ZSln% add %ZApps%\glue\z0.glue.csproj
dotnet sln %ZSln% add %ZApps%\llvm.models\z0.llvm.models.csproj
dotnet sln %ZSln% add %ZApps%\llvm.tool\z0.llvm.tool.csproj
dotnet sln %ZSln% add %ZApps%\llvm.tools\z0.llvm.tools.csproj
dotnet sln %ZSln% add %ZApps%\logix.test\z0.logix.test.csproj
dotnet sln %ZSln% add %ZApps%\machine\z0.machine.csproj
dotnet sln %ZSln% add %ZApps%\machines\z0.machines.csproj
dotnet sln %ZSln% add %ZApps%\math.test\z0.math.test.csproj
dotnet sln %ZSln% add %ZApps%\res\z0.res.csproj
dotnet sln %ZSln% add %ZApps%\respack\z0.respack.csproj
dotnet sln %ZSln% add %ZApps%\run\z0.run.csproj
dotnet sln %ZSln% add %ZApps%\tools.shell\z0.tools.shell.csproj
dotnet sln %ZSln% add %ZApps%\workers\z0.workers.csproj
dotnet sln %ZSln% add %ZCore%\asm.models\z0.asm.models.csproj
dotnet sln %ZSln% add %ZCore%\lib\z0.lib.csproj
dotnet sln %ZSln% add %ZCore%\test\z0.test.csproj
dotnet sln %ZSln% add %ZCore%\tools\z0.tools.csproj
dotnet sln %ZSln% add %ZCore%\validity\z0.validity.csproj