using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using ChessClass;

namespace ImaginaryChessPieces
{
    internal class ImaginaryChessPiece : ChessPiece
    {
        private bool _canBePromotedInto;
        private string _description;
        private bool _isASharedPiece;

        public bool CanBePromotedInto { get { return _canBePromotedInto; } init { _canBePromotedInto = value; } }
        public ImaginaryChessPiece(string name, List<Tuple<int, int>> possibleMoves, int pieceValue, bool canMoveInOneDirectionIndefinitely, int xCoordinate, int yCoordinate, bool captured, string colour, bool canBePromotedInto, string description, bool isASharedPiece) : base(name, possibleMoves, pieceValue, canMoveInOneDirectionIndefinitely, xCoordinate, yCoordinate, captured, colour)
        {
            _canBePromotedInto = canBePromotedInto;
            _description = description;
            _isASharedPiece = isASharedPiece;
        }
        public override void Move(int changeInX, int changeInY, string playerColour)
        {
            if (Captured)
            {
                throw new InvalidOperationException("this piece is already captured!");
            }
            if ((playerColour != Colour) && (!_isASharedPiece))
            {
                throw new InvalidOperationException("you do not own this piece!");
            }
            if (PossibleMoves.IndexOf(new Tuple<int, int>(changeInX, changeInY)) == -1)
            {
                XCoordinate += changeInX;
                YCoordinate += changeInY;
            }
            else
            {
                throw new InvalidOperationException($"the {Name} cannot move to this square!");
            }
        }
        public override string Info()
        {
            return base.Info() + $"\nA shared piece: {_isASharedPiece}\nDescription: {_description}";
        }
    }
}
