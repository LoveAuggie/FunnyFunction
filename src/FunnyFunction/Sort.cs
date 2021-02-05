using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyFunction
{
    public class Sort
    {
        #region 冒泡排序
        /* 通过每次比较数组中相邻的两个元素值，使数组中较小的值像气泡一样逐渐“上浮”到数组头部，
         * 较大的值逐渐下浮到数组尾部。（默认升序，降序为反过程）         * 
         */

        public static void BubbleSort(int[] arr)
        {
            for (int index = 0; index < arr.Length; index++)
            {
                for (int next = index + 1; next < arr.Length; next++)
                {
                    if (arr[index] < arr[next])
                    {
                        Swap(arr, index, next);
                    }
                }
            }
        }
        #endregion

        #region 插入排序
        /* 将数组的第一个元素看成一个有序的序列，然后把第二个元素到最后一个元素看作是未排序的序列。
         * 从头到尾扫描未排序的序列（第二个元素到末尾），将每次扫描的元素插入到有序序列合适的位置。
         */
        public static int[] InsertSort(int[] arr)
        {
            List<int> ilist = new List<int>() { arr[0] };

            for (int index = 1; index < arr.Length; index++)
            {
                var iV = arr[index];
                bool find = false;
                for (int ist = ilist.Count - 1; ist >= 0; ist--)
                {
                    if (ilist[ist] >= iV)
                    {
                        find = true;
                        ilist.Insert(ist + 1, iV);
                        break;
                    }
                }
                if (!find)
                    ilist.Insert(0, iV);
            }
            return ilist.ToArray();
        }
        #endregion

        #region 快速排序
        /* 实际上，快排是对冒泡排序的一种改进，采用分而治之的思想。
         * 在待排序表 A[1,2…n]中选取一个基准值pivot（通常选取序列首元素）;
         * 通过一趟排序操作将待排序表分为独立的两部分A[1,2…k-1]，A[k+1,…n]。
         * 其中A[1,2…k-1]都是比基准值小的元素，A[k+1,…n]都是比基准值大的元素。
         * 而基准值pivot通过一趟排序确定了最终的位置，然后就是对A[1,2…k-1], A[k+1,…n]这两部分，递归的进行上述操作。
         */
        public static void QuickSort(List<int> arr, List<int> Result)
        {
            if (arr.Count <= 0) return;
            List<int> bList = new List<int>();
            List<int> aList = new List<int>();
            var av = arr[0];
            for (int i = 1; i < arr.Count; i++)
            {
                if (arr[i] < av)
                    bList.Add(arr[i]);
                else
                    aList.Add(arr[i]);
            }
            QuickSort(bList, Result);
            Result.Add(av);
            QuickSort(aList, Result);
        }
        #endregion

        #region 选择排序
        /* 在有n个元素的数组中，通过n-1轮比较，每一轮对未排序的n-i+1个元素进行比较（i表示当前进行的轮数，范围是[1,n-1]）, 
         * 使得每轮中，最小(大)的元素，放在第 i 个位置上。
         */

        public static List<int> SelectSort(List<int> arr)
        {
            List<int> rList = new List<int>();
            while (arr.Count > 0)
            {
                for (int index = 0; index < arr.Count; index++)
                {
                    var mi = index;
                    for (int ci = index + 1; ci < arr.Count; ci++)
                    {
                        if (arr[mi] < arr[ci])
                            mi = ci;
                    }
                    rList.Add(arr[mi]);
                    arr.RemoveAt(mi);
                }
            }
            return rList;
        }

        #endregion

        #region 希尔排序
        /* 其工作原理是定义一个间隔序列来表示排序过程中进行比较的元素之间有多远的间隔，
         * 每次将具有相同间隔的数分为一组，进行插入排序，大部分场景中，间隔是可以提前定义好的，也可以动态生成。
         * 希尔排序的实质就是分组的插入排序
         */
        public static void ShellSort(int[] arr)
        {
            var sp = arr.Length / 2;
            while (sp > 0)
            {
                for (int i = 0; i < sp; i++)
                {
                    int[] nr = arr.Where((t, id) => id % sp == i).ToArray();
                    int[] nnr = InsertSort(nr);
                    for (int k = 0; k < nnr.Length; k++)
                    {
                        arr[k * sp + i] = nnr[k];
                    }
                }
                sp = sp / 2;
                Console.WriteLine("Step " + sp + " : " + string.Join(",", arr));
            }
        }
        #endregion

        #region 堆排序
        /* 步骤1.根据数组初始化堆中的数据（开始为无序堆）
         * 步骤2. 从最后一个根节点（ 下标为(size-1-1)/2 ）开始往第一个根节点遍历，依次将每个最小（或最大）子树排好序，
         *        建造一个小堆（或大堆） 建堆的过程是O(n)的复杂度，证明是数列极限求和。
         * 步骤3.进行堆排序过程：将堆数组的首位置和末位置的数据交换，缩小范围，以–size大小的范围将堆顶数据下调，
         *        完成建堆（实际上就是更新交换首尾元素后的堆，使堆保持最小（或者最大）堆的性质） 调整的过程是O(logn)的复杂度
         */
        public static void HeapSort(int[] arr)
        {
            HeapHelper.arr = arr;
            HeapHelper.sort();
        }
        #endregion

        #region 归并排序
        /* １、算法思想 : 归并排序是建立在归并操作上的一种有效的排序算法。该算法是采用分治法的一个非常典型的应用，归并排序将两个已经有序的序列合并成一个有序的序列。
         * 2、算法流程
         * 主要两步(分，合)
         * 步骤１进行序列拆分，这是一递归的操作，通常是分到只剩一个元素。（一个元素必定是有序的）
         * 步骤２对排好序的序列合并。
         * 思路：假设我们有一个没有排好序的序列，那么我们首先使用分割的方法将这个序列分割成一个个已经排好序的子序列（直到剩下一个元素）。然后再利用归并的方法将一个个有序的子序列合并成排好序的序列。
         */
        public static int[] MergeSort(int[] arr)
        {
            return MergeHelper2.Sort(arr);

            MergeHelper mh = new MergeHelper(arr);
            mh.Sort();
            return mh.BaseArr;
        }

        #endregion

        private static void Swap(int[] arr, int i, int j)
        {
            var ii = arr[i];
            arr[i] = arr[j];
            arr[j] = ii;
        }
    }

    public class HeapHelper
    {
        public static int[] arr;

        public static void sort()
        {
            //1.构建大顶堆
            for (int i = arr.Length / 2 - 1; i >= 0; i--)
            {
                //从第一个非叶子结点从下至上，从右至左调整结构
                adjustHeap(arr, i, arr.Length);
            }
            //2.调整堆结构+交换堆顶元素与末尾元素
            for (int j = arr.Length - 1; j > 0; j--)
            {
                swap(arr, 0, j);//将堆顶元素与末尾元素进行交换
                adjustHeap(arr, 0, j);//重新对堆进行调整
            }

        }

        /**
         * 调整大顶堆（仅是调整过程，建立在大顶堆已构建的基础上）
         * @param arr
         * @param i
         * @param length
         */
        public static void adjustHeap(int[] arr, int i, int length)
        {
            int temp = arr[i];//先取出当前元素i
            for (int k = i * 2 + 1; k < length; k = k * 2 + 1)
            {//从i结点的左子结点开始，也就是2i+1处开始
                if (k + 1 < length && arr[k] < arr[k + 1])
                {//如果左子结点小于右子结点，k指向右子结点
                    k++;
                }
                if (arr[k] > temp)
                {//如果子节点大于父节点，将子节点值赋给父节点（不用进行交换）
                    arr[i] = arr[k];
                    i = k;
                }
                else
                {
                    break;
                }
            }
            arr[i] = temp;//将temp值放到最终的位置
        }

        /**
         * 交换元素
         * @param arr
         * @param a
         * @param b
         */
        public static void swap(int[] arr, int a, int b)
        {
            int temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }
    }

    public class MergeHelper
    {
        // 面向对象的概念
        public MergeHelper m1;

        public MergeHelper m2;

        public int[] BaseArr;

        public MergeHelper(int[] arr)
        {
            if (arr.Length > 2)
            {
                var arr1 = arr.Take(arr.Length / 2).ToArray();
                m1 = new MergeHelper(arr1);
                var arr2 = arr.Skip(arr.Length / 2).ToArray();
                m2 = new MergeHelper(arr2);
            }
            else
            {
                BaseArr = arr;
            }
        }

        public void Sort()
        {
            if (m1 != null)
            {
                m1.Sort();
                m2.Sort();
                this.BaseArr = MergeArr(m1.BaseArr, m2.BaseArr);
            }
            else
            {
                if(this.BaseArr.Length==2)
                {
                    if (BaseArr[0] > BaseArr[1])
                    {
                        var temp = BaseArr[0];
                        BaseArr[0] = BaseArr[1];
                        BaseArr[1] = temp;
                    }
                }
            }
        }

        public int[] MergeArr(int[] arr1, int[] arr2)
        {
            List<int> list = new List<int>();
            int i = 0; int j = 0;
            while (i < arr1.Length || j < arr2.Length)
            {
                if (i >= arr1.Length)
                {
                    list.AddRange(arr2.Skip(j));
                    j = arr2.Length;
                }
                else if (j >= arr2.Length)
                {
                    list.AddRange(arr1.Skip(i));
                    i = arr1.Length;
                }
                else if (arr1[i] < arr2[j])
                {
                    list.Add(arr1[i]);
                    i++;
                }
                else
                {
                    list.Add(arr2[j]);
                    j++;
                }
            }
            return list.ToArray();
        }
    }

    public class MergeHelper2
    {
        // 面向过程，使用数组交换来排序
        public static int[] Sort(int[] arr)
        {
            // 先拆分
            Split(arr, 0, arr.Length-1);

            // 再合并
            int[] temp = new int[arr.Length];
            Merge(arr, 0, arr.Length - 1, temp);
            return temp;
        }

        public static void Split(int[] arr, int st, int ed)
        {
            if (ed - st >= 2)
            {
                var mid = (ed + st) / 2;
                Split(arr, st, mid);
                Split(arr, mid + 1, ed);
            }
            else if (ed > st)
            {
                if (arr[ed] < arr[st])
                {
                    int temp = arr[ed];
                    arr[ed] = arr[st];
                    arr[st] = temp;
                }
            }
        }

        public static void Merge(int[] arr, int st, int ed, int[] temp)
        {
            if (ed - st >= 2)
            {
                var mid = (ed + st) / 2;
                Merge(arr, st, mid, temp);
                Merge(arr, mid+1, ed, temp);

                int i = st; int j = mid+1; int index = st;
                while (i <= mid || j <= ed)
                {
                    if (i > mid)
                    {
                        temp[index] = arr[j++];
                    }
                    else if (j > ed)
                    {
                        temp[index++] = arr[i++];
                    }
                    else if (arr[i] < arr[j])
                    {
                        temp[index++] = arr[i++];
                    }
                    else
                    {
                        temp[index++] = arr[j++];
                    }
                }
                // 排序后的数据，放到原数组中
                for (int ii = st; ii <= ed; ii++)
                {
                    arr[ii] = temp[ii];
                }
            }
            else
            {
                for (int i = st; i <= ed; i++)
                {
                    temp[i] = arr[i];
                }
            }
        }
    }
}
