Given an array of points where points[i] = [xi, yi] represents a point on the X-Y plane and an integer k, return the k closest points to the origin (0, 0).

The distance between two points on the X-Y plane is the Euclidean distance (i.e., √(x1 - x2)2 + (y1 - y2)2).

You may return the answer in any order. The answer is guaranteed to be unique (except for the order that it is in).

 

Example 1:


Input: points = [[1,3],[-2,2]], k = 1
Output: [[-2,2]]
Explanation:
The distance between (1, 3) and the origin is sqrt(10).
The distance between (-2, 2) and the origin is sqrt(8).
Since sqrt(8) < sqrt(10), (-2, 2) is closer to the origin.
We only want the closest k = 1 points from the origin, so the answer is just [[-2,2]].
Example 2:

Input: points = [[3,3],[5,-1],[-2,4]], k = 2
Output: [[3,3],[-2,4]]
Explanation: The answer [[-2,4],[3,3]] would also be accepted.
 

public class Solution {
    private class Point {
        public int[] point;
        int distance;
        public Point(int[] point, int distance) {
            this.point = point;
            this.distance = distance;
        }
    }

    public int[][] KClosest(int[][] points, int k) {
        if (points.Length == 0 || k == 0) {
            return new int[0][];
        }

        PriorityQueue<int[], int> queue = new PriorityQueue<int[], int>(Comparer<int>.Create((int x, int y) => y - x));
        for (int i = 0; i < points.Length; i++) {
            int distance = GetDistance(points[i]);
            if (queue.Count >= k && GetDistance(queue.Peek()) > distance) {
                queue.EnqueueDequeue(points[i], distance);
            }
            else if (queue.Count < k) {
                queue.Enqueue(points[i], distance);
            }
        }
        int j = 0;
        int[][] result = new int[k][];
        while (queue.Count > 0) {
            int[] point = queue.Dequeue();
            result[j] = new int[2];
            result[j][0] = point[0];
            result[j][1] = point[1];
            j++;
        }

        return result;
    }

    private int GetDistance(int[] point) {
        return (point[0] * point[0]) + (point[1] * point[1]);
    }
}
