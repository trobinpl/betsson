Escape Mines - Paweł Hemperek - README

Hi!
I've decided to write this short README file, because I felt the need to talk about some design decisions and assumptions I've made when implementing the escape of our brave turtle out of mine field!

Assumptions
-----------
Since in the provided example there is 5x4 board with turtle starting on position (1,0) and exit point at (2,4) grid is as follows
+-------+-------+-------+-------+-------+
| (0,0) | (0,1) | (0,2) | (...) | (0,n) |
+-------+-------+-------+-------+-------+
| (1,0) |       |       |       |       |
+-------+-------+-------+-------+-------+
| (2,0) |       |       |       |       |
+-------+-------+-------+-------+-------+
| (...) |       |       |       |       |
+-------+-------+-------+-------+-------+
| (m,0) |       |       |       |       |
+-------+-------+-------+-------+-------+
It was a little bit confusing since (0,0) should be in the down left corner, but I assumed that's "business requirement" to have starting point in the left top corner.

============

It's impossible for turtle to make move resulting him going outside of board. If the sequence of moves leads to such move it won't have any consequences (position or direction of turtle will not change)

============

I wanted to implement some settings validation inside my solution so I assumed that mine can't lay on the exit point, none of the points can be outside of declared board and in order to make settings valid there must be also any moves declared

============

With every new series of moves turtle begins from scratch (his original starting position).

General thoughts
----------------
I tried to create solution as simple as possible and reuse some basic concepts to model bigger ones. I could model the minefield creating two-dimensional array of size n x m, but that would result in lower testability and also wouldn't scale with increasing board size.

I'm certain that there are some parts of the code that could be more polished. I did not aim to write "ideal" code. Obviously I wanted to show you that I can solve this problem nicely, but also leave it in a state where it can somehow reflect code I would actually write on my day-to-day job. So it's a little bit "real world"-ish ;-)

I also tried to have test coverage as high as possible, but I didn't use any tools that would measure that for me. I wrote tests for methods I thought they should be tested and did not try to write tests just for the sake of covering absolutely every line.

I hope most of my design decisions are clear! I'm looking forward to discussing any doubts you might have during technical interview! :-)
