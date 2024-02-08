namespace TarkovPacketSer.BSG_Classes
{
    public class GitVersion
    {
        public static GitVersion Deserialize(BinaryReader reader)
        {
            return new GitVersion
            {
                CommitHash = reader.ProperReadString(),
                CommitDate = DateTime.FromOADate(reader.ReadDouble()),
                CommitSubject = reader.ProperReadString(),
                CommitBranch = reader.ProperReadString()
            };
        }

        public string CommitHash = "c942d618e8bab1e70aa2385ae798251a8dd9ef76";

        public DateTime CommitDate = DateTime.FromOADate(45313.5139930556);

        public string CommitSubject = "Export to server";

        public string CommitBranch = "release/0.14.0.1";
    }
}
