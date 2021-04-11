#
# uploads a documetation folder to the gh_branch
#
[CmdletBinding()]
Param
  (    
    [parameter(Mandatory=$true,Position=1)]
    [String]$SiteFolder,
    [parameter(Mandatory=$true,Position=2)]
    [String]$Project,
	[parameter(Mandatory=$true,Position=3)]
    [String]$User,
	[parameter(Mandatory=$true,Position=4)]
    [String]$EMail,	
	[parameter(Mandatory=$true,Position=5)]
    [String]$Token
  )

function Invoke-git
{
    param([Parameter(Mandatory,Position=0)][string] $Command)

    $output = Invoke-Expression "git $Command 2>&1"
    if ( $LASTEXITCODE -gt 0 )
    {
        throw "error executing (RC=$LASTEXITCODE): git $Command"
    }
    else
    {
        $output | Write-Host 
    }
}

Write-Host -ForegroundColor Cyan "init git"
git config --global credential.helper store
Add-Content "$env:USERPROFILE\.git-credentials" "https://$($Token):x-oauth-basic@github.com`n"
git config --global user.email $EMail
git config --global user.name $User

git config --global core.autocrlf false

$source=$pwd
$repro=[System.IO.Path]::GetFullPath("$pwd\..\$Project-Documentation")

Write-Host -ForegroundColor Cyan "removing doc directory $repro"
rm $repro -Force -Recurse -ErrorAction SilentlyContinue
Write-Host -ForegroundColor Cyan "create doc directory $repro"
mkdir $repro | Out-Null

$url = "https://github.com/$User/$Project.git"
Write-Host -ForegroundColor Cyan "cloning the repo $url with the gh-pages branch"

Invoke-Git "clone $url --branch gh-pages $repro"

Write-Host -ForegroundColor Cyan "clear repo directory"
cd $repro
git rm -r *

Write-Host -ForegroundColor Cyan "copy documentation into the repo"
cp -r "$source\$SiteFolder\*" .

Write-Host -ForegroundColor Cyan "push the new docs to the gh-pages branch"
git add . -A
git commit -m "update generated documentation"
Invoke-Git "push origin gh-pages"

cd $source