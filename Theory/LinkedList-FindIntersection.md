 ## 找到两个链表中的交点
 
 #### 单链表数据结构：
 ```
 //Definition for singly-linked list.
 public class ListNode 
 {
     public int val;
     public ListNode next;
     public ListNode(int x) { val = x; }
 }
```
#### 思路： 
注：此算法来自discuss区排第一名的一个比较巧妙的算法。 
同时遍历两个链表，当两个结点相同时，循环结束。

* 如果两个链表长度相同，且有交点，那么当遇到交点时，循环结束，即找到交点。只需要一次循环。
* 如果两个链表长度相同，没有交点，那么当遍历至尾结点的下一个结点时，两个结点都为空，循环结束，返回null。只需要一次循环。
* 如果两个链表长度不同，且有交点，那么在第一次遍历时肯定不会在交点处相遇，当更短的链表先到达尾结点时，切换到长链表，而长链表到达尾结点时也切换到短链表，这样两条路线遍历的长度相等，都是“长链表+短链表”的长度，则第二次遍历时即会相遇。
* 如果两个链表长度不同，没有交点，那么即使切换线路也永远不会相遇，但是两条路线遍历的长度相等，都是“长链表+短链表”的长度，则第二次遍历时，最终会同时到达各尾结点的下一个结点，即null，循环结束，返回null。

```
public ListNode getIntersectionNode(ListNode headA, ListNode headB)
{
    //boundary check
    if (headA == null || headB == null)
    {
        return null;
    }

    ListNode a = headA;
    ListNode b = headB;

    //如果a，b长度相同, 则第一次遍历时就会结束循环
    //如果a，b长度不同，则第二次遍历时会结束循环
    while (a != b)
    {
        //遍历结束时，互换方向，指向另一个链表的头结点
        a = a == null ? headB : a.next;
        b = b == null ? headA : b.next;
    }
    return a;
}
```
