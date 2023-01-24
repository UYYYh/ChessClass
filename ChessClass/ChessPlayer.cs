using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessClass;

namespace PlayerClass
{
    internal class ChessPlayer
    {
        private string _name;
        private List<ChessPiece>? _chessPieces;
        private string? _colour;
        private FIDEProfile _profile;

        public string Name { get { return _name; } }
        public List<ChessPiece> ChessPieces { get { return _chessPieces; } }
        public FIDEProfile Profile { get { return _profile; } }
        public string Colour { get { return _colour; } }

        public ChessPlayer(string name, List<ChessPiece>? chessPieces, string? colour, FIDEProfile playerCareerProfile)
        {            
            _chessPieces = chessPieces;
            _colour = colour;
            _profile = playerCareerProfile;
            _name = name;
        }
        
        public void AddPiece(ChessPiece piece)
        {
            _chessPieces.Append(piece);
        }
        public void RemovePiece(ChessPiece piece)
        {
            _chessPieces.Remove(piece);
        }
        public void MovePiece(ChessPiece piece, int changeInX, int changeInY)
        {   
            if (_chessPieces.IndexOf(piece) == -1)
            {
                throw new InvalidOperationException("You do not own this piece!");
            }
            piece.Move(changeInX, changeInY, _colour);
        }

        public void PromotePiece(ChessPiece piece, ChessPiece pieceTobePromotedInto)
        {
            if (_chessPieces.IndexOf(piece) == -1)
            {
                throw new InvalidOperationException("You do not own this piece!");
            }
            piece.Promote(pieceTobePromotedInto);
        }

        public void ResignGame()
        {
            throw new NotImplementedException();
        }

        public string Info()
        {
            return $"Name: {Name}\nColour: {Colour}";
        }
    }
}
