namespace Chess.Move;

interface IMove
{
    void Execute(Board board);
    void Undo(Board board);
}
