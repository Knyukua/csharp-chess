namespace Chess.Move.Container;

interface IMoveChain
{
    void AddMove(Position endPosition, IMove move);
    void RemoveMoveTo(Position endPosition);
    bool HasMoveTo(Position endPosition);
    IEnumerable<ISingleMove> GetAllMoves();
}

class MoveChain : IMoveChain
{
    private List<ISingleMove> _moves;

    public MoveChain() => _moves = new();

    public void AddMove(Position endPosition, IMove move) => _moves.Add(new SingleMove(endPosition, move));  

    public IEnumerable<ISingleMove> GetAllMoves() => _moves;

    public bool HasMoveTo(Position endPosition) => _moves.Any(move => move.EndPosition == endPosition);

    public void RemoveMoveTo(Position endPosition) => _moves.RemoveAll(move => move.EndPosition == endPosition);
}
