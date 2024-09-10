namespace Chess;

class File : IEquatable<File>
{
    private readonly int _file;

    public File(int file) => _file = file;

    public File(char file) => _file = file - 'a';

    public bool IsValid() => _file >= 0 && _file <= 7;

    public static implicit operator int(File file) => file._file;

    public static implicit operator File(int file) => new(file);

    public override string ToString() => IsValid() ? $"{(char)(_file + 'a')}" : "[invalid file]";

    public bool Equals(File? other) => _file == other?._file;
}
