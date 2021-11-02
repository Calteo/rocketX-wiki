---
uid: instructions
title: Instructions
---
# Instructions

## Introduction
These pages help to author articles for the wiki. The source is stored on [github](https://github.com/Calteo/rocketX-wiki).
All edits go into this repository. On a succesful commit a github action is triggered to transform the source into a static web page.
The resuling page is hosted on [github pages](https://github.com/Calteo/rocketX-wiki).

## Transformation

The transformation uses a tool [DocFX](https://dotnet.github.io/docfx/). 
It uses markdown as source for texts and YML ands JSON files for configuration. 
This instruction tries to make authoring as simple as possible. 

# Markdown
Markdown is a simple text syntax to allow basic formatting. An overiew can be found with examples on [wikipedia](https://en.wikipedia.org/wiki/Markdown).
DocFX extends this markdown with some small features described later.

## Formatting

### Text
Text is simply outputted as text. Extra spaces and line breaks are ignored. For a new paragraph an extra emtpy line is needed.

Input:
```tex
Here  is a   example    with extra spaces.
And a line break.

New paragraph begins here.
```
Output:

Here  is a   example    with extra spaces.
And a line break.

New paragraph begins here.

### Styles
Basic styles are also supported

Input:
```tex
Normal, *Italics*, **Bold** and ***Both***
```
Output:

Normal, *Italics*, **Bold** and ***Both***

### Enumerations
Enumeraions are easy

Input:
```tex
- First
- Second
- Third
```
Output:

- First
- Second
- Third

Or numbered

Input:
```tex
1. First
2. Second
3. Third
```
Output:

1. First
2. Second
3. Third