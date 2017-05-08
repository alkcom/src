namespace Niscon.Raynok.Models.Mock
{
    public class FooterMock
    {
        public FooterMock()
        {
            SelectedNode = new Cue("Front curtain in");
        }

        public Cue SelectedNode { get; set; }
        public bool IsCueTreeVisible { get; set; }
    }
}
