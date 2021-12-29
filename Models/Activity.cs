using System.Runtime.Serialization;

namespace Models
{
    [DataContract]
    public class Activity
    {
        // Datamembers

        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string? title { get; set; }

        [DataMember]
        public DateTime dateTime { get; set; }

        [DataMember]
        public string? description { get; set; }

        // Constructor
        public Activity(int id, string title, DateTime dateTime)
        {
            this.id = id;
            this.title = title;
            this.dateTime = dateTime;
        }

    }
}