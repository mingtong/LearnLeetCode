## 快速排序

快速排序是应用最广泛的排序算法之一，流行的原因是它实现简单，而且是原地排序（只需要一个很小的辅助栈），缺点是非常脆弱，实现时要非常小心才能避免性能问题。

快速排序同样也是一种分治的排序算法，将一个数组分成两个子数组，两部分独立地排序。

合并排序把数组分成两个数组分别排序再合并，而快速排序的方式是两个子数组都有序时整个数组也就有序了。 
合并排序按数量将数组分成两半，快速排序按大小将数组分成两半。

```
public void QuickSort(int[] a, int low, int high)
{
    if(high >= low)
    {
        return;
    }
    int j = Partition(a, low, high); //切分数组
    sort(a, low, j-1); //将小于a[j]的部分进行排序
    sort(a, j+1, high); //将大于a[j]的部分进行排序
}
```

![](https://algs4.cs.princeton.edu/23quicksort/images/partitioning.png)

切分过程
```
public int Partition(int[] a, int low, int high)
{
    int i = low;
    int j = high + 1;
    int v = a[low]; //将第一个元素作为切分元素
    while(true)
    {
        //依次扫描左右，检查是否扫描结束
        while(a[++j] < v)
        {
            if(i == high)
            {
                break;
            }
        }
        while(v < a[--j])
        {
            if(j == low)
            {
                break;
            }
        }
        if(i >= j)
        {
            break;
        }       
        exchange(a[i], a[j]); //将 v = a[j]放入正确的位置
    }
    return j;
}
```

Dijkstra提出的三向切分法：
```
public void sort(int[] a, int low, int high)
{
    if(high >= low)
    {
        return;
    }
    int lt = low;
    int i = low+1;
    int gt = high;
    int v = a[low]; //切分元素
    while(i <= gt)
    {
        if(a[i] < v)
        {
            exchange(a[lt++], a[i++]);
        }
        else if(a[i] > v)
        {
            exchange(a[i]; a[gt--]);
        }
        else
        {
            i++;
        }
    }
    sort(a, low, lt-1);
    sort(a, gt+1, high);
}
```

![](https://algs4.cs.princeton.edu/23quicksort/images/partitioning3.png)
