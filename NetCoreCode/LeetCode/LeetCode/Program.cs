using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class MyLinkedList {
    class ListNode{
        public ListNode next;
        public int val;
        public ListNode(int val)
        {
            this.val = val;
        }
    }
    
    ListNode head;
    int Length;
    /** Initialize your data structure here. */
    public MyLinkedList() {
        head = null;
        Length = 0;
    }
    
    /** Get the value of the index-th node in the linked list. If the index is invalid, return -1. */
    public int Get(int index) {
        if(index > Length-1)
        {
            return -1;
        }
        var runNode = head;
        for(int i = 0; i < index; i++)
        {
            runNode = runNode.next;
        }
        return runNode.val;
    }
    
    /** Add a node of value val before the first element of the linked list. After the insertion, the new node will be the first node of the linked list. */
    public void AddAtHead(int val) {
        AddAtIndex(0, val);
    }
    
    /** Append a node of value val to the last element of the linked list. */
    public void AddAtTail(int val) {
        AddAtIndex(Length, val);
    }
    
    /** Add a node of value val before the index-th node in the linked list. If index equals to the length of linked list, the node will be appended to the end of linked list. If index is greater than the length, the node will not be inserted. */
    public void AddAtIndex(int index, int val) {
        if(index > Length)
        {
            return;
        }
        else if(index == Length && head!=null) //tail
        {
            var runNode = head;
            for(int i = 1; i < index-1; i++)
            {
                runNode = runNode.next;
            }
            var newNode = new ListNode(val);
            runNode.next = newNode;
        }
        else
        {
            if(index == 0) //head
            {
                if(head == null)
                {
                    head = new ListNode(val);
                }
                else
                {
                    var newNode = new ListNode(val);
                    newNode.next = head;
                }    
            }
            else
            {
                var runNode = head;
                for(int i = 1; i < index-1; i++)
                {
                    runNode = runNode.next;
                }
                var newNode = new ListNode(val);
                newNode.next = runNode.next;
                runNode.next = newNode;
                
            }
        }
        Length++;
    }
    
    /** Delete the index-th node in the linked list, if the index is valid. */
    public void DeleteAtIndex(int index) {
        if(index < 0 || index > Length-1)
        {
            return;
        }
        if(index == 0)
        {
            head = head.next;
            Length--;
            return;
        }
        var runNode = head;
        for(int i = 0; i < index-1; i++)
        {
            runNode = runNode.next;
        }        
        runNode.next = runNode.next.next;
        Length--;
    }
}
    
    class Program
    {
        static void Main(string[] args)
        {
//            var dp = new DP();
//            var v = dp.MaxSubArray();
//            Console.WriteLine(v);
            Trie trie = new Trie();          
            trie.Insert("apple");
            trie.Search("apple");   // returns true
            trie.Search("app");     // returns false
            trie.StartsWith("app"); // returns true
            trie.Insert("app");   
            trie.Search("app");     // returns true
        }

        private static TreeNode BuildTree()
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            //root.right = new TreeNode(3);

//            root.left.left = new TreeNode(4);
//            root.left.right = new TreeNode(5);
//            root.right.left = new TreeNode(6);
            return root;
        }
        
        public static string ReverseOnlyLetters(string S) {
            if(string.IsNullOrEmpty(S))
            {
                return S;
            }

            var stack = new Stack<string>();
            var queue = new Queue<int>();
            for(int i = 0; i < S.Length; i++)
            {
                if(S[i] != '-')
                {
                    stack.Push(S[i].ToString());
                }
                else
                {
                    queue.Enqueue(i);
                }
            }
        
            var result = new StringBuilder();
            //int qCount = queue.Count;
            while(queue.Count > 0)
            {
                int len = queue.Dequeue();
                for(int j = 0; j < len; j++)
                {
                    result.Append(stack.Pop());
                }
                result.Append("-");
            }
            while(stack.Count > 0)
            {
                result.Append(stack.Pop());
            }
            return result.ToString();
        }
    }
}