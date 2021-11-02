# Adding a picture

Add an image into to folder `images`. Create it if it does not exist.

Input:
```
![SpaceX Logo][spaceX]

[spaceX]: images/spacex.png "SpaceX Tooltip"
```
Output:

![SpaceX Logo][spaceX]

[spaceX]: images/spacex.png "SpaceX Tooltip"

or input:
```
![SpaceX Logo](images/spacex.png "SpaceX Tooltip")
```
Output:

![SpaceX Logo](images/spacex.png "SpaceX Tooltip")

<!---
Just a comment into the output file.
-->

Also works in tables :smile:

|Column 1|Column 2|
|:------:|:-------:|
|![SpaceX Logo](images/spacex.png "SpaceX Tooltip1")|![SpaceX Logo](images/spacex.png "SpaceX Tooltip2")|
