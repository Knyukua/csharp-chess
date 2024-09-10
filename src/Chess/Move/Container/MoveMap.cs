namespace Chess.Move.Container;

interface IMoveMap
{
    void RemoveMove(Position startPosition, Position endPosition);
    void AddMoveList(Position startPosition, IMoveList moveList);
    IEnumerable<ISingleMove> GetAllMovesFrom(Position position);
    bool HasMoveTo(Position position);
    IEnumerable<IMoveChain> GetMoveChainsWithMoveTo(Position endPosition);
}

class MoveMap : IMoveMap
{
    private Dictionary<Position, IMoveList> _moveMap;

    public MoveMap()
    {
        _moveMap = new();
    }

    public void AddMoveList(Position startPosition, IMoveList moveList) => _moveMap[startPosition] = moveList;

    public IEnumerable<ISingleMove> GetAllMovesFrom(Position position) 
        => _moveMap.ContainsKey(position) ? _moveMap[position].GetAllMoves() : Enumerable.Empty<ISingleMove>();

    public IEnumerable<IMoveChain> GetMoveChainsWithMoveTo(Position endPosition) 
        => _moveMap.SelectMany(kvp => kvp.Value.MoveChains).Where(moveChain => moveChain.HasMoveTo(endPosition));

    public bool HasMoveTo(Position position) => _moveMap.Any(kvp => kvp.Value.HasMoveTo(position));

    public void RemoveMove(Position startPosition, Position endPosition)
    {
        if (!_moveMap.ContainsKey(startPosition)) return;
        _moveMap[startPosition].RemoveMoveTo(endPosition);
    }
}