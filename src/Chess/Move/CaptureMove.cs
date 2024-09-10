namespace Chess.Move;

class CaptureMove : IMove
{
    private readonly Position _startPosition;
    private readonly Position _endPosition;
    private readonly Position _capturedPiecePosition;
    private readonly Piece _capturedPiece;

    public Position StartPosition { get => _startPosition; }
    public Position EndPosition { get => _endPosition; }

    public CaptureMove(Position startPosition, Position endPosition, Piece capturedPiece)
    {
        _startPosition = startPosition;
        _endPosition = endPosition;
        _capturedPiecePosition = endPosition;
        _capturedPiece = capturedPiece;
    }

    public CaptureMove(Position startPosition, Position endPosition, Position capturedPiecePosition, Piece capturedPiece)
    {
        _startPosition = startPosition;
        _endPosition = endPosition;
        _capturedPiecePosition = capturedPiecePosition;
        _capturedPiece = capturedPiece;
    }

    public void Execute(Board board)
    {
        board.RemovePiece(_capturedPiecePosition);
        board.MovePiece(_startPosition, _endPosition);
    }

    public void Undo(Board board)
    {
        board.MovePiece(_endPosition, _startPosition);
        board.SetPiece(_capturedPiecePosition, _capturedPiece);
    }
}
