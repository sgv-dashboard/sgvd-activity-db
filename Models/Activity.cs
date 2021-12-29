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
        public string title { get; set; }

        [DataMember]
        public string group { get; set; }

        [DataMember]
        public DateTime dateTime { get; set; }

        [DataMember]
        public string? description { get; set; }

        // Constructor
        public Activity(int id, string title)
        {
            this.id = id;
            this.title = title;
        }

        public Activity(string title, string group, DateTime dateTime, string? description)
        {
            this.title = title;
            this.group = group;
            this.dateTime = dateTime;
            this.description = description;
        }
    }
}