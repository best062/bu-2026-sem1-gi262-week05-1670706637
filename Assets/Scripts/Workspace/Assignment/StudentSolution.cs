using UnityEngine;
using System.Reflection;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Assignment
{
    public class StudentSolution : IAssignment
    {
        #region Lecture
        public int[] LCT01_SelectionSortAscending(int[] numbers)
        {
            int n = numbers.Length;
            for (int i = 0; i < n-1; i++)
            {
                int minIndex = i;
                for (int j = i+1; j < n; j++)
                {
                    if (numbers[j] < numbers[minIndex])
                    {
                        minIndex = j;
                    }
                }

                (numbers[i], numbers[minIndex]) = (numbers[minIndex], numbers[i]);
            }
            foreach (var n_ in numbers)
            {
                Debug.Log(n_);
            }
            return numbers;
        }

        public int[] LCT02_BubbleSortAscending(int[] numbers)
        {
            int n = numbers.Length;
            for (int i = 0; i < n-1; i++)
            {
                for (int j = 0; j < n-i-1; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        (numbers[j], numbers[j + 1]) = (numbers[j + 1], numbers[j]);
                    }
                }
            }

            foreach (var n_ in numbers)
            {
                Debug.Log(n_);
            }
            return numbers;
        }

        public int[] LCT03_InsertionSortAscending(int[] numbers)
        {
            int n = numbers.Length;
            for (int i = 0; i < n; i++)
            {
                int key = numbers[i];
                int j = i-1;
                while (j >= 0 && numbers[j] > key)
                {
                    numbers[j + 1] = numbers[j];
                    j--;
                }
                numbers[j + 1] = key;
            }

            foreach (var n_ in numbers)
            {
                Debug.Log(n_);
            }
            return numbers;
        }

        #endregion

        #region Assignment

        public int[] AS01_SelectionSortDescending(int[] numbers)
        {
            if (numbers == null || numbers.Length <= 1)
            {
                return numbers;
            }
            int n = numbers.Length;
            
            for (int i = 0; i < n - 1; i++)
            {
                int maxIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (numbers[j] > numbers[maxIndex])
                    {
                        maxIndex = j;
                    }
                }
                if (maxIndex != i)
                {
                    (numbers[i], numbers[maxIndex]) = (numbers[maxIndex], numbers[i]);
                }
            }
            
            foreach (var n_ in numbers)
            {
                Debug.Log(n_);
            }
            return numbers;
        }

        public int[] AS02_BubbleSortDescending(int[] numbers)
        {
            if (numbers == null || numbers.Length <= 1)
            {
                return numbers;
            }

            int n = numbers.Length;
            for (int i = 0; i < n - 1; i++)
            {
                bool swapped = false;
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (numbers[j] < numbers[j + 1])
                    {
                        (numbers[j], numbers[j + 1]) = (numbers[j + 1], numbers[j]);
                        swapped = true;
                    }
                }
                if (!swapped)
                {
                    break;
                }
            }
            
            foreach (var n_ in numbers)
            {
                Debug.Log(n_);
            }
            return numbers;
        }

        public int[] AS03_InsertionSortDescending(int[] numbers)
        {
            if (numbers == null || numbers.Length <= 1)
            {
                return numbers;
            }

            int n = numbers.Length;
            for (int i = 1; i < n; i++)
            {
                int key = numbers[i];
                int j = i - 1;
                while (j >= 0 && numbers[j] < key)
                {
                    numbers[j + 1] = numbers[j];
                    j--;
                }
                numbers[j + 1] = key;
            }
            
            foreach (var n_ in numbers)
            {
                Debug.Log(n_);
            }
            return numbers;
        }

        public int AS04_FindTheSecondLargestNumber(int[] numbers)
        {
            int n = numbers.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int maxIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (numbers[j] > numbers[maxIndex])
                    {
                        maxIndex = j;
                    }
                }
                (numbers[i], numbers[maxIndex]) = (numbers[maxIndex], numbers[i]);
            }
            
            int largest = numbers[0];
            int secondLargest = int.MinValue;

            for (int i = 1; i < n; i++)
            {
                if (numbers[i] < largest)
                {
                    secondLargest = numbers[i];
                    break;
                }
            }

            Debug.Log(secondLargest);
            return secondLargest;
        }

        #endregion

        #region Extra

        public int EX01_FindLongestConsecutiveSequence(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                return 0;
            }
            int n = numbers.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (numbers[j] < numbers[minIndex])
                    {
                        minIndex = j;
                    }
                }
                (numbers[i], numbers[minIndex]) = (numbers[minIndex], numbers[i]);
            }
            
            int longestStreak = 1;
            int currentStreak = 1;

            for (int i = 0; i < n - 1; i++)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    continue;
                }
                
                if (numbers[i + 1] == numbers[i] + 1)
                {
                    currentStreak++;
                }
                else
                {
                    if (currentStreak > longestStreak)
                    {
                        longestStreak = currentStreak;
                    }
                    currentStreak = 1;
                }
            }
            return System.Math.Max(longestStreak, currentStreak);
        }

        #endregion
    }
}
