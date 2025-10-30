namespace PolyphaseSorting
{
    public class MergeSort
    {
        public static void Sort(List<Record> records, int left, int right)
        {
            if (left < right)
            {
                int mid = left + (right - left) / 2;

                Sort(records, left, mid);
                Sort(records, mid + 1, right);

                Merge(records, left, mid, right);
            }
        }
        private static void Merge(List<Record> records, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;

            var leftArray = new List<Record>(n1);
            var rightArray = new List<Record>(n2);

            for (int i = 0; i < n1; i++)
                leftArray.Add(records[left + i]);
            for (int j = 0; j < n2; j++)
                rightArray.Add(records[mid + 1 + j]);

            int k = left;
            int x = 0, y = 0;

            while (x < n1 && y < n2)
            {
                if (leftArray[x].Key <= rightArray[y].Key)
                {
                    records[k] = leftArray[x];
                    x++;
                }
                else
                {
                    records[k] = rightArray[y];
                    y++;
                }
                k++;
            }

            while (x < n1)
            {
                records[k] = leftArray[x];
                x++;
                k++;
            }

            while (y < n2)
            {
                records[k] = rightArray[y];
                y++;
                k++;
            }
        }
    }
}