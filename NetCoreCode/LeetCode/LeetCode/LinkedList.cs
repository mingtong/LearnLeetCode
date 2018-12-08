using System.Runtime;
using System.Collections.Generic;
using System.Collections;

namespace LeetCode
{
    public class LinkedList
    {
        ListNode root;

        public LinkedList()
        {
        }

        /// <summary>
        /// #237 Delete the node in the LinkedList
        /// </summary>
        /// <param name="node">node</param>
        public void DeleteNode(ListNode node)
        {
            if (node == null) 
            {
                return;
            }
            node.val = node.next.val;
            node.next = node.next.next;
        }

        /// <summary>
        /// #19 Delete the n-th node from tail of the LinkedList
        /// </summary>
        /// <param name="head"></param>
        /// <param name="n"></param>
        public ListNode DeleteNodeFromTail(ListNode head, int n)
        {
            if (head == null || head.next == null)
            {
                return null;
            }

            ListNode slow = head;
            ListNode fast = head;
            int length = 1;
            for (int i = 0; i < n; i++)
            {
                fast = fast.next;
                if (fast == null)
                {
                    return head.next;
                }

                length++;
            }

            while (fast.next != null)
            {
                fast = fast.next;
                slow = slow.next;
                length++;
            }

            if (n == length)
            {
                return head.next;
            }

            slow.next = slow.next.next;
            return head;
        }

        /// <summary>
        /// #21 Merge Two Sorted Lists
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null)
            {
                return l2;
            }

            if (l2 == null)
            {
                return l1;
            }

            ListNode dummy = new ListNode(0);
            ListNode runNode = dummy;

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

            runNode.next = l1 != null ? l1 : l2;
            return dummy.next;
        }

        /// <summary>
        /// #83 Delete duplicated nodes
        /// the two nodes are neighbor
        /// </summary>
        public ListNode DeleteDuplicated(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            ListNode runNode = head;
            while (runNode != null && runNode.next != null)
            {
                if (runNode.val == runNode.next.val)
                {
                    runNode.next = runNode.next.next;
                }
                else
                {
                    runNode = runNode.next;
                }
            }

            return head;
        }

        /// <summary>
        /// #82 Delete duplicated nodes
        /// the two nodes are everywhere
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode DeleteDuplicated2(ListNode head)
        {
            //use two pointers, slow - track the node before the dup nodes, 
            // fast - to find the last node of dups.
            ListNode dummy = new ListNode(0);
            ListNode fast = head;
            ListNode slow = dummy;
            slow.next = fast;

            while (fast != null)
            {
                while (fast.next != null && fast.val == fast.next.val)
                {
                    //while loop to find the last node of the dups.
                    fast = fast.next;
                }

                //duplicates detected.
                if (slow.next != fast)
                {
                    slow.next = fast.next; //remove the dups.
                    fast = slow.next; //reposition the fast pointer.
                }
                else
                {
                    //no dup, move down both pointer.
                    slow = slow.next;
                    fast = fast.next;
                }
            }

            return dummy.next;
        }

        /// <summary>
        /// #203 Insert a new node to the n-th pos of the LinkedList
        /// </summary>
        /// <param name="head"></param>
        /// <param name="val"></param>
        public ListNode InsertNode(ListNode head, int val)
        {
            if (head != null && head.val == val)
            {
                return head.next;
            }

            ListNode runNode = head;

            while (runNode != null && runNode.next != null)
            {
                if (runNode.next.val == val)
                {
                    runNode.next = runNode.next.next;

                    break;
                }

                runNode = runNode.next;
            }

            return head;
        }

        /// <summary>
        /// #206 Reverse LinkedList
        /// </summary>
        public ListNode ReverseIteratively(ListNode head)
        {
            if (head == null)
            {
                return null;
            }

            ListNode runNode = head;
            ListNode dummy = new ListNode(-1);
            dummy.next = head;
            while (runNode != null)
            {
                runNode.next = dummy.next;
                dummy.next = runNode;
                runNode = runNode.next;
            }

            return dummy.next;
        }
        
        /// <summary>
        /// #92 Reverse Linked List (between [m, n])
        /// </summary>
        /// <param name="head"></param>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public ListNode ReverseBetween(ListNode head, int m, int n) {
            ListNode dummyhead = new ListNode(0);
            dummyhead.next = head;
        
            ListNode sublisthead = new ListNode(0);
            ListNode sublisttail = new ListNode(0);
            int count = 1;
        
            ListNode pre_cur = dummyhead;
            ListNode cur = head;
            while(count <= n){
                ListNode temp = cur.next;
                if (count < m)
                    pre_cur = cur;
                else if (count == m){
                    sublisttail = cur;
                    sublisthead.next = cur;
                }else if (count > m){
                    cur.next = sublisthead.next;
                    sublisthead.next = cur;
                }
                cur = temp;
                ++count;
            }
            pre_cur.next = sublisthead.next;
            sublisttail.next = cur;
            return dummyhead.next;        
        }

        /// <summary>
        /// #141 If has circle?
        /// </summary>
        /// <returns></returns>
        public bool HasCircle(ListNode head)
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

        /// <summary>
        /// #142 If has circle? then find the circle start point
        /// </summary>
        /// <returns></returns>
        public ListNode HasCircle2(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;

            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;

                if (slow != fast)
                {
                    continue;
                }

                while (head != slow)
                {
                    head = head.next;
                    slow = slow.next;
                }

                return slow;
            }

            return null;
        }

        /// <summary>
        /// #234 is Palindrome Linked List?
        /// </summary>
        /// <returns></returns>
        public bool IsPalindrome(ListNode head)
        {
            if(head == null) {
                return true;
            }
            ListNode p1 = head;
            ListNode p2 = head;
            ListNode p3 = p1.next;
            ListNode pre = p1;
            //find mid pointer, and reverse head half part
            while(p2.next != null && p2.next.next != null) {
                p2 = p2.next.next;
                pre = p1;
                p1 = p3;
                p3 = p3.next;
                p1.next = pre;
            }

            //odd number of elements, need left move p1 one step
            if(p2.next == null) {
                p1 = p1.next;
            }
            else {   //even number of elements, do nothing
            
            }
            //compare from mid to head/tail
            while(p3 != null) {
                if(p1.val != p3.val) {
                    return false;
                }
                p1 = p1.next;
                p3 = p3.next;
            }
            return true;
        }
        /// <summary>
        /// #234 is Palindrome Linked List?
        /// using reverse
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool IsPalindromeReversely(ListNode head)
        {
            if(head == null)
            {
                return true;
            }
        
            ListNode slow = head;
            ListNode fast = head;
        
            while(fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }
        
            if(fast != null)
            {
                slow = slow.next;
            }
        
            slow = reverse(slow);
            fast = head;
        
            while(slow != null)
            {
                if(fast.val != slow.val)
                {
                    return false;
                }
                fast = fast.next;
                slow = slow.next;            
            }
        
            return true;
        }
        private ListNode reverse(ListNode head) {
            ListNode prev = null;
            while (head != null) {
                ListNode next = head.next;
                head.next = prev;
                prev = head;
                head = next;
            }
            return prev;
        }  

        /// <summary>
        /// #2 Add two number in linked list
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode head = new ListNode(0);
            bool isAdd = false;

            ListNode runNode = head;

            while (l1 != null || l2 != null || isAdd)
            {
                int val = (l1 != null ? l1.val : 0)
                          + (l2 != null ? l2.val : 0)
                          + (isAdd ? 1 : 0);
                isAdd = val / 10 > 0;
                val = val % 10;
                runNode.next = new ListNode(val);
                runNode = runNode.next;
                l1 = l1 != null ? l1.next : null;
                l2 = l2 != null ? l2.next : null;
            }

            return head.next;
        }
        
        /// <summary>
        /// #445 Add Two Numbers II
        /// digit is opposite
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode AddTwoNumbers2(ListNode l1, ListNode l2) {
            if(l1 == null)
            {
                return l2;
            }
            if(l2 == null)
            {
                return l1;
            }
            ListNode r1 = l1;
            ListNode r2 = l2;
        
            Stack<ListNode> stack1 = new Stack<ListNode>();
            Stack<ListNode> stack2 = new Stack<ListNode>();
        
            while(r1 != null || r2 != null)
            {
                if(r1!=null) 
                {
                    stack1.Push(r1);
                    r1 = r1.next;
                }
                if(r2!=null) 
                {
                    stack2.Push(r2);
                    r2 = r2.next;
                }
            }
        
            ListNode newHead = null;
            bool curry = false;
        
            while(stack1.Count>0 || stack2.Count>0)
            {
                int val = 0;
                if(stack1.Count>0)
                {
                    val += stack1.Pop().val;
                }
                if(stack2.Count>0)
                {
                    val += stack2.Pop().val;
                }
                if(curry)
                {
                    val++;
                }
                curry = (val >= 10);
                ListNode newNode = new ListNode(val%10);
                newNode.next = newHead;
                newHead = newNode;
            }
            if(curry)
            {
                ListNode newNode = new ListNode(1);
                newNode.next = newHead;
                newHead = newNode;            
            }
        
            return newHead;
        }
        /// <summary>
        /// #61 Rotate k places(k times to right)
        /// </summary>
        /// <param name="head"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public ListNode RotateRight(ListNode head, int k) {
            if (head == null || head.next == null) 
            {
                return head;
            }
        
            ListNode dummy = new ListNode(0);
            dummy.next = head;
            ListNode fast = dummy;
            ListNode slow = dummy;

            int i;
            for (i = 0; fast.next != null; i++)//Get the total length
            {
                fast=fast.next;
            }

            for (int j = i - k % i; j > 0; j--) //Get the i-n%i th node
            {
                slow = slow.next;
            }           

            fast.next = dummy.next; //Do the rotation
            dummy.next = slow.next;
            slow.next = null;

            return dummy.next;
        }
        
        /// <summary>
        /// #24 swap nodes in pair
        /// 1-2-3-4 to 2-1-4-3
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode SwapPairs(ListNode head) {
            if(head == null)
            {
                return null;
            }
        
            ListNode dummyHead = new ListNode(0);
            dummyHead.next = head;
        
            ListNode runNode = dummyHead;
            while(runNode.next != null &&　runNode.next.next != null)
            {
                ListNode first = runNode.next;
                ListNode second = runNode.next.next;
                first.next = second.next;
                runNode.next = second;
                runNode.next.next = first;
                runNode = runNode.next.next;
            }
            return dummyHead.next;
        }

        /// <summary>
        /// #328 Odd Even Linked List
        /// 1-2-3-4-5-6 to 1-3-5-2-4-6
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode OddEvenList(ListNode head)
        {
            if(head == null || head.next == null || head.next.next == null)
            {
                return head;
            }
        
            ListNode oddHead = head;
            ListNode evenHead = head.next;
        
            ListNode odd = oddHead;
            ListNode even = evenHead;
        
            while(odd != null && odd.next != null && odd.next.next != null)
            {
                odd.next = odd.next.next;
                even.next = even.next.next;
                odd = odd.next;
                even = even.next;
            }

            odd.next = evenHead;
            return oddHead;
        }

        /// <summary>
        /// #86 Partition List, split by value
        /// 1->4->3->2->5->2, x = 3 to 1->2->2->4->3->5
        /// </summary>
        /// <param name="head"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public ListNode Partition(ListNode head, int x)
        { //dummy heads of the 1st and 2nd queues
            ListNode dummy1 = new ListNode(0);
            ListNode dummy2 = new ListNode(0);  
        
            //current tails of the two queues;
            ListNode curr1 = dummy1;
            ListNode curr2 = dummy2;  
        
            while(head != null){
                if(head.val < x) 
                {
                    curr1.next = head;
                    curr1 = head;
                }
                else 
                {
                    curr2.next = head;
                    curr2 = head;
                }
                head = head.next;
            }
            curr2.next = null;          
            //important! avoid cycle in linked list. otherwise u will get TLE.
            curr1.next = dummy2.next;
            return dummy1.next;
        }
    }
}