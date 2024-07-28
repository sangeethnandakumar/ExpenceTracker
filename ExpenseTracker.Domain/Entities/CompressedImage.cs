using Domain.Primitives;

namespace Domain.Entities
{
    public sealed class CompressedImage : Entity
    {
        public CompressedImage(string mapId, byte[] data) : base(Guid.NewGuid())
        {
            MapId = mapId;
            Data = data;
        }

        public string MapId { get; set; }
        public byte[] Data { get; set; }
    }
}
