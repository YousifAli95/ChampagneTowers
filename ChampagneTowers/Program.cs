namespace ChampagneTowers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int chosenRow = 5;
            int chosenGlass = 2;

            int numberOfRows = 7;
            double[][] champagneTower = new double[numberOfRows][];
            for (int row = 0; row < numberOfRows; row++)
            {
                champagneTower[row] = new double[row + 1];
            }
            int numberOfGlassesPoured = 0;
            double stepSize = 1;
            //for (int numberOfGlassesPoured = 0; numberOfGlassesPoured < 20; numberOfGlassesPoured++)
            var fullGlass = false;
            while (!fullGlass)
            {
                numberOfGlassesPoured++;
                PourGlass(champagneTower, stepSize);
                if (champagneTower[chosenRow - 1][chosenGlass - 1] == 1)
                {
                    fullGlass = true;
                    numberOfGlassesPoured--;
                }
                //PrintChampagneTower(champagneTower);
            }
            double[][] newChampagneTower = new double[numberOfRows][];
            for (int row = 0; row < numberOfRows; row++)
            {
                newChampagneTower[row] = new double[row + 1];
            }
            int newNumberOfGlassesPoured = 0;
            for (int i = 0; i < numberOfGlassesPoured; i++)
            {
                Console.WriteLine($"Number of second passed: {((newNumberOfGlassesPoured++ + 1) * 10 * stepSize).ToString("#0.000")}s");
                PourGlass(newChampagneTower, stepSize);
                PrintChampagneTower(newChampagneTower);
            }
            stepSize = 0.0001;
            fullGlass = false;
            numberOfGlassesPoured = 0;
            double numberOfSecondsPassed = stepSize + newNumberOfGlassesPoured;
            //(numberOfSecondsPassed * 10 * stepSize).ToString("#0.000")
            while (!fullGlass)
            {
                Console.WriteLine($"Number of second passed:  {numberOfSecondsPassed * 10}s");
                numberOfSecondsPassed += stepSize;
                PourGlass(newChampagneTower, stepSize);
                if (newChampagneTower[chosenRow - 1][chosenGlass - 1] == 1)
                {
                    fullGlass = true;
                    //numberOfGlassesPoured--;
                }
                PrintChampagneTower(champagneTower);
            }
            numberOfSecondsPassed -= stepSize;
            Console.WriteLine($"Number of second passed:  {(numberOfSecondsPassed * 10).ToString("#0.000")}s");
            static void PrintChampagneTower(double[][] champagneTower)
            {

                foreach (var row in champagneTower)
                {
                    foreach (var glass in row)
                    {
                        Console.Write($"[{glass}] ");
                    }
                    Console.WriteLine();
                }
            }

            static void PourGlass(double[][] champagneTower, double StepSize)
            {
                champagneTower[0][0] += StepSize;
                for (int row = 0; row < champagneTower.Length - 1; row++)
                {
                    for (int glass = 0; glass < champagneTower[row].Length; glass++)
                    {
                        //double fillAmount = Math.Min(1, champagneTower[row][glass]);
                        //double overflowAmount = Math.Max(0, champagneTower[row][glass] - 1);

                        var tmp = (champagneTower[row][glass] - 1) / 2;
                        if (tmp > 0)
                        {
                            champagneTower[row + 1][glass] += tmp;
                            champagneTower[row + 1][glass + 1] += tmp;
                        }
                        champagneTower[row][glass] = Math.Min(1, champagneTower[row][glass]);


                    }

                }

            }
        }
    }
}
//for (let i = 0; i < rows; i++)
//{
//    const currentRow = tower[i];
//    const nextRow = [];
//    for (let j = 0; j < currentRow.length; j++)
//    {
//        const fillAmount = Math.min(1, currentRow[j]);
//        const overflowAmount = Math.max(0, currentRow[j] - 1);
//        nextRow[j] = nextRow[j] + overflowAmount / 2 || overflowAmount / 2;
//        nextRow[j + 1] =
//          nextRow[j + 1] + overflowAmount / 2 || overflowAmount / 2;
//        currentRow[j] = fillAmount;
//    }