using SFML.Graphics;
using SFML.Window;

using Chess;
using Chess.Move;
using Chess.Move.Container;

class Program
{
    static void Main(string[] args)
    {
        const int WINDOW_SIZE_X = 800;
        const int WINDOW_SIZE_Y = 800;
        RenderWindow window = new(new VideoMode(WINDOW_SIZE_X, WINDOW_SIZE_Y), "Chess");
        window.SetFramerateLimit(144);

        window.Closed += OnWindowClosed;

        MoveMap moveMap = new();
        MoveList moveList = new();
        MoveChain moveChain = new();

        moveChain.AddMove("a2", new RegularMove("a1", "a2"));
        moveChain.AddMove("a3", new RegularMove("a1", "a3"));
        moveChain.AddMove("a4", new CaptureMove("a1", "a4", Piece.Pawn(PieceColor.Black)));

        moveList.AddMoveChain(moveChain);
        moveMap.AddMoveList("a1", moveList);

        Console.WriteLine(moveMap.HasMoveTo("a5"));

        Board board = new();

        while (window.IsOpen)
        {
            window.DispatchEvents();

            window.Clear();
            window.Display();
        }
    }

    private static void OnWindowClosed(object? sender, EventArgs e)
    {
        RenderWindow? window = (RenderWindow?)sender;
        window?.Close();
    }
}
