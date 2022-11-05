using System;
namespace IndexerApplication
{
    class IndexN
    {
        private string[] list = new string[size];
        static public int size = 10;
        public IndexN()
        {
            for (int i = 0; i < size; i++)
            {
                list[i] = "N. A.";
            }
        }
        public string this[int index]
        {
            get
            {
                string tmp;

                if (index >= 0 && index <= size - 1)
                {
                    tmp = list[index];
                }
                else
                {
                    tmp = "";
                }

                return (tmp);
            }
            set
            {
                if (index >= 0 && index <= size - 1)
                {
                    list[index] = value;
                }
            }
        }
        public int this[string name]
        {
            get
            {
                int index = 0;
                while (index < size)
                {
                    if (list[index] == name)
                    {
                        return index;
                    }
                    index++;
                }
                return index;
            }

        }

        static void Main(string[] args)
        {
            IndexN names = new IndexN();
            names[0] = "Rose";
            names[1] = "Lilly";
            names[2] = "Jasmine";
            names[3] = "Mango";
            names[4] = "Apple";
            names[5] = "Orange";
            names[6] = "Grapes";
            //using the first indexer with int parameter
            for (int i = 0; i < IndexN.size; i++)
            {
                Console.WriteLine(names[i]);
            }
            //using the second indexer with the string parameter
            Console.WriteLine("The Name ORANGE is Found at the Position : " +
                               names["Orange"]);
            Console.ReadKey();
        }
    }
}