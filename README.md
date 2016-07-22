# Maze 

The Maze it is an application which demonstrate the pathfinding algorithm. The maze map is loaded from a file in the following format.

``` 
____G__X
___XXX__
X______X
__XXXX__
___X____
__S__X__
```

where
 - S: Start Point
 - G: Goal Point
 - _: Empty Point
 - X: Wall Point
 
### Path finding algorithm
The technique used for this demonstration is called "Breadth-First Search".
Basically means we are going to check every possible path of length 1, then every possible path of length 2 and so on until we find the shortest path that will take us from [StartPoint] to [GoalPoint]

Details and implemetation of the technique found at the article [A Basic Path Finding algorithm](http://gregtrowbridge.com/a-basic-pathfinding-algorithm/)

### Project Strucure
* [Maze.ConsoleApp](https://github.com/klimisa/Maze/tree/master/Maze.ConsoleApp)
* [Maze.Application](https://github.com/klimisa/Maze/tree/master/Maze.Application)
* [Maze.Domain](https://github.com/klimisa/Maze/tree/master/Maze.Domain)
* [Maze.Domain.Tests](https://github.com/klimisa/Maze/tree/master/Maze.Domain.Tests)
* [Maze.Repository](https://github.com/klimisa/Maze/tree/master/Maze.Repository)

###### ConsoleApp
This is the entry point of the program which responsibilities are 
 - To supply with a file path to the underlying path finder service
 - To display the actors route

###### Application
Here is the service which cordinates the path finding by the folowing steps 
 - Get the Maze map for a file path.
 - Supply the map to the route discovery domain service
 - Watch for result and return the Actor's Route
 
###### Domain
The domain layer is responsible for supplying the Algorithm Strategy and has the objects are necessary to perform the actor's route finding.
Here concepts emerges like,
 - [Start Point](https://github.com/klimisa/Maze/blob/master/Maze.Domain/Points/StartPoint.cs)
 - [Goal Point](https://github.com/klimisa/Maze/blob/master/Maze.Domain/Points/GoalPoint.cs)
 - [Empty Point](https://github.com/klimisa/Maze/blob/master/Maze.Domain/Points/EmptyPoint.cs)
 - [Wall Point](https://github.com/klimisa/Maze/blob/master/Maze.Domain/Points/WallPoint.cs)
 - [Square](https://github.com/klimisa/Maze/blob/master/Maze.Domain/PathFinder/Square.cs)

###### Repositoty
This layer is resposible to read the file with the Maze map and transform it to a [MazeMap](https://github.com/klimisa/Maze/blob/master/Maze.Domain/Service/MazeMap.cs) object.

### Improvement
 - Algorithm Refactoring towards simpler design
 - Perfomance tunning using for ex. linked lists and trees.


### External Sources
  - [NUnit](https://www.nuget.org/packages/NUnit/)
