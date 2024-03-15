You are given an m x n grid rooms initialized with these three possible values.

-1 A wall or an obstacle.
0 A gate.
INF Infinity means an empty room. We use the value 231 - 1 = 2147483647 to represent INF as you may assume that the distance to a gate is less than 2147483647.
Fill each empty room with the distance to its nearest gate. If it is impossible to reach a gate, it should be filled with INF.

 

Example 1:


Input: rooms = [[2147483647,-1,0,2147483647],[2147483647,2147483647,2147483647,-1],[2147483647,-1,2147483647,-1],[0,-1,2147483647,2147483647]]
Output: [[3,-1,0,1],[2,2,1,-1],[1,-1,2,-1],[0,-1,3,4]]
Example 2:

Input: rooms = [[-1]]
Output: [[-1]]
 

Constraints:

m == rooms.length
n == rooms[i].length
1 <= m, n <= 250
rooms[i][j] is -1, 0, or 231 - 1.

class Solution:
    def wallsAndGates(self, rooms: List[List[int]]) -> None:
        """
        Do not return anything, modify rooms in-place instead.
        """
        gate, obstacle, empty_room = 0, -1, 2147483647

        rows, cols = len(rooms), len(rooms[0])

        empty_rooms = set()
        queue = collections.deque([])

        for row in range(rows):
            for col in range(cols):
                if rooms[row][col] == gate:
                    queue.append((row, col, 0))
                    empty_rooms.add((row, col))
                if rooms[row][col] == empty_room:
                    empty_rooms.add((row, col))
        
        while queue:
            row, col, distance = queue.popleft()
            if (row, col) in empty_rooms:
                rooms[row][col] = distance
                empty_rooms.remove((row, col))
                queue.append((row + 1, col, distance + 1))
                queue.append((row - 1, col, distance + 1))
                queue.append((row, col - 1, distance + 1))
                queue.append((row, col + 1, distance + 1))
