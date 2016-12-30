namespace Narochno.Primitives
{
    public interface IOptional
    {
        bool IsSet { get; }
        bool NotSet { get; }
        object Value { get; }
    }
}