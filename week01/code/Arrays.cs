public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.
    /// Assume that length is a positive integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // PLAN:
        // 1. Create a new array of doubles with the specified length.
        // 2. Use a for-loop to populate the array.
        // 3. At each index i, store (number * (i + 1)) to get multiples starting from number itself.
        // 4. Return the populated array.

        double[] multiples = new double[length];
        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }

        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.
    /// For example, if the data is List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and amount is 3,
    /// then the result should be List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.
    /// This modifies the original list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // PLAN:
        // 1. Validate that amount is within the correct range (1 to data.Count).
        // 2. Use slicing: split the list into two parts:
        //    - The last 'amount' elements.
        //    - The first 'data.Count - amount' elements.
        // 3. Clear the original list.
        // 4. Add the two parts back in the correct rotated order:
        //    - Add the last 'amount' elements first.
        //    - Then add the remaining elements.

        if (amount < 1 || amount > data.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be between 1 and the size of the list.");
        }

        int splitIndex = data.Count - amount;
        List<int> tail = data.GetRange(splitIndex, amount);
        List<int> head = data.GetRange(0, splitIndex);

        data.Clear();
        data.AddRange(tail);
        data.AddRange(head);
    }
}
