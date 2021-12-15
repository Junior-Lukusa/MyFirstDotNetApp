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
    int _dimension;
    int[][] _relief;
    public int Dimension { set{_dimension = value;} get{return _dimension;} }
    public int[][] Relief { set{_relief = value;} get{return _relief;} }

    public Map(int[][] arr2D, int hSnow)
    {
        HSnow = hSnow;
        Dimension = arr2D.Length;
        Relief = arr2D;
    }

    public Map(string mapString, int hSnow)
    {
        string[] mapLine = mapString.Split('\n');
        Console.WriteLine(mapLine[0]);
        for(int i = 0; i < mapLine.Length; i++)
        {
            string[] tile = mapLine[i].Split(' ');
            for (int j = 0; j < tile.Length; j++)
            {
                try
                {
                    Console.WriteLine($"({i},{j})" + int.Parse(tile[j]).GetType()); 
                }
                catch (System.Exception e)
                {
                    Console.WriteLine($"({i},{j})"); 
                    Console.Write(e.Message);
                    //throw;
                }
                // Relief[i][j] = int.Parse(tile[j]);
            }
        }
    }

    public void Display()
    {
        for (int i = 0; i < Dimension; i++)
        {
            Console.WriteLine();
            for (int j = 0; j < Dimension; j++)
            {
                int h = Relief[i][j];
                if(h <= HSnow)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(h + " ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(h + " ");
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

        Map myMap = new Map(map, 6);
        // myMap.Display();

        var map2 = 
@"8 9 9 8 7
8 2 3 2 7
6 4 5 4 8
9 8 4 2 7
7 8 9 6 5";

        Map myMap2 = new Map(map2, 5);
        myMap2.Display();

    }
}