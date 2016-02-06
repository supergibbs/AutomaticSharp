#This should work but it's not installed properly
#$dnxRoot = [regex]::match($env:PATH,'([^;]+\\\.dnx\\runtimes\\[^;]+\\bin);').Groups[1].Value

$dnxRoot = $dnxRoot = "C:\Users\Wonka\.dnx\runtimes\dnx-clr-win-x86.1.0.0-rc2-16357\bin"
$dnx = "$dnxRoot\dnx.exe"
$dnxTooling = "$dnxRoot\lib\Microsoft.Dnx.Tooling\Microsoft.Dnx.Tooling.dll"
 
& $dnx $dnxTooling restore ".\src\AutomaticSharp"
