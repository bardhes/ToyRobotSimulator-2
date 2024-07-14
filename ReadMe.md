﻿# Robot App

\############## <br/>
\#&nbsp;&nbsp; QUESTION 1 &nbsp;&nbsp;# <br/>
\##############

You are given a file like: `Sample.txt`

It starts by declaring a grid:

`GRID 4x3`

As you might expect this is a grid of 4 cells by 3 cells i.e.

+---+---+---+---+<br/>
&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|<br/>
+---+---+---+---+<br/>
&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|<br/>
+---+---+---+---+<br/>
&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|<br/>
+---+---+---+---+<br/>


The cells are numbered starting with zero.


&nbsp;  +---+---+---+---+<br/>
2 |&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|<br/>
&nbsp;  +---+---+---+---+<br/>
1 |&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|<br/>
&nbsp;  +---+---+---+---+<br/>
0 |&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|<br/>
&nbsp;  +---+---+---+---+<br/>
&nbsp;&nbsp;&nbsp;&nbsp; 0 &nbsp;&nbsp;&nbsp; 1 &nbsp;&nbsp;&nbsp; 2 &nbsp;&nbsp;&nbsp; 3

It contains zero to many (in this case 3) journeys. Here's the first one:

```
1 1 E
RFR
1 0 W
```

Each one starts with the initial coordinates of the robot (1,1) and the direction it is pointing in (`E`). The directions are as follows:

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`N` = North <br/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|<br/>
`W` = West  ---+--- `E` = East <br/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|<br/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`S` = South <br/>


So this robot starts here:

&nbsp;  +---+---+---+---+<br/>
2 |&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|<br/>
&nbsp;  +---+---+---+---+<br/>
1 |&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;>&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|<br/>
&nbsp;  +---+---+---+---+<br/>
0 |&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|<br/>
&nbsp;  +---+---+---+---+<br/>
&nbsp;&nbsp;&nbsp;&nbsp; 0 &nbsp;&nbsp;&nbsp; 1 &nbsp;&nbsp;&nbsp; 2 &nbsp;&nbsp;&nbsp; 3

Following the starting conditions are a list of commands:

`RFR`

Each character is a command, either to turn (`L` = left, `R` = right) or to move forwards (`F`).

The robot would therefore make the following movements.

Turn Right:

&nbsp;  +---+---+---+---+<br/>
2 |&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|<br/>
&nbsp;  +---+---+---+---+<br/>
1 |&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;v&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|<br/>
&nbsp;  +---+---+---+---+<br/>
0 |&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; New position: 1 1 S <br/> 
&nbsp;  +---+---+---+---+<br/>
&nbsp;&nbsp;&nbsp;&nbsp; 0 &nbsp;&nbsp;&nbsp; 1 &nbsp;&nbsp;&nbsp; 2 &nbsp;&nbsp;&nbsp; 3


Move Forward:

&nbsp;  +---+---+---+---+<br/>
2 |&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|<br/>
&nbsp;  +---+---+---+---+<br/>
1 |&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|<br/>
&nbsp;  +---+---+---+---+<br/>
0 |&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;v&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; New position: 1 0 S <br/> 
&nbsp;  +---+---+---+---+<br/>
&nbsp;&nbsp;&nbsp;&nbsp; 0 &nbsp;&nbsp;&nbsp; 1 &nbsp;&nbsp;&nbsp; 2 &nbsp;&nbsp;&nbsp; 3


Turn Right:

&nbsp;  +---+---+---+---+<br/>
2 |&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|<br/>
&nbsp;  +---+---+---+---+<br/>
1 |&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|<br/>
&nbsp;  +---+---+---+---+<br/>
0 |&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;<&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; New position: 1 0 W <br/> 
&nbsp;  +---+---+---+---+<br/>
&nbsp;&nbsp;&nbsp;&nbsp; 0 &nbsp;&nbsp;&nbsp; 1 &nbsp;&nbsp;&nbsp; 2 &nbsp;&nbsp;&nbsp; 3


Finally the journey ends with another set of coordinates and a direction. This is the expected position and orientation of your robot at the end of the journey. 
Your program should check that it ends at the specified coordinates and facing in the given direction.

The challenge is to parse the input file, set the start position of your robot, then have it execute the instructions and check its final position with the expected position.

- If at any point during its journey it leaves the grid boundary do not continue the journey and output `OUT OF BOUNDS`

- If the journey is completed and the final position and expected position match then output "SUCCESS" followed by the coordinates and direction, for example: `SUCCESS 1 1 E`

- If the journey is completed and the final position and expected position do not match then output "FAILURE" followed by the actual final coordinates and direction, for example: `FAILURE 1 1 E`

It should take the filename as an argument i.e. `RobotApp.exe Sample.txt`. It should handle invalid inputs gracefully.

The expected output for `Sample.txt` is:

```
SUCCESS 1 0 W
FAILURE 0 0 W
OUT OF BOUNDS
```

`Sample1.txt` contains some more complex journeys to process.


\##############<br/>
\# &nbsp; QUESTION 2 &nbsp;&nbsp;#<br/>
\##############<br/>

`Sample2.txt` starts with a grid declaration and then a number of lines of the form `OBSTACLE 1 2` these denote obstacles at specific coordinates. 
Obstacles are declared before any journeys.
Any obstacles declared elsewhere in the file should cause a parsing error to be displayed and the journeys in the file should not be executed.

A file containing the following text:

```
GRID 4x3

OBSTACLE 1 2 
OBSTACLE 3 1 

1 1 E
FF
1 0 W
```

would have the starting positions (`o` is an OBSTACLE):

&nbsp;  +---+---+---+---+<br/>
2 |&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;o&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|<br/>
&nbsp;  +---+---+---+---+<br/>
1 |&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;>&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;o&nbsp;&nbsp;|<br/>
&nbsp;  +---+---+---+---+<br/>
0 |&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|<br/> 
&nbsp;  +---+---+---+---+<br/>
&nbsp;&nbsp;&nbsp;&nbsp; 0 &nbsp;&nbsp;&nbsp; 1 &nbsp;&nbsp;&nbsp; 2 &nbsp;&nbsp;&nbsp; 3


Adjust your program so that any journey in a file with obstacles checks at each step that it has not collided with the obstacle. 
If it does then the output should be "CRASHED" followed by the coordinates, for example `CRASHED 3 1`

\##############<br/>
\# &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; NOTES &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; #<br/>
\##############<br/>

Write your code as though it was for a real project. Make it maintainable, readable and clean. 
Write unit tests and use a test framework of your choosing. 
You may use any of the LanguageExt nuget packages if you want although this is not mandatory.
Please do not use any other nuget packages.

Things we look for in submissions:

- Robust code that works
- Domain modelling, are you using primitive types or have you created nice structures to model the problem
- Well thought out unit tests
- Good separation of code, i.e. a parser distinct from the logic.
- Short, readable functions
- Minimal duplicate code
