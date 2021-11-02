---
uid: toc
title: Table of Content
---
# Table of Content
Each folder contains the table of content in an file ```toc.yml```. It describes what the navigation bars contains.

On the main page the navigations is rendered as a horizontal menu. In sub folders it is a bar in the left hand side that even supports searching.

Basic syntax:
```yml
- name: Overview
  href: index.md
- name: More Markdown
  href: markdown.md
- name: Pictures
  href: pictures.md
- name: References
  href: markdownref.md
- name: Table of Content
  href: tableOfContent/toc.yml
  topicHref: tableOfContent.md
```

Simple entries just contain a ```name``` and an ```href```. The last entry refers to another ```toc.yml``` from a sub folder. It gets included into this navigation bar. 
The ```topicHref``` give the link to the article on the entry his case.

Child entries can also created directly with:
```yml
- name: Page Title
  href: page.md
  items:
    - name: Child Page 1
      href: child1.md
    - name: Child Page 2
      href: child2.md
```

> [!NOTE]
> All article (``*.md``-files) are generated. Even if they are not in the table of contents. 
> They are simply not shown in the navigation, but can be opened by normal links. 
>
> Try this one --> @hiddentest.