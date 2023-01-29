using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessClass
{
    internal class ChessSet
    {
        private List<ChessPiece>? _pieces;
        private string? _material;
        private decimal _price;

        public string Material { get { return _material; } init { _material = value; } }
        public decimal Price { get { return _price; } set { _price = value; } }
        public List<ChessPiece?> Pieces { get { return _pieces; } protected set { _pieces = value; } }

        public ChessSet(List<ChessPiece>? pieces, string? material, int price)
        {
            _pieces = pieces;
            _material = material;
            _price = price;
        }

        public string info()
        {
            StringBuilder output = new StringBuilder();
            foreach (ChessPiece piece in _pieces)
            {   
                if (piece.Captured != true)
                {
                    output.Append($"{piece.Colour} {piece.Name}, Coordinates: {piece.XCoordinate}, {piece.YCoordinate}");
                }                
            }
            return output.ToString();
        }
    }
}
