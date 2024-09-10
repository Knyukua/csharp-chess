namespace Chess;

class Rank : IEquatable<Rank>
{
    private readonly int _rank;

    public Rank(int rank) => _rank = rank;

    public Rank(char rank) => _rank = rank - '1';

    public bool IsValid() => _rank >= 0 && _rank <= 7;

    public static implicit operator int(Rank rank) => rank._rank;

    public static implicit operator Rank(int rank) => new(rank);

    public override string ToString() => IsValid() ? $"{_rank + 1}" : "[invalid rank]";

    public bool Equals(Rank? other) => _rank == other?._rank;
}
