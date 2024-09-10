namespace Chess;

class Position : IEquatable<Position>
{
    public File File { get; private set; }
    public Rank Rank { get; private set; }

    public Position(File file, Rank rank)
    {
        File = file;
        Rank = rank;
    }

    public Position(string position)
    {
        if (position.Length != 2) throw new ArgumentException("Position notation string length must be equal to '2'");
        File = new(position[0]);
        Rank = new(position[1]);
    }

    public bool IsValid() => File.IsValid() && Rank.IsValid();

    public static implicit operator Position(string position) => new(position);

    public override string ToString() => $"{File}{Rank}";

    public override int GetHashCode() => ToString().GetHashCode();

    public static bool operator==(Position a, Position b) => a.Equals(b);
    public static bool operator!=(Position a, Position b) => !a.Equals(b);

    public override bool Equals(object? obj)
    {
        return this.Equals(obj as Position);
    }

    public bool Equals(Position? other) => File.Equals(other?.File) && Rank.Equals(other?.Rank);
}
