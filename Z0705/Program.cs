namespace Z0705
{
    internal class Program
    {
        static string[] TableElementsToString<T>(T[] table){
            if (table == null) throw new ArgumentNullException();

            string[] strings = new string[table.Length];
            int index = 0;
            foreach (var element in table)
            {
                if (element != null) strings[index] = element.ToString() ?? "";
                else strings[index] = "null";
                index++;
            }

            return strings;
        }
        static void Main()
        {
            string[] strs = { "jeden", "dwa", "trzy" };
            string[] strsStr = TableElementsToString<string>(strs);
            Console.WriteLine(string.Join(',', strsStr));

            int[] ints = { 1, 2, 3 };
            string[] strsInt = TableElementsToString<int>(ints);
            Console.WriteLine(string.Join(',', strsInt));

            object[] objs = { new object(), null, new object()};
            string[] strsObj = TableElementsToString<object>(objs);
            Console.WriteLine(string.Join(',', strsObj));

            List<int>[] lists = { new List<int>() { 1, 2, 3 }, new List<int>{ 2, 3, 4 }, new List<int> { 5, 6, 7 } };
            string[] strsList = TableElementsToString<List<int>>(lists);
            Console.WriteLine(string.Join(',', strsList));
        }
    }
}