using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDataStructures
{
    /* Although Lists have a bit of boilerplate for 
     * resize them its read, write operations are done in O(1) time.
     * 
     */
    public class MyList<T>
    {
        public T[] arr;

        public int incrementFactor = 2;

        /// <summary>
        /// Gets the quantity of items added to the list
        /// </summary>
        public int Count
        {
            get
            {
                return count;
            }
        }

        private int count;


        public MyList()
        {
            // Starts array with 4 elements by default.
            arr = new T[4];
        }

        // Overloads the constructor for make configurable the list's array' length
        public MyList(int size)
        {
            arr = new T[size];
        }

        /// <summary>
        /// Adds a new item to arr[Count]
        /// </summary>
        /// <param name="item">Item to add to the list</param>
        public void Add(T item)
        {
            // Checks if number of Items added is less than arr length
            if (count < arr.Length)
            {
                arr[count] = item;
            }
            else // if code reaches this, then count == to length, so the original array is full making needed increase its size.
            {
                // Double the arr capacity by default
                T[] tempArr = new T[arr.Length * incrementFactor];
                Array.Copy(arr, tempArr, arr.Length);
                // Change the reference of the variable arr to the same as the new array
                arr = tempArr;

                arr[count] = item;
            }
            count++;
        }

        /// <summary>
        /// Sets the 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        /// 
        /* this notation is known as indexers, and allow us to make 
         * possible to the client code access the array using [] notation
         * NOTE: An indexor can have more that one formal parameter, as in the two dimensional arrays.s
         * 
         */
        public T this[int index] 
        {
            get
            {
                return arr[index];
            }

            set
            {
                // Checks user is accessing an valid Item
                /* count-1 because when count is equal to 0
                 * index > count will be true because is true that index == count
                 * 
                 */

                if (index < 0 || index > (count - 1))
                    throw new IndexOutOfRangeException();

                arr[index] = value;
            }
        }

        /// <summary>
        /// Removes first item from the list equal to the argument
        /// if operation was succesfull, then return true
        /// </summary>
        /// <remarks>Note that this function make a linear search O(n) for find the item in the list's array</remarks>
        /// <param name="item">The item to delete from the list</param>
        /// <returns></returns>
        public bool Remove(T item)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Equals(item))
                {
                    // TODO: Implement RemoveAt function
                    RemoveAt(i);

                    // Returns true if the item was found and succesfully deleted from the list's array
                    return true;
                }
            }

            // Returns false if item element is not found in the list's array
            return false;                
        }

        /// <summary>
        /// Remove item located at specified index
        /// </summary>
        /// <param name="index">Index of item to be removed</param>
        public void RemoveAt(int index)
        {
            // Checks index out of ranges
            if (index < 0 || index > (count-1))
            {
                throw new IndexOutOfRangeException();
            }

            /* Array.Copy() is similar to c++ memmove() function,
             * then its complexity is O(n)
             * see: https://goo.gl/XUGPUj
             * 
             * Arra.Copy() is O(n) where n is the 'length' argument
             * 
             */

            /*
             * If list's arr have 4 elements and it is deleted the
             * element in index 2, then it is required calculated the 
             * number of elements from index 2 (exlusive) to the last index (incluse)
             * for calculate array's length
             * */

            int remaindLength = arr.Length - (index + 1);
            // T[] remaindElements = new T[remaindLength];

            /* Shift the elements located after specified index 
             * one index to left for replace the element located at arr[index]
             * */
            Array.Copy(arr, index + 1, arr, index, remaindLength);

            // Decrease the count variable not the length of the list's array
            count--;

        }
    }
}
