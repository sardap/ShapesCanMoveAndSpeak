# ShapesCanMoveAndSpeak

## What

This is my OOP final project (2017). It's not really a game more of a demonstration of a bunch of mechanics cobbled together. 

Such as 
* Bridge pattern
	* Can render both using `swin game` or `splashkit`
* A Entity Component Structure 
	* Reusing coms as much as possible
* Quad trees
* Communication between ents
* Factories
* Some others

## Game?
![screenshot](example/shapes_move_speak_1.gif)
The game is it spawns a bunch of shapes with gold mines. Each shape cares about 3 things in a random amount Money, Age and size. They also have 3 colours chosen randomly. 

The more a shape cares about one of the 3 things the more it can be influenced by another shape if that shape has a greater amount of that thing. Example Shape A cares a lot about age is 23 and is red. Shape B cares a lot about age as well is 45 and is blue. when they are next to each other shape B will turn shape A blue over time. Because shape A cares about age and shape B is older. 

Shapes get money by being next to a gold mine. The bigger a shape is the faster it will mine.

The game ends when you close the program.

Here is a gif of it running it's bloody strange.
