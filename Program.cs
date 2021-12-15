using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Map
{
    int HSnow{ set; get;}
    // int _dimension;
    int[][] _relief;
    // public int Dimension { set{_dimension = value;} get{return _dimension;} }
    public int[][] Relief { 
        set
        {
            _relief = value;
        } 
        get{return _relief;} }

    public Map(int[][] arr2D, int hSnow)
    {
        HSnow = hSnow;
        // Dimension = arr2D.Length;
        Relief = arr2D;
    }

    public Map(string mapString, int hSnow)
    {
        
        HSnow = hSnow;
        // Splitting the mapString into its lines. Each ones of these are stored in an array as its items.
        string[] mapLine = mapString.Split('\n');

        // Initializing the Relief jagged array by specifying its dimension.
        Relief = new int[mapLine.Length][];
        for(int i = 0; i < mapLine.Length; i++)
        {
            // Splitting the line into its characters separated by a space. Each char correspond to one tile of the entire map 
            string[] tile = mapLine[i].Split(' ');

            //Initializing the array of each jagged array item by specifying its dimension (the same as mapLine)
            Relief[i] = new int[tile.Length];
            for (int j = 0; j < tile.Length; j++)
            {
                // Assigning tile's value to each jagged array item 
                Relief[i][j] = int.Parse(tile[j]);
                // Console.WriteLine(int.Parse(tile[j]).GetType());
                // Relief[i][j] = int.Parse(tile[j]);
            }
        }
    }

    public void DisplayReliefInfo()
    {
        Console.WriteLine($"\n\n\n\nRelief.Length : " + Relief.Length + "\nSnow height : " + HSnow);
        foreach(int[] line in Relief)
        {
            Console.WriteLine();
            foreach(int tile in line)
            {
                if(tile <= HSnow)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(tile + "\t");

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(tile + "\t");
                }
                
                Console.ResetColor();
            }
        }
    }
}

class Solution
{
    static void Main(string[] args)
    {
        // int hSnow = 8;
        // int H = 5;
        // int N = 5;
        var map = new[]
        {
            new[] {8,9,9,8,7},
            new[] {8,2,3,2,7},
            new[] {6,4,5,4,8},
            new[] {9,8,4,2,7},
            new[] {7,8,9,6,5}
        };

        var map2 = 
@"8 9 9 8 7
8 2 3 2 7
6 4 5 4 8
9 8 4 2 7
7 8 9 6 15";

        // int H = 5;
        // int N = 5;
        int hSnow = 3;
        Map myMap = new Map(map, hSnow);
        Map myMap2 = new Map(map2, hSnow);
        // myMap2.DisplayReliefInfo();
        // myMap.DisplayReliefInfo();


        var map1Valley = 
@"8 9 9 8 7
8 2 3 2 7
6 4 5 4 8
9 8 4 2 7
7 8 9 6 5";


        var map2Valley = 
@"1230 1241 1223 1244
1002 1014 1223 1244
1230 1241 1072 1244
1230 1132 1118 1171";


        var map3Valley = 
@"120 134 172 141 154
171 100 121 91 132
165 51 120 179 141
162 73 145 81 87
120 134 172 79 154";

        
        var mapAlpsValley = 
@"1596 1385 651 1934 1057 1815 1729 1240 1948 1876 649 1374 1811 464 1824 595 1176 792 489 789
867 1412 469 709 1079 1038 1028 1075 519 966 958 1964 680 1379 1177 693 921 1729 1909 1619
620 408 1116 1574 669 1955 1382 1368 1914 1114 1183 1648 1270 1265 1277 654 474 1999 627 1282
680 1681 415 1200 457 1502 1802 1142 1268 1569 506 1433 1093 930 1506 1270 1753 465 1907 1243
1606 1860 1792 1190 1224 796 1129 1958 1531 1146 929 439 627 485 1701 789 855 1800 1953 1108
1932 1495 666 420 1168 1005 828 1214 796 1454 919 1419 772 1793 701 1820 994 1335 698 1753
581 844 819 1760 1098 1658 1619 1615 1773 1860 1025 656 657 1973 1122 1254 851 1518 1373 1706
846 1252 632 972 942 1955 1382 1947 1431 1193 1720 954 1235 1777 1029 1472 1366 954 1194 1812
1125 1731 664 1003 910 1114 853 490 876 445 567 1439 1373 1352 1756 1058 1857 1276 1436 786
1769 532 1387 1163 1939 444 1933 1898 1969 959 1573 764 1004 1093 493 584 1433 1596 1849 1155
590 1345 696 1625 1995 1440 1774 1418 519 1813 1096 1779 858 1529 569 1130 853 1236 1392 1247
1202 1654 1453 1273 572 1389 494 1402 1720 1020 753 1415 806 718 694 1064 1006 442 1071 1367
727 1021 1457 992 1690 728 945 1182 1105 1256 568 1080 620 1828 1800 1079 1738 1564 920 1948
535 1555 503 1939 1517 1556 1550 412 1017 809 724 1073 1052 1223 1883 919 592 1020 1938 1093
1726 1298 941 622 1336 1162 1229 499 1524 569 1806 1303 953 1237 803 1739 1305 875 925 1857
1347 1077 552 1713 939 1659 707 706 1389 1623 1969 841 1875 716 1956 1956 1350 1212 1042 1335
716 1079 1190 1410 1751 1657 1588 1300 1575 707 737 1987 542 1352 433 1920 1477 1440 497 1284
1928 1567 1801 528 1795 538 1606 1670 433 1529 1674 1496 1552 1576 1567 437 1360 1952 652 624
1370 1928 920 1634 1903 1788 513 1883 1313 1495 1890 1409 482 643 1045 1126 1135 975 1998 1105
1007 944 600 473 732 529 1597 532 1192 1707 533 1981 653 1254 476 1015 1123 1715 985 766";

        Map myMap1Valley = new Map(map1Valley, 5);
        Map myMap2Valley = new Map(map2Valley, 1200);
        Map myMap3Valley = new Map(map3Valley, 100);
        Map myMapAlpsValley = new Map(mapAlpsValley, 862);

        myMap1Valley.DisplayReliefInfo();
        myMap2Valley.DisplayReliefInfo();
        myMap3Valley.DisplayReliefInfo();
        myMapAlpsValley.DisplayReliefInfo();


    }
}