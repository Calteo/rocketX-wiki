# Instructions

This page describes the various steps and tools to create the wiki.

# Process

Any commit on the MAIN branch triggers a build process that excutes the following steps:
1. Run a custom tool to create the table of content files (toc.yaml) in the wiki folder.
2. Run DocFX to transform the markdown in the folder wiki into html files.
3. Publish the html file at https://calteo.github.io/SpaceX-RUS-Wiki/

# Edit

## GitHub

Pages can be directly edited on this github site. 

### Advantages
- Easy to edit or quickly change files.

### Drawbacks
- The markdown rendering of github may differ from the real output created by DocFX.
- Every commit will trigger a new build. So for multiple changes it is better to create a new branch and push the results from that branch when all changes are made.
- No preview of the resulting wiki.

## Local

For a local editing you must have git installed an clone the respository. To run the local processing you need also DocFX and the .net runtime.

You can use chocolately to install git, docfx and other tools. Follow the instuctions to install chocolatey at https://chocolatey.org/install.
Start the install with
```
choco install git -y
choco install docfx -y
```
To keep everything up to date use `choco upgrade all -y`.

Make clone of the wiki to a folder of your choice: `git clone https://github.com/Calteo/SpaceX-RUS-Wiki`
This will create a folder `SpaceX-RUS-Wiki`. Change to the wiki folder with `cd SpaceX-RUS-Wiki\wiki`.

Now you can start editing the files and create new ones.

Use the tools to run the DocFX process on your local copy.
- Create the toc files: `..\Docfx.Helpers\Docfx.Create.Toc.exe`
- Run the watcher: `..\Docfx.Helpers\Docfx.Watcher.exe .`

New files have to be added to the repostory manually. 
This can be done with gui: `git gui`. You also need this to commit your changes locally and push them to repostiory on github.

# Tools

## DoxFX

## Docfx.Create.Toc

This tool scans all markdown files in a folder and creates the toc.yaml files. The creation is based upon the yaml header in the markdown files.

## Docfc.Watcher

This tool is used to local testing of the process. It watches a folder and on any change it rund DocFX locally an serves the resulting html file at http://localhost:8080. 
See runing the process locally.

