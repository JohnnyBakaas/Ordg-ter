namespace Ordgåter
{
    internal class Program
    {
        public static string[] cleaanText;

        static void Main(string[] args)
        {
            string[] text = File.ReadAllLines("C:\\Users\\johnn\\source\\repos\\Ordgåter\\Ordgåter\\ordliste.txt");

            cleaanText = RemoveUnwanted(ThereMayOnlyBeOne(text));


            punktFem(2);
        }


        public static void punktFem(int offset)
        {
            offset++;
            Random rnd = new Random();
            string randomWord = cleaanText[rnd.Next(cleaanText.Length)];
            string sertchString = "";

            for (int i = randomWord.Length - offset; i < randomWord.Length; i++)
            {
                sertchString += randomWord[i];
            }

            Console.WriteLine(randomWord);
            Console.WriteLine(sertchString);
            Console.WriteLine(cleaanText[indexOfMatch(sertchString)]);
        }

        public static int indexOfMatch(string input)
        {
            for (int i = 0; i < cleaanText.Length; i++)
            {
                bool found = true;
                for (int j = 0; j < input.Length; j++)
                {
                    if (!(cleaanText[i][j] == input[j])) { found = false; break; }
                }
                if (found) return i;
            }
            return indexOfMatch(input);
        }

        public static string[] RemoveUnwanted(string[] strings)
        {
            List<string> list = new List<string>();
            foreach (string s in strings)
            {
                if (s.Length >= 7 && s.Length <= 10 && !s.Contains("-"))
                {
                    list.Add(s);
                }
            }
            return list.ToArray();
        }

        public static string[] ThereMayOnlyBeOne(string[] text)
        {
            List<string> list = new List<string>();

            string lastWord = "";
            foreach (string line in text)
            {

                string word = "";
                int i = line.IndexOf('\t') + 1;

                while (line[i] != '\t')
                {
                    word += line[i];
                    i++;
                }

                //Console.WriteLine(word);
                if (lastWord != word)
                {
                    lastWord = word;
                    list.Add(word);
                }

            }
            return list.ToArray();
        }
    }
}