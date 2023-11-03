namespace Folders.Models
{
    public class Folder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentFolderId {  get; set; }
        public Folder ParentFolder { get; set; }
        public List<Folder> SubFolders { get; set; }
   
    }
}
