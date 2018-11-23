```
 //Definition for singly-linked list.
 public class ListNode 
 {
     public int val;
     public ListNode next;
     public ListNode(int x) { val = x; }
 }
```

####
思路： 
相对简单，只要依次遍历两个链表，比较链表1和链表2当前结点值的大小来选择下一个结点取自链表1还是链表2，生成一个新的链表。 
要注意的情况是：
- 其中一个链表为空的情况，显然，那就不用合并了。
- 当其中一个链表已经为空时，将新链表的next指向另一条链表即可。

```
public ListNode MergeTwoLists(ListNode l1, ListNode l2)
{
    if (l1 == null)
    {
        return l2;
    }
    else if (l2 == null)
    {
        return l1;
    }

    ListNode dummy = new ListNode(0);
    ListNode runNode = dummy;

    //当遍历到其中一个链表为空时，结束循环
    while (l1 != null && l2 != null)
    {
        if (l1.val < l2.val)
        {
            runNode.next = l1;
            l1 = l1.next;
        }
        else
        {
            runNode.next = l2;
            l2 = l2.next;
        }
        runNode = runNode.next;
    }
    //处理情况2
    runNode.next = l1 != null ? l1 : l2;
    return dummy.next;
}
```
