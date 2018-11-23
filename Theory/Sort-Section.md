### 选择排序

#### 思路

选择排序的思路是这样的： 
首先，找到数组中最小的元素， 
其次，将它和数组中的第一个元素交换（如果第一个就是最小的就和自己交换） 
再次，在其余元素中找到最小的元素， 
再次，将它和数组中的第二个元素交换 
不断重复，直到最后一个元素。

叫选择排序，是因为它不断地在其余元素中选择最小的那一个。 
选择排序的移动是最少的，而交换的次数是N，其他排序算法都不具有这个性质。

```
public void SelectionSort(int[] a)
{
    for(int i = 0; i < a.Length; i++)
    {
        int min = i; //最小元素的索引
        for(int j = i+1; j < a.Length; j++)
        {
            if(a[j] < a[min])
            {
                exchange(a[j], a[min]);
            }
        }
    }
}
```
#### 图示如下：

![](https://algs4.cs.princeton.edu/21elementary/images/selection.png)
