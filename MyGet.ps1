Get-ChildItem Env:


$dnxRoot = "C:\Users\Wonka\.dnx\runtimes\dnx-clr-win-x86.1.0.0-rc2-16357\bin"
$dnx = "$dnxRoot\dnx.exe"
$dnxTooling = "$dnxRoot\lib\Microsoft.Dnx.Tooling\Microsoft.Dnx.Tooling.dll"
 
& $dnx $dnxTooling restore ".\src\AutomaticSharp" -f "C:\Program Files (x86)\Microsoft Web Tools\DNU"

& $dnx --appbase ".\src\AutomaticSharp" $dnxTooling pack ".\src\AutomaticSharp" --configuration Release --out "..\..\artifacts\bin\AutomaticSharp"