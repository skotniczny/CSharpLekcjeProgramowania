double[] Uniq(double[] array)
{
    List<double> uniq = new List<double>();

    foreach (double element in array)
    {
        if (!uniq.Contains(element)) uniq.Add(element);
    }

    return uniq.ToArray();
}

Console.WriteLine(string.Join("; ", Uniq(new double[] { 1.111, 1.111, 1.4, 1.4, 1.8, 2.4, 2.4, 100.5, 1.111, 1.4})));
