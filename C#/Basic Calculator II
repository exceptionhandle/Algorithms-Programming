Given a string s which represents an expression, evaluate this expression and return its value. 

The integer division should truncate toward zero.

You may assume that the given expression is always valid. All intermediate results will be in the range of [-231, 231 - 1].

Note: You are not allowed to use any built-in function which evaluates strings as mathematical expressions, such as eval().

 

Example 1:

Input: s = "3+2*2"
Output: 7
Example 2:

Input: s = " 3/2 "
Output: 1
Example 3:

Input: s = " 3+5 / 2 "
Output: 5
 

Constraints:

1 <= s.length <= 3 * 105
s consists of integers and operators ('+', '-', '*', '/') separated by some number of spaces.
s represents a valid expression.
All the integers in the expression are non-negative integers in the range [0, 231 - 1].
The answer is guaranteed to fit in a 32-bit integer.


public class Solution {
    
    public int Calculate(string s) {
        int length = s.Length;
        if (length == 0) {
            return 0;
        }

        int currentNum = 0;
        int lastNumber = 0;
        int result = 0;

        char sign = '+';
        for (int i = 0; i < length; i++) {
            char currentChar = s[i];
            if (IsDigit(currentChar)) {
                currentNum = (currentNum * 10) + (currentChar - '0');
            }
            if (!IsDigit(currentChar) && currentChar != ' ' || i == length - 1 ) {
                if (sign == '+' || sign == '-') {
                    result += lastNumber;
                    lastNumber = (sign == '+') ? currentNum : -currentNum;
                }
                else if (sign == '*') {
                    lastNumber = lastNumber * currentNum;
                }
                else if (sign == '/') {
                    lastNumber = lastNumber / currentNum;
                }

                sign = currentChar;
                currentNum = 0;
            }
        }

        result += lastNumber;
        return result;
    }

    private int PerformCalculation(int d1, int d2, char op) {
        if (op == '+') {
            return d1 + d2;
        }
        else if (op == '-') {
            return d1 - d2;
        }
        else if (op == '*') {
            return d1 * d2;
        }
        else if (op == '/') {
            return d1 / d2;
        }
        return 1;
    }

    private int PerformMultiplyDivide(int d1, int d2, char op) {
        if (op == '*') {
            return d1*d2;
        }
        return d1/d2;
    }

    private bool IsDigit(char c) {
        return c >= '0' && c <= '9';
    }

    private bool IsMultiplyDivide(char c) {
        return (c == '*' || c == '/');
    }

    private bool IsOperator(char c) {
        return (c == '+' || c == '-' || c == '*' || c == '/');
    }
}
