using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9
{
    class Translate
    {
        public int x = 0;
        public int y = 0;

        public Translate(int dispMethod)
        {
            switch (dispMethod)
            {
                case 1:
                    x = 0;
                    y = 1;
                    break;
                case 2:
                    x = 1;
                    y = 1;
                    break;
                case 3:
                    x = 1;
                    y = 0;
                    break;
                case 4:
                    x = 1;
                    y = -1;
                    break;
                case 5:
                    x = 0;
                    y = -1;
                    break;
                case 6:
                    x = -1;
                    y = -1;
                    break;
                case 7:
                    x = -1;
                    y = 0;
                    break;
                case 8:
                    x = -1;
                    y = 1;
                    break;
                case 9:
                    x = -2;
                    y = -2;
                    break;
                case 10:
                    x = 2;
                    y = -2;
                    break;
            }
        }
    }
}
