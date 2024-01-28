// используем алгоритм бинарного поиска для отсортированного массива
// сгенерируем массив размером 100 элементов со значениями от -100 до 100

var random = new Random();
int[] numbers = Enumerable.Repeat(0, 100)
           .Select(i => random.Next(-100, 101)).OrderBy(i => i)
           .ToArray();

Console.WriteLine(string.Join(", ", numbers));
Console.WriteLine("Enter value: ");
int.TryParse(Console.ReadLine(), out int value);
Console.WriteLine("Search result: " + BinarySearch(numbers, value));

static int BinarySearch(int[] array, int value)
{
    if (array.Length == 0) return -1;

    var left = 0;
    var right = array.Length - 1;

    if (value < array[left] || value > array[right]) return -1;

    if (array[left] == value) return left;
    if (array[right] == value) return right;

    while (left <= right)
    {
        var middle = (left + right) / 2;
        var result = array[middle].CompareTo(value);

        if (result == 0) return middle;
        if (result > 0) right = middle - 1;
        if (result < 0) left = middle + 1;
    }

    return -1;
}