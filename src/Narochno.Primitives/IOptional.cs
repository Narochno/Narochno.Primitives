namespace Narochno.Primitives
{
    public interface IOptional
    {
        bool HasValue { get; }
        bool HasNoValue { get; }
        object Value { get; }
    }
}