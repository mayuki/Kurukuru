namespace Kurukuru
{
    public class Pattern
    {
        public string[] Frames { get; }
        public int Interval { get; }

        public Pattern(string[] frames, int interval)
        {
            Frames = frames;
            Interval = interval;
        }
    }
}
