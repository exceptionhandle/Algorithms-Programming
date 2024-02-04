/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    List<int> numbers = new List<int>();
    public int SumNumbers(TreeNode root) {
        TraverseTree(root, 0);

        int result = 0;
        foreach (var number in numbers) {
            result += number;
        }

        return result;
    }

    private void TraverseTree(TreeNode root, int number) {
        if (root == null) {
            return;
        }

        number = number * 10 + root.val;
        if (root.left == null && root.right == null) {
            numbers.Add(number);
            return;
        }

        if (root.left != null) {
            TraverseTree(root.left, number);
        }
        if (root.right != null) {
            TraverseTree(root.right, number);
        }
    }
}
