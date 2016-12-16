using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;

namespace TankGame
{
    class MapFile
    {
        // Attributes
        private string file;
        private ArrayList tanks = new ArrayList();
        private ArrayList walls = new ArrayList();

        // Constructor
        public MapFile(string f)
        {
            // Verifies that file exists
            try
            {
                file = f;
            }
            // Throws exception
            catch (FileNotFoundException fe)
            {
                Console.WriteLine(fe.Message);
            }
        }

        public void loadData()
        {
            try
            {
                // Reads file
                StreamReader input = new StreamReader(file);
                // Reads tank lines
                String s1 = input.ReadLine();
                String s2 = input.ReadLine();

                // Puts split strings into string array
                string[] split1 = s1.Split(',');
                string[] split2 = s2.Split(',');

                // Creates int arrays
                int[] int1 = new int[3];
                int[] int2 = new int[3];

                int num;

                // Changes split string into split ints
                for (int i = 0; i < split1.Length; i++)
                {
                    num = int.Parse(split1[i]);
                    int1[i] = num;
                }
                for (int i = 0; i < split2.Length; i++)
                {
                    num = int.Parse(split2[i]);
                    int2[i] = num;
                }

                // Creates tank objects
                Tank tank1 = new Tank(null, int1[2], int1[0], int1[1]);
                Tank tank2 = new Tank(null, int2[2], int2[0], int2[1]);

                // Puts tank objects into tank collection
                tanks.Add(tank1);
                tanks.Add(tank2);

                String c = "";
                while (c != null)
                {
                    c = input.ReadLine();
                    string[] split3 = c.Split(',');
                    int[] int3 = new int[2];

                    for (int i = 0; i < split3.Length; i++)
                    {
                        num = int.Parse(split3[i]);
                        int3[i] = num;
                    }
                    Wall wall = new Wall(int3[0], int3[1]);
                    walls.Add(wall);
                }
                // Closes file
                input.Close();
            }

            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        // Properties
        public ArrayList Tanks
        {
            get { return tanks; }
        }

        public ArrayList Walls
        {
            get { return walls; }
        }
    }
}
