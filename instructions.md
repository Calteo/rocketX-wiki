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

# Tools

## DoxFX

## Docfx.Create.Toc

This tool  scans all markdown files in a folder and creates the toc.yaml files. The creation is based upon the yaml header in the markdown files.

## Docfc.Watcher

This tool is used to local testing of the process. It watches a folder and on any change it rund DocFX locally an serves the resulting html file at http://localhost:8080. 
See runing the process locally.

