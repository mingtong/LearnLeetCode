
```
 //Definition for singly-linked list.
 public class ListNode 
 {
     public int val;
     public ListNode next;
     public ListNode(int x) { val = x; }
 }
```

有两个指针快慢套跑遍历，快指针每次走两格，慢指针每次走一格，当快慢指针相遇时，即有环。如果快指针走到末尾（循环结束）都没有相遇，则无环。

```
public bool HasCycle(ListNode head)
{
    if (head == null)
    {
        return false;
    }

    ListNode slow = head;
    ListNode fast = head;

    while (fast.next != null && fast.next.next != null)
    {
        slow = slow.next;
        fast = fast.next.next;
        if (slow == fast)
        {
            return true;
        }
    }
    return false;
}
```
