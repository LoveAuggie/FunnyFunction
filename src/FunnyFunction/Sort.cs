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
                        ilist.Insert(ist+1, iV);
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
            QuickSort(bList,Result);
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
            while (sp>0)
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
        #endregion

        private static void Swap(int[] arr, int i, int j)
        {
            var ii = arr[i];
            arr[i] = arr[j];
            arr[j] = ii;
        }
    }
}
