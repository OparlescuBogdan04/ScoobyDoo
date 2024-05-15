using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoobyDoo
{
    internal class Threading
    {
        public int[] GenerateRandomArray(int length)
        {
            //To Do
            return new int[length];
        }

        void ThreadedArraySum(int[] array, int no_threads)
        {
            //divide the array into parts
            //create a thread for each part
            //for each thread => sum the array on that division
            //return sum(all_thread_results)
        }

        //The same as the function above, but modulo <mod>
        void ThreadedArraySumMod(int[] array, int no_threads,int mod)
        {

        }


        void ThreadedArrayAverage(int[] array, int no_threads)
        {
            //average for each thread result
            //average of the averaged_thread_results
        }
    }
}
