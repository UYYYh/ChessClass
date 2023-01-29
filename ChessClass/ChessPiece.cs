using System;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace ChessClass// Note: actual namespace depends on the project name.
{
    internal class ChessPiece
    {
        private string _name;
        private List<Tuple<int,int>> _possibleMoves;
        private int _value;
        private bool _canMoveInOneDirectionIndefinitely;
        private int _xCoordinate;
        private int _yCoordinate;
        private bool _captured;
        private string _colour;
        private bool _isInCheck;
        private bool _isPinned;

        public string Name { get { return _name; } protected set { _name = value; } }
        public List<Tuple<int,int>> PossibleMoves { get { return _possibleMoves; } protected set { _possibleMoves = value; } }
        public int XCoordinate { get { return _xCoordinate; } set { _xCoordinate = value; } }
        public int YCoordinate { get { return _yCoordinate; } set { _yCoordinate = value; } }
        public bool Captured { get { return _captured; } protected set { _captured = value; } }
        public string Colour { get { return _colour; } protected set { _colour = value; } }
        public bool IsPinned { 
            get { return _isPinned; } 
            protected set
            {
                if (_name == "King")
                {
                    throw new InvalidOperationException("the King cannot be pinned!");
                }
                _isPinned = value;
            }
        }
        public bool IsInCheck
        {
            get
            { return _isInCheck; }
            protected set
            {   
                if (_name != "King")
                {
                    throw new InvalidOperationException($"the {_name} cannot be in check");
                }
                _isInCheck = value;
            }
        }
        public ChessPiece(string name, List<Tuple<int,int>> possibleMoves, int pieceValue, bool canMoveInOneDirectionIndefinitely, int xCoordinate, int yCoordinate, bool captured, string colour)
        {
            _name = name;
            _possibleMoves = possibleMoves;
            _value = pieceValue;
            _canMoveInOneDirectionIndefinitely = canMoveInOneDirectionIndefinitely;         
            _xCoordinate = xCoordinate;
            _yCoordinate = yCoordinate;
            _captured = captured;
            _colour = colour;
        }

        public virtual void Move(int changeInX, int changeInY, string playerColour)
        {
            if (_captured)
            {
                throw new InvalidOperationException("this piece is already captured!");
            }
            if (playerColour != _colour)
            {
                throw new InvalidOperationException("you do not own this piece!");
            }
            if (_possibleMoves.IndexOf(new Tuple<int, int>(changeInX,changeInY)) == -1)
            {
                _xCoordinate += changeInX;
                _yCoordinate += changeInY;
            }
            else
            {
                throw new InvalidOperationException($"the {_name} cannot move to this square!");
            }
        }

        public Tuple<int,int> CheckCoordinates()
        {
            return new Tuple<int,int>(_xCoordinate, _yCoordinate);
        }

        public virtual string Info()
        {
            var possibleMoves = new StringBuilder("");
            foreach (var move in _possibleMoves) { possibleMoves.Append($"({move.Item1}, {move.Item2}) "); }
            return $"{_colour} {_name}\nPiece Value: {_value}\nPossible moves:{possibleMoves}\nCurrent Coordinates:{_xCoordinate}, {_yCoordinate}\nIn Check:{_isInCheck}";
        }

        public virtual void Promote(ChessPiece chessPieceToBePromotedTo)
        {
            if (_name != "pawn")
            {
                throw new InvalidOperationException("only a pawn can promote!");
            }
            if (((_yCoordinate == 8) && (_colour == "white")) || ((_yCoordinate == 0) && (_colour == "black")))
            {
                _name = chessPieceToBePromotedTo._name;
                _possibleMoves = chessPieceToBePromotedTo._possibleMoves;
                _value = chessPieceToBePromotedTo._value;
                _canMoveInOneDirectionIndefinitely = chessPieceToBePromotedTo._canMoveInOneDirectionIndefinitely;
            }
        }
    }

}