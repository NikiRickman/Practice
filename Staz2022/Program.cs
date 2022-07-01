using System;
using System.Text.RegularExpressions;
namespace Staz2022
{
    class Program
    {
        static void Main(string[] args)
        {
            int Size1 = 0;
            int Size2 = 0;

            string FirstLine = "";
            int count_lines = 0;
            string SecondLine = "";
            string ThirdLine = "";

            //Change the link for ur own
            foreach (string line in System.IO.File.ReadLines(@"C:\Users\Night\Desktop\3.txt"))
            {
                if (count_lines == 0) FirstLine = line;
                if (count_lines == 1) SecondLine = line;
                if (count_lines == 2) ThirdLine = line;
                count_lines++;
            }

            int count_size = 0;
            string[] Size = FirstLine.Split(new char[] { '-' });
            foreach (string s2 in Size)
            {
                if (s2 != "")
                {
                    if (count_size == 0) Size1 = Convert.ToInt32(s2);
                    if (count_size == 1) Size2 = Convert.ToInt32(s2);
                    count_size++;
                }
            }
            int MainSize = Math.Max(Size1, Size2);

            int Side_x = MainSize * 2 + 1;
            int Side_y = MainSize * 2 + 1;

            byte[,] pole = new byte[Side_y, Side_x];
            int[,] poledistance1 = new int[Side_y, Side_x];
            int[,] poledistance2 = new int[Side_y, Side_x];

            int current_location_x = MainSize;
            int current_location_y = MainSize;

            //Base point
            pole[current_location_y, current_location_x] = 9;

            string[] lines = SecondLine.Split(new char[] { ',' });
            MatchCollection matches = Regex.Matches(SecondLine, ",");
            int MoveCount = matches.Count + 1;
            int[] distance_driver1 = new int[MoveCount];

            int distance = 0;
            int distance2 = 0;
            //Create the way of the first driver
            foreach (string s in lines)
            {
                char side = 't';
                int cislo = 0;

                //Get the side
                foreach (char ch in s)
                {
                    if (char.IsLetter(ch))
                    {
                        side = ch;
                    }
                }

                //Get the length of the side
                string[] lines2 = s.Split(new char[] { 'N', 'S', 'W', 'E' });
                foreach (string s2 in lines2)
                {
                    if (s2 != "")
                    {
                        cislo = Convert.ToInt32(s2);
                    }
                }

                //Add '1' for every point on the first way.
                if (side == 'W')
                {
                    for (int i = 0; i < cislo; i++)
                    {
                        if (pole[current_location_y, current_location_x - 1] == 0)
                        {
                            distance += 1;
                            poledistance1[current_location_y, current_location_x] = distance;
                            pole[current_location_y, current_location_x - 1] += 1;
                        }
                        current_location_x -= 1;
                    }
                }
                if (side == 'N')
                {
                    for (int i = 0; i < cislo; i++)
                    {

                        if (pole[current_location_y - 1, current_location_x] == 0)
                        {
                            distance += 1;
                            poledistance1[current_location_y, current_location_x] = distance;
                            pole[current_location_y - 1, current_location_x] += 1;
                        }
                        current_location_y -= 1;
                    }
                }
                if (side == 'E')
                {
                    for (int i = 0; i < cislo; i++)
                    {

                        if (pole[current_location_y, current_location_x + 1] == 0)
                        {
                            distance += 1;
                            poledistance1[current_location_y, current_location_x] = distance;
                            pole[current_location_y, current_location_x + 1] += 1;
                        }
                        current_location_x += 1;
                    }
                }
                if (side == 'S')
                {
                    for (int i = 0; i < cislo; i++)
                    {

                        if (pole[current_location_y + 1, current_location_x] == 0)
                        {
                            distance += 1;
                            poledistance1[current_location_y, current_location_x] = distance;
                            pole[current_location_y + 1, current_location_x] += 1;
                        }
                        current_location_y += 1;
                    }
                }
            }

            string[] lines3 = ThirdLine.Split(new char[] { ',' });

            //Sets the start location
            current_location_x = MainSize;
            current_location_y = MainSize;

            //Create the way of the second driver
            foreach (string s in lines3)
            {
                char side = 't';
                int cislo = 0;

                //Get the side
                foreach (char ch in s)
                {
                    if (char.IsLetter(ch))
                    {
                        side = ch;
                    }
                }

                //Get the length of the side
                string[] lines4 = s.Split(new char[] { 'N', 'S', 'W', 'E' });
                foreach (string s2 in lines4)
                {
                    if (s2 != "")
                    {
                        cislo = Convert.ToInt32(s2);
                    }
                }

                if (side == 'W')
                {
                    for (int i = 0; i < cislo; i++)
                    {
                        if (pole[current_location_y, current_location_x - 1] < 2)
                        {
                            distance2 += 1;
                            poledistance2[current_location_y, current_location_x] = distance2;
                            pole[current_location_y, current_location_x - 1] += 1;
                        }
                        current_location_x -= 1;
                    }
                }
                if (side == 'N')
                {
                    for (int i = 0; i < cislo; i++)
                    {
                        if (pole[current_location_y - 1, current_location_x] < 2)
                        {
                            distance2 += 1;
                            poledistance2[current_location_y, current_location_x] = distance2;
                            pole[current_location_y - 1, current_location_x] += 1;
                        }
                        current_location_y -= 1;
                    }
                }
                if (side == 'E')
                {
                    for (int i = 0; i < cislo; i++)
                    {
                        if (pole[current_location_y, current_location_x + 1] < 2)
                        {
                            distance2 += 1;
                            poledistance2[current_location_y, current_location_x] = distance2;
                            pole[current_location_y, current_location_x + 1] += 1;
                        }
                        current_location_x += 1;
                    }
                }
                if (side == 'S')
                {
                    for (int i = 0; i < cislo; i++)
                    {
                        if (pole[current_location_y + 1, current_location_x] < 2)
                        {
                            distance2 += 1;
                            poledistance2[current_location_y, current_location_x] = distance2;
                            pole[current_location_y + 1, current_location_x] += 1;
                        }
                        current_location_y += 1;
                    }
                }
            }


            /*
             * Draw the ways
            for (int i = 0; i < Side_y; i++)
            {
                for (int j = 0; j < Side_x; j++)
                {
                    Console.Write(pole[i, j] + " ");
                }
                Console.WriteLine();
            }
            */

            //Checking whether the distance is the same         
            for (int y = 0; y < Side_y; y++)
            {
                for (int x = 0; x < Side_x; x++)
                {
                    if (pole[y, x] == 2)
                    {
                        if (poledistance1[y, x] == poledistance2[y, x])
                        {
                            int Os_x = Math.Max(MainSize, x) - Math.Min(MainSize, x);
                            int Os_y = Math.Max(MainSize, y) - Math.Min(MainSize, y);
                            if (x < MainSize) Os_x *= -1;
                            if (y > MainSize) Os_y *= -1;
                            Console.Write($"[{Os_x}, {Os_y}]\n");
                        }
                    }
                }
            }
            Console.ReadKey();
        }
    }
}