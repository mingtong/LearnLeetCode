## Add two numbers

#### 描述： 
有两个非空链表，分别表示一个非负整数，位数是逆序的，比如： 
2->4->3 分别是个位，十位，百位。结果仍然是一个表示非负整数的链表。
```
Input: (2 -> 4 -> 3) + (5 -> 6 -> 4) 
Output: 7 -> 0 -> 8
```

#### 思路： 
因为结果仍然是位数逆序的，所以只需要像加法运算一样，从左到右依次相加两个链表即可。要注意的是：

两个链表位置不相等的情况。
需要进位的情况。特别是最高位还需要进位的情况。

#### 实现：
``` C#
public class Solution
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        ListNode dummyHead = new ListNode(0);
        ListNode runNode = dummyHead;
        int sum = 0;
        while (l1 != null || l2 != null || sum != 0)
        {
            if (l1 != null)
            {
                sum += l1.val;
                l1 = l1.next;
            }

            if (l2 != null)
            {
                sum += l2.val;
                l2 = l2.next;
            }

            runNode.next = new ListNode(sum % 10);
            runNode = runNode.next;
            sum /= 10; // 获取末位是否还需要进位。
        }

        return dummyHead.next;
    }
}
```

#### 总结：
这里用一个假的头结点来打头，也是一个常用的套路，以避免头结点的特殊处理。而巧妙的只需要一次循环就处理了3种特殊情况：
- 链表1 已经到头，而链表2 还未到头。
- 链表2 已经到头，而链表1 还未到头。
- 链表1，2 都已经到头，但还需要进位（新加一个结点）。

所以循环结束的条件也就是链表1，2都已经到头，且也不需要再进位。 
而 sum /= 10; 则可以巧妙的让 sum < 10 时， sum -> 0。

所以有几个特殊的边界case需要注意：
- [0] + [0]，返回 0；
- [5] + [5]，返回 [0, 1]；
- [1, 2, 3] + [1, 2, 7, 1]；位数不相等，且最后还要进位。
