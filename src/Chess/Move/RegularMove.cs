namespace Chess.Move;

class RegularMove : IMove
{
    private readonly Position _startPosition;
    private readonly Position _endPosition;

    public Position StartPosition { get => _startPosition; }
    public Position EndPosition { get => _endPosition; }

    public RegularMove(Position startPosition, Position endPosition)
    {
        _startPosition = startPosition;
        _endPosition = endPosition;
    }

    public void Execute(Board board) => board.MovePiece(_startPosition, _endPosition);

    public void Undo(Board board) => board.MovePiece(_endPosition, _startPosition);
}
