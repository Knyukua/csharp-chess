namespace Chess.Move.Container;

interface IMoveList
{
    IEnumerable<IMoveChain> MoveChains { get; }
    void AddMoveChain(IMoveChain moveChain);
    void AddMove(Position endPosition, IMove move);
    void RemoveMoveTo(Position position);
    bool HasMoveTo(Position position);
    IEnumerable<ISingleMove> GetAllMoves();
}

class MoveList : IMoveList
{
    private List<ISingleMove> _singleMoves;
    private List<IMoveChain> _moveChains;

    public IEnumerable<IMoveChain> MoveChains => _moveChains;

    public MoveList()
    {
        _singleMoves = new();
        _moveChains = new();
    }

    public void AddMove(Position endPosition, IMove move) => _singleMoves.Add(new SingleMove(endPosition, move));

    public void AddMoveChain(IMoveChain moveChain) => _moveChains.Add(moveChain);

    public IEnumerable<ISingleMove> GetAllMoves() => _moveChains.SelectMany(moveChain => moveChain.GetAllMoves()).Concat(_singleMoves);

    public bool HasMoveTo(Position endPosition) => _moveChains.Any(moveChain => moveChain.HasMoveTo(endPosition)) || _singleMoves.Any(move => move.EndPosition == endPosition);

    public void RemoveMoveTo(Position endPosition)
    {
        foreach (var moveChain in _moveChains)
        {
            moveChain.RemoveMoveTo(endPosition);
        }
        _singleMoves.RemoveAll(move => move.EndPosition == endPosition);
    }
}
