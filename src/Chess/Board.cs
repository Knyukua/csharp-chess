namespace Chess;

class Board
{
    private Dictionary<Position, Piece> _pieces;
    public IEnumerable<KeyValuePair<Position, Piece>> PositionToPiece { get => _pieces; }

    public Board()
    {
        _pieces = new();
    }

    public void SetPiece(Position position, Piece piece) => _pieces[position] = piece;

    public Piece? GetPiece(Position position) => _pieces.GetValueOrDefault(position);

    public void RemovePiece(Position position) => _pieces.Remove(position);

    public void MovePiece(Position startPosition, Position endPosition)
    {
        Piece? piece = GetPiece(startPosition);
        if (piece is null) return;
        RemovePiece(startPosition);
        SetPiece(endPosition, piece);
    }
}
