## 堆排序/优先队列

有些情况下要求不一定要求数组全部有序，或者说不一定要一定性全部有序。 
有些情况下先收集一些元素，找到这些元素中的最大值，然后重复这个步骤。 
比如，电脑或手机上运行的多个应用程序，可以给每个程序分配一个优先队列，并总是处理下一个优先级最高的那个应用程序。

这就需要优先队列了，它支持这两种操作：
- 删除最大元素
- 插入元素

优先队列与队列（删除最老元素）和栈（删除最新元素）类似，但更高效。

二叉堆数据结构能够很好的实现优先队列的两种操作。二叉堆就像是一个完全二叉树。 
有序的堆能够保证父结点大于两个子结点，根结点是最大结点。 

![](https://algs4.cs.princeton.edu/24pq/images/heap-representations.png)

位置 k 的结点的父结点的位置是 k/2，而他的子结点的位置是 2k 和 2k+1。

我们用长度为 N+1 的数据 pq[] 来表示一个大小为 N 的堆，不使用 pq[0]（为了方便计算），所有堆元素放在 pq[1] 至 pq[N] 中。

首先将二叉堆排序：
- 从下至上的有序化（上浮）swim()
- 从上至下的有序化（下沉）sink()
如果堆的有序状态因为某个结点变得比它的父结点更大，那么就需要交换二者的顺序，以重新恢复堆的规则，直至小于其父结点。 

![](https://algs4.cs.princeton.edu/24pq/images/swim.png)

``` C#
public void swim(int k)
{
    while(k > 1 && k/2  < k)
    {
        exchange(k/2, k);
        k = k/2;
    }
}
```

如果堆的有序状态因为某个结点变得比它的两个子结点或是其中之一更小，那么就需要与两个子结点的较大者交换顺序，以重新恢复堆的规则，直至大于其子结点。 

![](https://algs4.cs.princeton.edu/24pq/images/sink.png)

``` C#
public void sink(int k)
{
    while(2*k < = N)
    {
        int j = 2*k;
        if(j < N && j < j+1)
        {
            j++;
        }
        if(k >= j)
        {
            break;
        }
        exchange(k, j);
        k = j;
    }
}
```

当插入元素时，我们将新元素加至数组末尾，改变堆的大小，然后让这个元素 swim 到合适的位置。 
此操作的比较次数不超过 lgN+1。

当删除最大元素时，我们从数组顶端删去最大元素，改变堆的大小，并将数组的最后一个元素放至顶端，然后让这个元素 sink 至合适的位置。 
此操作的比较次数不超过 2 * lgN。

![](https://algs4.cs.princeton.edu/24pq/images/heap-ops.png)

任意优先队列可以变成堆排序。堆排序可以分为两个阶段：
- 将数组构造成堆：从右至左用 sink() 函数构造子堆。
- 下沉排序，从堆中按递减顺序取出所有元素并排序。

``` C#
public void sort(int[] a)
{
    int N = a.Length;
    for(int k = N/2; k >= 1; k--)
    {
        sink(a[k]);
    }
    while(N > 1)
    {
        exchange(a[1], a[N--]);
        sink(a[1]);
    }   
}
```

上面的代码将 a[1] 到 a[N] 的元素进行排序，for 循环构造堆。while 循环把 a[1] 和 a[N] 交换并修复堆，直到堆变空。

![](https://algs4.cs.princeton.edu/24pq/images/heapsort-trace.png)

#### 常见题型：
- 从10亿个元素中找出最大的10个。
