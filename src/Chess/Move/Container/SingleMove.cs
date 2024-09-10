namespace Chess.Move.Container;

interface ISingleMove
{
    Position EndPosition { get; }
    IMove Move { get; }
}

class SingleMove : ISingleMove
{
    public Position EndPosition { get; }
    public IMove Move { get; }

    public SingleMove(Position endPosition, IMove move)
    {
        EndPosition = endPosition;
        Move = move;
    }
}