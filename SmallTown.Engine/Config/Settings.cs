namespace SmallTown.Config
{
    public sealed class Settings
    {
        public WorldConfig World { get; set; }

        public string[] I18n { get; set; }
    }

    public sealed class WorldConfig
    {
        public int FrameInterval { get; set; }
    }
}