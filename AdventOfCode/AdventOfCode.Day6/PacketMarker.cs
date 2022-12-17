namespace AdventOfCode.Day6
{
    internal class PacketMarker
    {
        private readonly int bufferSize;
        private readonly List<string> _buffer;
        
        private int markerStartLocation = default;

        public int StartOfpacketMarker { get; private set; }

        public PacketMarker(int bufferSize)
        {
            this.bufferSize = bufferSize;
            _buffer = new();
        }

        public bool AddCharacterAndCheckForStart(string character)
        {
            if (_buffer.Count == bufferSize)
            {
                _buffer.RemoveAt(0);
            }

            _buffer.Add(character);
            markerStartLocation++;

            return _buffer.Count == bufferSize ? CheckForStart() : false;
        }

        public int GetMarkerLocation()
        {
            return markerStartLocation;
        }

        private bool CheckForStart()
        {
            return _buffer.Count == _buffer.Distinct().Count();
        }
    }
}
