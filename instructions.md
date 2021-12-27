# Instructions

This page describes the various steps and tools to create the wiki.

# Process

Any commit on the MAIN branch triggers a build process ([Create-Wiki](.github/wolkflows/main.yml) action) that excutes the following steps:
1. Stamp the current time into the pages.
2. Run DocFX to transform the markdown in the folder wiki into html files.
3. Publish the html file at https://calteo.github.io/rocketX-wiki/

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

For a local editing you must have git installed an clone the respository. To run the local processing you need also DocFX.

You can use chocolately to install git, docfx and other tools. Follow the instuctions to install chocolatey at https://chocolatey.org/install.
Start the install with
```
choco install git -y
choco install docfx -y
```
To keep everything up to date use `choco upgrade all -y`.

Make clone of the wiki to a folder of your choice: `git clone https://github.com/Calteo/rocketX-wiki`
This will create a folder `rocketX-wiki`. Change to the wiki folder with `cd rocketX-wiki\wiki`.

Now you can start editing the files and create new ones.

New files have to be added to the repostory manually. 
This can be done with gui: `git gui`. You also need this to commit your changes locally and push them to repostiory on github.

# Tools

## DoxFX

You can run the docfx tool to generate the html pages locally and test them before commit.

Open a command line and use the 