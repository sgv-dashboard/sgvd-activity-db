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
        public string? group { get; set; }

        [DataMember]
        public DateTime dateTime { get; set; }

        [DataMember]
        public string? location { get; set; }

        [DataMember]
        public string? description { get; set; }

        // Constructor
        public Activity(int id, string title)
        {
            this.id = id;
            this.title = title;
        }

        public Activity(string title, string group, DateTime dateTime, string? location, string? description)
        {
            this.title = title;
            this.group = group;
            this.dateTime = dateTime;
            this.location = location;
            this.description = description;
        }

        public void updateFrom(Activity a)
        {
            Console.WriteLine($"Update activity:\n\ttitle: {a.title}\n\tgroup: {a.group}\n\tdateTime: {a.dateTime}\n\tdescription: {a.description}\n\t");
            this.title = a.title == null ? this.title : a.title;
            this.group = a.group == null ? this.group : a.group;
            this.dateTime = a.dateTime == new DateTime() ? this.dateTime : a.dateTime;
            this.description = a.description == null ? this.description : a.description;
            this.location = a.location == null ? this.location : a.location;
        }
    }
}