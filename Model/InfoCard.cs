namespace Model
{
    public class InfoCard
    {
        public InfoCard(string info, string pictureUrl)
        {
            PictureUrl = pictureUrl;
            Info = info;
        }

        public string PictureUrl { get; set; }

        public string Info { get; set; }
    }
}