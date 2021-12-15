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
    public int[][] Relief { 
        set
        {
            _relief = value;
        } 
        get{return _relief;} }

    public Map(int[][] arr2D, int hSnow)
    {
        HSnow = hSnow;
        Dimension = arr2D.Length;
        Relief = arr2D;
    }

    public Map(string mapString, int hSnow)
    {
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
        Console.WriteLine($"\n\nRelief.Length : " + Relief.Length);
        foreach(int[] line in Relief)
        {
            Console.WriteLine();
            foreach(int tile in line)
            {
                // Console.Write("<" + tile + "> ");
                if(tile <= HSnow)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(tile + " ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(tile + " ");
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
        // myMap.DisplayReliefInfo();

        var map2 = 
@"8 9 9 8 7
8 2 3 2 7
6 4 5 4 8
9 8 4 2 7
7 8 9 6 15";

        Map myMap2 = new Map(map2, 5);
        myMap2.DisplayReliefInfo();
        myMap.DisplayReliefInfo();

    }
}