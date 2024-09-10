namespace Chess;

enum PieceColor
{
    White,
    Black
}

enum PieceType
{
    Pawn,
    Knight,
    Bishop,
    Rook,
    Queen,
    King
}

class Piece
{
    public PieceColor Color { get; private set; }
    public PieceType Type { get; private set; }

    public Piece(PieceColor color, PieceType type)
    {
        Color = color;
        Type = type;
    }

    public static Piece Pawn(PieceColor color) => new(color, PieceType.Pawn);
    public static Piece Knight(PieceColor color) => new(color, PieceType.Knight);
    public static Piece Bishop(PieceColor color) => new(color, PieceType.Bishop);
    public static Piece Rook(PieceColor color) => new(color, PieceType.Rook);
    public static Piece Queen(PieceColor color) => new(color, PieceType.Queen);
    public static Piece King(PieceColor color) => new(color, PieceType.King);

    public override string ToString() => $"{Color.ToString()} {Type.ToString()}";
}
