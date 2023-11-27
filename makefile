linux:
	dotnet publish src/ModernCCompiler/ModernCCompiler.sln -p:PublishProfile=Linux
	cp publish/linux/mcc mcc
windows:
	dotnet publish src/ModernCCompiler/ModernCCompiler.sln -p:PublishProfile=Windows
	cp publish/windows/mcc.exe mcc.exe
clean:
	rm -f mcc.exe mcc
	rm -f publish/linux/*
	rm -f publish/windows/*
