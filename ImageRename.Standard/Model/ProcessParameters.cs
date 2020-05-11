namespace ImageRename.Standard.Model
{
    public class ProcessParameters
    {
        public bool FindOnly { get;  set; }
        public object MoveToProcessed { get;  set; }
        public string ProcessedPath { get; set; }
        public bool SortByYear { get; set; }
        public string SourcePath { get; set; }
        public bool WriteReverseGeotag { get;  set; }
        public bool OnlyShowfilesToChange { get; set; }
    }
}