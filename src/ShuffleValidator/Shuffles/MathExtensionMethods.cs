﻿namespace ShuffleValidator.Shuffles
{
    using System.Collections.Generic;
    using System.Linq;

    public static class MathExtensionMethods
    {
        public static ulong Factorial(this int input)
        {
            ulong answer = 0;

            ulong count = 1;
            
            while (count <= (ulong)input)
            {
                if (count == 1)
                {
                    answer = 1;
                    count++;
                }
                else
                {
                    answer = count * answer;
                    count++;
                }
            }

            return answer;
        }
        public static IEnumerable<IEnumerable<T>> Permute<T>(this IEnumerable<T> sequence)
        {
            if (sequence == null)
            {
                yield break;
            }

            var list = sequence.ToList();

            if (list.Any())
            {
                var startingElementIndex = 0;

                foreach (var startingElement in list)
                {
                    var remainingItems = list.AllExcept(startingElementIndex);

                    foreach (var permutationOfRemainder in remainingItems.Permute())
                    {
                        yield return startingElement.Concat(permutationOfRemainder);
                    }

                    startingElementIndex++;
                }
            }
            else
            {
                yield return Enumerable.Empty<T>();
            }
        }

        private static IEnumerable<T> Concat<T>(this T firstElement, IEnumerable<T> secondList)
        {
            yield return firstElement;
            foreach (var item in secondList)
            {
                yield return item;
            }
        }

        private static IEnumerable<T> AllExcept<T>(this IEnumerable<T> sequence, int indexToSkip)
        {
            var index = 0;

            foreach (var item in sequence)
            {
                if (index != indexToSkip)
                {
                    yield return item;
                }

                index++;
            }
        }
    }
}