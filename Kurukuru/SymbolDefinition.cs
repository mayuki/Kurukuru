namespace Kurukuru
{
    public class SymbolDefinition
    {
        public string Default { get; }
        public string Fallback { get; }

        public SymbolDefinition(string defaultValue, string fallback)
        {
            Default = defaultValue;
            Fallback = fallback;
        }
    }
}
