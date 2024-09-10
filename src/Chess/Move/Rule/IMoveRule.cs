using Chess.Move.Container;

namespace Chess.Move.Rule;

interface IMoveRule
{
    IMoveList GenerateMoves(Board board, Piece piece, Position startPosition);
}
