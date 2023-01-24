using System;
using ChessClass;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            var knightPossibleMoves = new List<Tuple<int, int>>() {new Tuple<int, int> (2,1), new Tuple<int, int>(1, 2), new Tuple<int, int>(-1, 2), new Tuple<int, int>(-2, 1), new Tuple<int, int>(-2, -1), new Tuple<int, int>(-1, -2), new Tuple<int, int>(1, -2), new Tuple<int, int>(2, -1) };
            var kingPossibleMoves = new List<Tuple<int, int>>() { new Tuple<int, int>(-1, 1), new Tuple<int, int>(1, 1), new Tuple<int, int>(0, 1), new Tuple<int, int>(1, 0), new Tuple<int, int>(1, -1), new Tuple<int, int>(0, -1), new Tuple<int, int>(-1, -1), new Tuple<int, int>(-1, 0) };
            var bishopPossibleMoves = new List<Tuple<int, int>>() { new Tuple<int, int>(1, 1), new Tuple<int, int>(-1, 1), new Tuple<int, int>(1, -1), new Tuple<int, int>(-1, -1) };
            var rookPossibleMoves = new List<Tuple<int, int>>() { new Tuple<int, int>(0, 1), new Tuple<int, int>(-1, 0), new Tuple<int, int>(0, -1), new Tuple<int, int>(1, 0) };
            var pawnPossibleMoves = new List<Tuple<int, int>>() { new Tuple<int, int>(0, 1), new Tuple<int, int>(0, 2), new Tuple<int, int>(1, 1), new Tuple<int, int>(-1, 1) };
            var WhiteKnight1 = new ChessPiece("Knight", knightPossibleMoves, 3, false, 2, 1, false, "White");
            var WhiteKnight2 = new ChessPiece("Knight", knightPossibleMoves, 3, false, 2, 7, false, "White");
            var WhiteRook1 = new ChessPiece("Rook", rookPossibleMoves, 3, false, 1, 1, false, "White");
            var WhiteRook2 = new ChessPiece("Rook", rookPossibleMoves, 3, false, 1, 8, false, "White");
            Console.WriteLine(WhiteKnight1.Info());

            var checkIsPinned = WhiteKnight1.IsPinned;
        }
    }
}
