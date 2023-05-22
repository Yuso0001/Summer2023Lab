using System.Diagnostics;

namespace Lab1 {
    internal class Program
    {
        private IList<string> wordList;
        private int count = 0; 
        static void Main(string[] args) {
            Program program = new Program();
            bool repeat = true;
            while (repeat)
            {
                repeat = program.ConsoleMenu();
            }
        }

        public bool ConsoleMenu()
        {
            Stopwatch SortingTime = new Stopwatch();
            Console.Write("Choose an option:\n" + "1 - Import Words from File\n" + "2 - Bubble Sort Words\n" + "3 - LINQ/Lambda sort words\n" + "4 - Count and Print the Distinct Words\n" + "5 - Take the last 50 words\n" + "6 - Reverse print the words\n" + "7 - Get and display words that end with 'd' and display the count\n" + "8 - Get and display words that starts with 'r' and display the count\n" + "9 - Get and display words that are more than 3 characters long and contains the letter 'a', and display the count\n" + "x - Exit\n\n>>>");

            switch (Console.ReadLine()) {
                case "1":
                    ImportWords();
                    return true;
                case "2":
                    Console.WriteLine("Bubble Sorting...\n");
                    IList<string> tempList = wordList;
                    SortingTime.Start();
                    BubbleSort(tempList);
                    SortingTime.Stop();
                    var elapsed = SortingTime.ElapsedMilliseconds;
                    Console.WriteLine("Bubble Sort Elapsed Time: " + elapsed + "\n");
                    SortingTime.Reset();
                    return true;
                case "3":
                    tempList = wordList;
                    SortingTime.Start();
                    LINQSort(tempList);
                    SortingTime.Stop();
                    elapsed = SortingTime.ElapsedMilliseconds;
                    Console.WriteLine("LINQ Sort Elapsed Time: " + elapsed + "\n");
                    SortingTime.Reset();
                    return true;
                case "4":
                    Distinct();
                    Console.WriteLine("\n");
                    return true;
                case "5":
                    LastFifty();
                    Console.WriteLine("\n");
                    return true;
                case "6":
                    ReversePrint();
                    Console.WriteLine("\n");
                    return true;
                case "7":
                    DEndWords();
                    Console.WriteLine("\n");
                    return true;
                case "8":
                    RStartWords();
                    Console.WriteLine("\n");
                    return true;
                case "9":
                    AWordThree();
                    Console.WriteLine("\n");
                    return true;
                case "x": return false;
                default:
                    return true;
            }
        }

        /**
         * Import Words to File Method
         */
        public void ImportWords()
        {
            wordList = new List<string>();
            var file = Path.Combine(Directory.GetCurrentDirectory(), "Words.txt");
            try
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    String word;
                    while ((word = sr.ReadLine()) != null)
                    {
                        wordList.Add(word);
                        count++;
                    }
                }

                Console.WriteLine(count + " words from file: " + file + " have been imported");
            }
            catch (Exception ex)
            {
                Console.WriteLine("The file: " + file + " could not be read!");
            }
        }

        /**
         * Bubble Sort words in list Method
         */
        public IList<string> BubbleSort(IList<string> tempList)
        {
            string temp = "";
            string[] array = tempList.ToArray();
            for (int prev = 0; prev < array.Length; prev++)
            {
                for (int next = prev + 1; next < array.Length; next++)
                {
                    if (array[next].CompareTo(array[prev]) > 0)
                    {
                        temp = array[next];
                        array[next] = array[prev];
                        array[prev] = temp;
                    }
                }
            }

            tempList = array.ToList();
            return tempList;
        }

        /**
         * LINQ Sort for word list Method
         */
        public IList<string> LINQSort(IList<string> tempList)
        {
            string[] array = tempList.ToArray();
            var linqorder = from s in array orderby s select s;
            return tempList;
        }


        /**
         * Find, Count and Print Distinct words from Word List using LINQ/Lambda Query Method
         */
        public void Distinct()
        {
            count = 0;
            string[] array = wordList.ToArray();
            var disctinct = array.Distinct();
            foreach (var item in disctinct)
            {
                Console.WriteLine(item);
                count++;
            }

            Console.WriteLine("There are " + count + " distinct words in the Word List");
        }

        /**
         * Get Last Fifty words from the Word List using LINQ/Lambda Query Method
         */
        public void LastFifty()
        {
            count = 0;
            var temp = wordList.Reverse();
            foreach (var item in temp)
            {
                if (count == 50) { return; }
                Console.WriteLine(item);
                count++;
            }
        }

        /**
         * Reverse: Print Word List starting from end to first Method
         */
        public void ReversePrint()
        {
            var reverse = wordList.Reverse();
            foreach (var item in reverse)
            {
                Console.WriteLine(item);
            }
        }

        /**
         * Find, Count and Print Words ending with 'd' from the Word List Method
         */
        public void DEndWords()
        {
            count = 0;
            string[] array = wordList.ToArray();
            var dWords = from item in array where item.ToLower().EndsWith('d') select item;
            foreach (var items in dWords)
            {
                Console.WriteLine(items);
                count++;
            }

            Console.WriteLine("There are " + count + " words that ends with 'd'");
        }


        /**
         * Find, Count and Print words starting with letter 'r' from Word List Method
         */
        public void RStartWords()
        {
            count = 0;
            string[] array = wordList.ToArray();
            var rWords = from item in array where item.ToLower().StartsWith('r') select item;
            foreach (var items in rWords)
            {
                Console.WriteLine(items);
                count++;
            }

            Console.WriteLine("There are " + count + " words starting with 'r'");
        }

        public void AWordThree()
        {
            count = 0;
            string[] array = wordList.ToArray();
            var three = from item in array where item.Contains('a') where item.Length > 3 select item;
            foreach (var items in three)
            {
                Console.WriteLine(items);
                count++;
            }
            Console.WriteLine("There are " + count + " words that is more than 3 letters and includes letter 'a");
        }

    }
}